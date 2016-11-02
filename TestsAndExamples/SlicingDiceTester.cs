using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slicer.Core;
using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Slicer.Test
{
    public class SlicingDiceTester
    {
        private SlicingDice Client { get; set; }
        private bool Verbose { get; set; }
        private Dictionary<string, dynamic> FieldTranslation { get; set; }
        private int SleepTime { get; set; }
        private string Path { get; set; }
        private string Extension { get; set; }
        public int NumSuccesses { get; set; }
        public int NumFails { get; set; }
        public List<dynamic> FailedTests { get; set; }
        public SlicingDiceTester(string apiKey, bool verbose = false)
        {
            this.Client = new SlicingDice(masterKey: apiKey);
            this.Verbose = verbose;
            this.Path = Directory.GetCurrentDirectory().Replace(@"\bin\Debug", @"\examples\");
            this.Extension = ".json";
            this.NumSuccesses = 0;
            this.NumFails = 0;
            this.SleepTime = 5;
            this.FailedTests = new List<dynamic>();
        }

        public void RunTests(string queryType)
        {
            List<Dictionary<string, dynamic>> testData = this.LoadTestData(queryType);
            int numTests = testData.Count();
            int counter = 0;

            foreach (Dictionary<string, dynamic> test in testData)
            {
                this.EmptyFieldTranslation();

                System.Console.WriteLine(string.Format("({0}/{1}) Executing test \"{2}\"", counter + 1, numTests, test["name"]));
                counter += 1;

                if (test.ContainsKey("description"))
                {
                    System.Console.WriteLine(string.Format("  Description: {0}", test["description"]));
                }

                System.Console.WriteLine(string.Format("  Query type: {0}", queryType));
                Dictionary<string, dynamic> result = null;
                try
                {
                    this.CreateFields(test);
                    this.IndexData(test);
                    result = this.ExecuteQuery(queryType, test);
                }
                catch (Exception e)
                {
                    result = new Dictionary<string, dynamic>(){
                        {"result", new Dictionary<string, dynamic>(){
                            {"error", e.Message}
                        }}
                    };
                }

                this.CompareResult(test, result);
            }
        }

        private void EmptyFieldTranslation()
        {
            this.FieldTranslation = new Dictionary<string, dynamic>();
        }
        private List<Dictionary<string, dynamic>> LoadTestData(string queryType)
        {
            string queriesText = string.Empty;
            using (StreamReader streamReader = new StreamReader(this.Path + queryType + this.Extension, Encoding.UTF8))
            {
                queriesText = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(queriesText);
        }

        private void CreateFields(Dictionary<string, dynamic> test)
        {
            JArray fieldsData = test["fields"];
            List<Dictionary<string, dynamic>> fields = fieldsData.ToObject<List<Dictionary<string, dynamic>>>();
            bool isSingular = fields.Count == 1;
            string fieldOrFields = string.Empty;

            if (isSingular)
            {
                fieldOrFields = "field";
            }
            else
            {
                fieldOrFields = "fields";
            }
            System.Console.WriteLine(string.Format("  Creating {0} {1}", fields.Count, fieldOrFields));

            foreach(Dictionary<string, dynamic> field in fields){
                this.AddTimestampToFieldName(field);
                this.Client.CreateField(field, test: true);

                if (this.Verbose)
                {
                    System.Console.WriteLine(string.Format("    - {0}", field["api-name"]));
                }
            }
        }

        private void AddTimestampToFieldName(Dictionary<string, dynamic> field)
        {
            string oldName = string.Format("\"{0}\"", field["api-name"]);

            string timestamp = this.GetTimestamp();
            field["name"] += timestamp;
            field["api-name"] += timestamp;

            string newName = string.Format("\"{0}\"", field["api-name"]);
            this.FieldTranslation[oldName] = newName;
        }

        private string GetTimestamp()
        {
            return DateTime.Now.Ticks.ToString();
        }

        private void IndexData(Dictionary<string, dynamic> test)
        {
            JObject indexObject = test["index"];
            Dictionary<string, dynamic> index = indexObject.ToObject<Dictionary<string, dynamic>>();
            bool isSingular = index.Count == 1;
            string entityOrEntities = string.Empty;

            if (isSingular)
            {
                entityOrEntities = "entity";
            }
            else
            {
                entityOrEntities = "entities";
            }
            System.Console.WriteLine(string.Format("  Indexing {0} {1}", index.Count, entityOrEntities));

            Dictionary<string, dynamic> indexData = this.TranslateFieldNames(index);

            if (this.Verbose)
            {
                foreach (KeyValuePair<string, dynamic> entity in indexData)
                {
                    System.Console.WriteLine(string.Format("    - \"{0}\": {1}", entity.Key, entity.Value));
                }
            }

            this.Client.Index(indexData, test: true);

            // Wait a few seconds so the data can be indexed by SlicingDice
            Thread.Sleep(this.SleepTime * 1000);
        }

        private Dictionary<string, dynamic> TranslateFieldNames(Dictionary<string, dynamic> data){
            string dataString = JsonConvert.SerializeObject(data);

            foreach (KeyValuePair<string, dynamic> entry in this.FieldTranslation)
            {
                dataString = dataString.Replace(entry.Key, (string)entry.Value);
            }

            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dataString);
        }

        private Dictionary<string, dynamic> ExecuteQuery(string queryType, Dictionary<string, dynamic> test)
        {
            JObject testQuery = test["query"];
            Dictionary<string, object> query = testQuery.ToObject<Dictionary<string, object>>();
            Dictionary<string, dynamic> queryData = this.TranslateFieldNames(query);
            System.Console.WriteLine("  Querying");

            if (this.Verbose)
            {
                foreach (KeyValuePair<string, dynamic> queryElement in queryData)
                {
                    System.Console.WriteLine(string.Format("    - \"{0}\": {1}", queryElement.Key, queryElement.Value));
                }
            }

            Dictionary<string, dynamic> result = null;
            if (queryType == "count_entity")
            {
                result = this.Client.CountEntity(queryData, test: true);
            }
            else if (queryType == "count_event")
            {
                result = this.Client.CountEvent(queryData, test: true);
            }
            else if (queryType == "top_values")
            {
                result = this.Client.TopValues(queryData, test: true);
            }
            else if (queryType == "aggregation")
            {
                result = this.Client.Aggregation(queryData, test: true);
            }

            return result;
        }

        private void CompareResult(Dictionary<string, dynamic> test, Dictionary<string, dynamic> result)
        {
            Dictionary<string, dynamic> rawExpected = test["expected"].ToObject<Dictionary<string, dynamic>>();
            Dictionary<string, dynamic> expected = this.TranslateFieldNames(rawExpected);

            foreach (KeyValuePair<string, dynamic> entry in expected)
            {
                if (entry.Value is string && entry.Value == "ignore")
                {
                    continue;
                }

                Dictionary<string, dynamic> expectedValue = expected[entry.Key].ToObject<Dictionary<string, dynamic>>();
                Dictionary<string, dynamic> resultValue;

                if (result[entry.Key] is JObject)
                {
                    resultValue = result[entry.Key].ToObject<Dictionary<string, dynamic>>(); 
                }
                else
                {
                    resultValue = result[entry.Key];
                }

                string expectedString = JsonConvert.SerializeObject(expectedValue).Trim();
                string resultString = JsonConvert.SerializeObject(resultValue).Trim();

                if (expectedString != resultString)
                {
                    this.NumFails += 1;
                    this.FailedTests.Add(test["name"]);

                    System.Console.WriteLine(string.Format("  Expected: \"{0}\": {1}", entry.Key, expectedString));
                    System.Console.WriteLine(string.Format("  Result: \"{0}\": {1}", entry.Key, resultString));
                    System.Console.WriteLine("  Status: Failed\n");
                    return;
                }
            }
            this.NumSuccesses += 1;
            System.Console.WriteLine("  Status: Passed\n");
        }
    }
}
