using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slicer.Utils.Exceptions;
using Slicer.Core;
using Slicer.Utils;
using System.Net.Http;
using Newtonsoft.Json;
using Slicer.Utils.Validators;

namespace Slicer
{
    public class SlicingDice
    {
        private string CurrentKey { get; set; }
        private int Timeout { get; set; }
        private Dictionary<string, string> Keys { get; set; }

        private string _enviromentAddress = Environment.GetEnvironmentVariable("SD_ADDRESS_API", EnvironmentVariableTarget.Machine);
        private string _baseUrl = null;
        public SlicingDice(string masterKey=null, string customKey=null, string writeKey=null, string readKey=null, int timeout=60)
        {
            this.Keys = this.OrganizeKeys(masterKey, customKey, writeKey, readKey);
            this.Timeout = timeout;
            this._baseUrl = this.GetBaseUrl();
        }
        private Dictionary<string, string> OrganizeKeys(string masterKey, string customKey, string writeKey, string readKey)
        {
            return new Dictionary<string, string>(){
                {"masterKey", masterKey},
                {"customKey", customKey},
                {"writeKey", writeKey},
                {"readKey", readKey}
            };
        }
        private string GetBaseUrl()
        {
            return String.IsNullOrEmpty(this._enviromentAddress) ? "https://api.slicingdice.com/v1" : this._enviromentAddress;
        }
        private List<dynamic> GetKey()
        {
            if (this.Keys["masterKey"] != null)
                return new List<dynamic>(){
                    this.Keys["masterKey"], 2
                };
            else if (this.Keys["customKey"] != null)
                return new List<dynamic>(){
                    this.Keys["customKey"], 2
                };
            else if (this.Keys["writeKey"] != null)
                return new List<dynamic>(){
                    this.Keys["writeKey"], 1
                };
            else if (this.Keys["readKey"] != null)
                return new List<dynamic>(){
                    this.Keys["readKey"], 0
                };
            throw new InvalidSlicingDiceKeysException("You need put a key.");
        }
        private string GetKey(int keyLevel)
        {
            List<dynamic> currentKeyLevel = this.GetKey();
            if ((int)currentKeyLevel[1] == 2)
            {
                return (string)currentKeyLevel[0];
            }
            if ((int)currentKeyLevel[1] != keyLevel)
            {
                throw new InvalidSlicingDiceKeysException("This key is not allowed to perform this operation.");
            }
            return (string)currentKeyLevel[0];
        }
        private Dictionary<string, dynamic> MakeRequest(string url, bool delete, int keyLevel)
        {
            string response;
            var key = this.GetKey(keyLevel);
            var headers = new Dictionary<string, string>()
            {
                {"authorization", key}
            };
            if (delete) response = Requester.Delete(url, headers).Content.ReadAsStringAsync().Result;
            else response = Requester.Get(url, headers);
            if (this.HandlerResponseRequester(response))
            {
                return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);
            }
            return null;
        }
        private Dictionary<string, dynamic> MakeRequest(string url, Dictionary<string, dynamic> query, bool update, int keyLevel)
        {
            HttpResponseMessage response;
            var key = this.GetKey(keyLevel);
            var headers = new Dictionary<string, string>()
            {
                {"authorization", key}
            };
            if (update)
            {
                response = Requester.Put(url, query, headers);
            }
            else
            {
                response = Requester.Post(url, query, headers);
            }
            var responseString = response.Content.ReadAsStringAsync().Result;
            if (this.HandlerResponseRequester(responseString))
            {
                if (RequestSuccessful(response))
                {
                    return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseString);
                }
            }
            return null;
        }
        private static bool RequestSuccessful(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new SlicingDiceHttpException("HTTP Error: " + response.ReasonPhrase);
            }
            return true;
        }
        private bool HandlerResponseRequester(string response)
        {
            Dictionary<string, dynamic> result;
            try
            {
                result = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);
            }
            catch (JsonException e)
            {
                throw new InternalException("SlicingDice: Internal error");
            }
            var handlerResponse = new HandlerResponse(result);
            if (handlerResponse.RequestSuccessful())
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, dynamic> CountQueryWrapper(string url, Dictionary<string, dynamic> query)
        {
            var sdValidator = new QueryCountValidator(query);
            if (sdValidator.Validator())
            {
                return this.MakeRequest(url, query, false, 0);
            }
            return null;
        }
        private string testWrapper(bool test)
        {
            if (test) return this._baseUrl + "/test";
            return this._baseUrl;
        }
        private Dictionary<string, dynamic> DataExtractionQueryWrapper(string url, Dictionary<string, dynamic> query)
        {
            var sdValidator = new DataExtractionQueryValidator(query);
            if (sdValidator.Validator())
            {
                return this.MakeRequest(url, query, false, 0);
            }
            return null;
        }
        public Dictionary<string, dynamic> GetFields(bool test=false)
        {
            var url = this.testWrapper(test) + URLResources.Field;
            return this.MakeRequest(url, false, 2);
        }
        public Dictionary<string, dynamic> GetProjects(bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.Project;
            return this.MakeRequest(url, false, 2);
        }
        public Dictionary<string, dynamic> GetSavedQuery(string savedQueryName, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QuerySaved + savedQueryName;
            return this.MakeRequest(url, false, 0);
        }
        public Dictionary<string, dynamic> GetSavedQueries(bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QuerySaved;
            return this.MakeRequest(url, false, 2);
        }
        public Dictionary<string, dynamic> CreateField(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.Field;
            var sdValidator = new FieldValidator(query);
            if (sdValidator.Validator()) return this.MakeRequest(url, query, false, 1);
            return null;
        }
        public Dictionary<string, dynamic> Index(Dictionary<string, dynamic> query, bool autoCreateFields = false, bool test = false)
        {
            if (autoCreateFields)
            {
                query.Add("auto-create-fields", autoCreateFields);
            }
            var url = this.testWrapper(test) + URLResources.Index;
            return this.MakeRequest(url, query, false, 1);
        }
        public Dictionary<string, dynamic> CountEntity(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QueryCountEntity;
            return this.CountQueryWrapper(url, query);
        }
        public Dictionary<string, dynamic> CountEntityTotal(bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QueryCountEntityTotal;
            return this.MakeRequest(url, false, 0);
        }
        public Dictionary<string, dynamic> CountEvent(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QueryCountEvent;
            return this.CountQueryWrapper(url, query);
        }
        public Dictionary<string, dynamic> Aggregation(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QueryAggregation;
            return this.MakeRequest(url, query, false, 0);
        }
        public Dictionary<string, dynamic> TopValues(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QueryTopValues;
            var sdValidator = new QueryTopValuesValidator(query);
            if (sdValidator.Validator())
            {
                return this.MakeRequest(url, query, false, 0);
            }
            return null;
        }
        public Dictionary<string, dynamic> ExistsEntity(List<string> ids, bool test = false)
        {
            Dictionary<string, dynamic> query = new Dictionary<string, dynamic>{
                {"ids", ids}
            };
            var url = this.testWrapper(test) + URLResources.QueryExistsEntity;
            return this.MakeRequest(url, query, false, 0);
        }
        public Dictionary<string, dynamic> CreateSavedQuery(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QuerySaved;
            var savedQuery = new SavedQueryValidator(query);
            if (savedQuery.Validator())
            {
                return this.MakeRequest(url, query, false, 2);
            }
            return null;
        }
        public Dictionary<string, dynamic> UpdateSavedQuery(string querySavedName, Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QuerySaved + querySavedName;
            return this.MakeRequest(url, query, true, 2);
        }
        public Dictionary<string, dynamic> DeleteSavedQuery(string savedQueryName, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QuerySaved + savedQueryName;
            return this.MakeRequest(url, true, 2);
        }
        public Dictionary<string, dynamic> Result(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QueryDataExtractionResult;
            return this.DataExtractionQueryWrapper(url, query);
        }
        public Dictionary<string, dynamic> Score(Dictionary<string, dynamic> query, bool test = false)
        {
            var url = this.testWrapper(test) + URLResources.QueryDataExtractionScore;
            return this.DataExtractionQueryWrapper(url, query);
        }
    }
}
