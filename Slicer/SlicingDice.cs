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

        private string _enviromentAddress = Environment.GetEnvironmentVariable("SD_API_ADDRESS");
        private string _baseUrl = null;
        private bool _usesTestEndpoint;
        public SlicingDice(string masterKey=null, string customKey=null, string writeKey=null, string readKey=null, int timeout=60, bool usesTestEndpoint=false)
        {
            this.Keys = this.OrganizeKeys(masterKey, customKey, writeKey, readKey);
            this.Timeout = timeout;
            this._baseUrl = this.GetBaseUrl();
            this._usesTestEndpoint = usesTestEndpoint;
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

        /* Get base url to access SlicingDice API */
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
        /// <summary>Make a HTTP request to SlicingDice API (only DELETE and GET)</summary>
        /// <param name="URL">Url to make request.</param>
        /// <param name="delete">if true it will make a delete request.</param>
        /// <param name="keyLevel">Minimum key level to make the request.</param>
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
        /// <summary>Make a HTTP request to SlicingDice API (only POST and PUT)</summary>
        /// <param name="URL">Url to make request.</param>
        /// <param name="query">The query to send to SlicingDice API.</param>
        /// <param name="update">if true it will make a put request.</param>
        /// <param name="keyLevel">Minimum key level to make the request.</param>
        private Dictionary<string, dynamic> MakeRequest(string url, dynamic query, bool update, int keyLevel)
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

        /// <summary>Makes a count query on SlicingDice API</summary>
        /// <param name="URL">Url to make request, identify if it's a count entity or a count event.</param>
        /// <param name="query">The count query.</param>
        private Dictionary<string, dynamic> CountQueryWrapper(string url, Dictionary<string, dynamic> query)
        {
            var sdValidator = new QueryCountValidator(query);
            if (sdValidator.Validator())
            {
                return this.MakeRequest(url, query, false, 0);
            }
            return null;
        }

        /// <summary>Makes a count query on SlicingDice API</summary>
        /// <param name="URL">Url to make request, identify if it's a count entity or a count event.</param>
        /// <param name="query">The count query.</param>
        private Dictionary<string, dynamic> CountQueryWrapper(string url, List<dynamic> query)
        {
            var sdValidator = new QueryCountValidator(query);
            if (sdValidator.Validator())
            {
                return this.MakeRequest(url, query, false, 0);
            }
            return null;
        }

        private string testWrapper()
        {
            if (this._usesTestEndpoint) return this._baseUrl + "/test";
            return this._baseUrl;
        }

        /// <summary>Makes a data extraction query (score or result) on SlicingDice API</summary>
        /// <param name="URL">Url to make request, identify if it's a score or result query.</param>
        /// <param name="query">The data extraction query.</param>
        private Dictionary<string, dynamic> DataExtractionQueryWrapper(string url, Dictionary<string, dynamic> query)
        {
            var sdValidator = new DataExtractionQueryValidator(query);
            if (sdValidator.Validator())
            {
                return this.MakeRequest(url, query, false, 0);
            }
            return null;
        }

        /// <summary>Get all fields</summary>
        public Dictionary<string, dynamic> GetFields()
        {
            var url = this.testWrapper() + URLResources.Field;
            return this.MakeRequest(url, false, 2);
        }

        /// <summary>Get all projects</summary>
        public Dictionary<string, dynamic> GetProjects()
        {
            var url = this.testWrapper() + URLResources.Project;
            return this.MakeRequest(url, false, 2);
        }

        /// <summary>Get a saved query</summary>
        /// <param name="savedQueryName">The name of the saved query that will be retrieved.</param>
        public Dictionary<string, dynamic> GetSavedQuery(string savedQueryName)
        {
            var url = this.testWrapper() + URLResources.QuerySaved + savedQueryName;
            return this.MakeRequest(url, false, 0);
        }

        /// <summary>Get all saved queries</summary>
        public Dictionary<string, dynamic> GetSavedQueries()
        {
            var url = this.testWrapper() + URLResources.QuerySaved;
            return this.MakeRequest(url, false, 2);
        }

        /// <summary>Create a field on SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> CreateField(dynamic query)
        {
            var url = this.testWrapper() + URLResources.Field;
            var sdValidator = new FieldValidator(query);
            if (sdValidator.Validator()) return this.MakeRequest(url, query, false, 1);
            return null;
        }

        /// <summary>Send a indexation command to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        /// <param name="autoCreateFields">if true SlicingDice API will create nonexistent fields automatically</param>
        public Dictionary<string, dynamic> Index(Dictionary<string, dynamic> query, bool autoCreateFields = false)
        {
            if (autoCreateFields)
            {
                query.Add("auto-create-fields", autoCreateFields);
            }
            var url = this.testWrapper() + URLResources.Index;
            return this.MakeRequest(url, query, false, 1);
        }
        
        /// <summary>Makes a count entity query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> CountEntity(Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryCountEntity;
            return this.CountQueryWrapper(url, query);
        }

        /// <summary>Makes a count entity query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> CountEntity(List<dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryCountEntity;
            return this.CountQueryWrapper(url, query);
        }

        /// <summary>Makes a total query to SlicingDice API</summary>
        public Dictionary<string, dynamic> CountEntityTotal()
        {
            var url = this.testWrapper() + URLResources.QueryCountEntityTotal;
            return this.MakeRequest(url, false, 0);
        }

        /// <summary>Makes a count event query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> CountEvent(Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryCountEvent;
            return this.CountQueryWrapper(url, query);
        }

        /// <summary>Makes a count event query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> CountEvent(List<dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryCountEvent;
            return this.CountQueryWrapper(url, query);
        }

        /// <summary>Makes a aggregation query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> Aggregation(Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryAggregation;
            return this.MakeRequest(url, query, false, 0);
        }

        /// <summary>Makes a Top Values query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> TopValues(Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryTopValues;
            var sdValidator = new QueryTopValuesValidator(query);
            if (sdValidator.Validator())
            {
                return this.MakeRequest(url, query, false, 0);
            }
            return null;
        }

        /// <summary>Makes a exists query to SlicingDice API</summary>
        /// <param name="ids">List of ids to test existence on SlicingDice API.</param>
        public Dictionary<string, dynamic> ExistsEntity(List<string> ids)
        {
            Dictionary<string, dynamic> query = new Dictionary<string, dynamic>{
                {"ids", ids}
            };
            var url = this.testWrapper() + URLResources.QueryExistsEntity;
            return this.MakeRequest(url, query, false, 0);
        }

        /// <summary>Create a saved query on SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> CreateSavedQuery(Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QuerySaved;
            var savedQuery = new SavedQueryValidator(query);
            if (savedQuery.Validator())
            {
                return this.MakeRequest(url, query, false, 2);
            }
            return null;
        }

        /// <summary>Update a previous saved query on SlicingDice API</summary>
        /// <param name="querySavedName">The name of the saved query that will be updated.</param>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> UpdateSavedQuery(string querySavedName, Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QuerySaved + querySavedName;
            return this.MakeRequest(url, query, true, 2);
        }

        /// <summary>Delete a saved query on SlicingDice API</summary>
        /// <param name="savedQueryName">The name of the saved query that will be deleted.</param>
        public Dictionary<string, dynamic> DeleteSavedQuery(string savedQueryName)
        {
            var url = this.testWrapper() + URLResources.QuerySaved + savedQueryName;
            return this.MakeRequest(url, true, 2);
        }

        /// <summary>Makes a result query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> Result(Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryDataExtractionResult;
            return this.DataExtractionQueryWrapper(url, query);
        }

        /// <summary>Makes a score query to SlicingDice API</summary>
        /// <param name="query">The query to send to SlicingDice API</param>
        public Dictionary<string, dynamic> Score(Dictionary<string, dynamic> query)
        {
            var url = this.testWrapper() + URLResources.QueryDataExtractionScore;
            return this.DataExtractionQueryWrapper(url, query);
        }
    }
}
