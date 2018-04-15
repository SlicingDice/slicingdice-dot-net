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
        private Dictionary<string, dynamic> ColumnTranslation { get; set; }
        private int SleepTime { get; set; }
        private string Path { get; set; }
        private string Extension { get; set; }
        public int NumSuccesses { get; set; }
        public int NumFails { get; set; }
        public List<dynamic> FailedTests { get; set; }
        private bool perTestInsert;
        private bool insertSqlData = false;
        public SlicingDiceTester(string apiKey, bool verbose = false)
        {
            this.Client = new SlicingDice(masterKey: apiKey);
            this.Verbose = verbose;
            // Path of examples directory, the replace is needed to point to the correct path, and it works on Unix and Windows systems
            this.Path = Directory.GetCurrentDirectory().Replace(@"\bin\Debug", @"\examples\").Replace(@"/bin/Debug", @"/examples/");
            // Extension of examples files
            this.Extension = ".json";
            this.NumSuccesses = 0;
            this.NumFails = 0;
            // Sleep time in seconds
            this.SleepTime = 10;
            this.FailedTests = new List<dynamic>();
        }

        /// <summary>Run all the tests for a determined query type</summary>
        /// <param name="queryType">The type of the query to test</param>
        public void RunTests(string queryType)
        {
            List<Dictionary<string, dynamic>> testData = this.LoadTestData(queryType);
            int numTests = testData.Count();
            int counter = 0;

            this.perTestInsert = testData[0].ContainsKey("insert");

            if (!this.perTestInsert && this.insertSqlData) {
                List<Dictionary<string, dynamic>> insertData = this.LoadTestData(queryType, "_insert");
                foreach (Dictionary<string, dynamic> insert in insertData) {
                    this.Client.Insert(insert);
                }
                Thread.Sleep(this.SleepTime * 1000);
            }

            foreach (Dictionary<string, dynamic> test in testData)
            {
                this.EmptyColumnTranslation();

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
                    if (this.perTestInsert) {
                        this.CreateColumns(test);
                        this.InsertData(test);
                    }
                    result = this.ExecuteQuery(queryType, test);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                    result = new Dictionary<string, dynamic>(){
                        {"result", new Dictionary<string, dynamic>(){
                            {"error", e.Message}
                        }}
                    };
                }

                this.CompareResult(test, result);
            }
        }

        // Erase column translation dictionary
        private void EmptyColumnTranslation()
        {
            this.ColumnTranslation = new Dictionary<string, dynamic>();
        }

        /// <summary>Load test data from examples files</summary>
        /// <param name="queryType">Type of the query</param>
        private List<Dictionary<string, dynamic>> LoadTestData(string queryType, string suffix = "")
        {
            string queriesText = string.Empty;
            using (StreamReader streamReader = new StreamReader(this.Path + queryType + suffix + this.Extension, Encoding.UTF8))
            {
                queriesText = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(queriesText);
        }

        /// <summary>Create columns for a given test</summary>
        /// <param name="test">Dictionary containing test name, columns metadata, data to be inserted, query, and expected results.</param>
        private void CreateColumns(Dictionary<string, dynamic> test)
        {
            JArray columnsData = test["columns"];
            List<Dictionary<string, dynamic>> columns = columnsData.ToObject<List<Dictionary<string, dynamic>>>();
            bool isSingular = columns.Count == 1;
            string columnOrColumns = string.Empty;

            if (isSingular)
            {
                columnOrColumns = "column";
            }
            else
            {
                columnOrColumns = "columns";
            }
            System.Console.WriteLine(string.Format("  Creating {0} {1}", columns.Count, columnOrColumns));

            for(int i = 0; i < columns.Count; i++) {
                Dictionary<string, dynamic> column = columns[i];
                this.AddTimestampToColumnName(column);
                this.Client.CreateColumn(column);

                if (this.Verbose)
                {
                    System.Console.WriteLine(string.Format("    - {0}", column["api-name"]));
                }
            }
        }

        /// <summary> Add timestamp to column name
        /// This technique allows the same test suite to be executed over and over again, since each execution will use different column names.
        /// </summary>
        /// <param name="column">Dicitonary containing the column to append timestamp</param>
        private void AddTimestampToColumnName(Dictionary<string, dynamic> column)
        {
            string oldName = string.Format("\"{0}", column["api-name"]);

            string timestamp = this.GetTimestamp();
            column["name"] = column["name"] + timestamp;
            column["api-name"] = column["api-name"] + timestamp;

            string newName = string.Format("\"{0}", column["api-name"]);
            this.ColumnTranslation[oldName] = newName;
        }

        // Get current timestamp in string format
        private string GetTimestamp()
        {
            return DateTime.Now.Ticks.ToString();
        }

        ///<summary>Insert test data on SlicingDice API</summary>
        ///<param name="test">Dictionary containing test name, columns metadata, data to be inserted, query, and expected results.</param>
        private void InsertData(Dictionary<string, dynamic> test)
        {
            JObject insertionObject = test["insert"];
            Dictionary<string, dynamic> insert = insertionObject.ToObject<Dictionary<string, dynamic>>();
            bool isSingular = insert.Count == 1;
            string entityOrEntities = string.Empty;

            if (isSingular)
            {
                entityOrEntities = "entity";
            }
            else
            {
                entityOrEntities = "entities";
            }
            System.Console.WriteLine(string.Format("  Inserting {0} {1}", insert.Count, entityOrEntities));

            Dictionary<string, dynamic> insertionData = this.TranslateColumnNames(insert);

            if (this.Verbose)
            {
                foreach (KeyValuePair<string, dynamic> entity in insertionData)
                {
                    System.Console.WriteLine(string.Format("    - \"{0}\": {1}", entity.Key, entity.Value));
                }
            }

            this.Client.Insert(insertionData);

            // Wait a few seconds so the data can be inserted by SlicingDice
            Thread.Sleep(this.SleepTime * 1000);
        }

        // Translate column name to match column name with timestamp.
        private Dictionary<string, dynamic> TranslateColumnNames(Dictionary<string, dynamic> data){
            string dataString = JsonConvert.SerializeObject(data);

            foreach (KeyValuePair<string, dynamic> entry in this.ColumnTranslation)
            {
                dataString = dataString.Replace(entry.Key, (string)entry.Value);
            }

            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dataString);
        }

        /// <summary>Execute a query on SlicingDice API</summary>
        /// <param name="queryType">The type of the query</param>
        /// <param name="test">Dictionary containing test name, columns metadata, data to be inserted, query, and expected results.</param>
        private Dictionary<string, dynamic> ExecuteQuery(string queryType, Dictionary<string, dynamic> test)
        {
            dynamic queryData;
            if (this.perTestInsert) {
                JObject testQuery = test["query"];
                Dictionary<string, object> query = testQuery.ToObject<Dictionary<string, object>>();
                queryData = this.TranslateColumnNames(query);
            } else {
                queryData = test["query"];
            }
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
                result = this.Client.CountEntity(queryData);
            }
            else if (queryType == "count_event")
            {
                result = this.Client.CountEvent(queryData);
            }
            else if (queryType == "top_values")
            {
                result = this.Client.TopValues(queryData);
            }
            else if (queryType == "aggregation")
            {
                result = this.Client.Aggregation(queryData);
            }
            else if (queryType == "result")
            {
                result = this.Client.Result(queryData);
            }
            else if (queryType == "score")
            {
                result = this.Client.Score(queryData);
            }
            else if (queryType == "sql")
            {
                result = this.Client.Sql(queryData);
            }

            return result;
        }

        // Compare expected result with the result obtained from SlicingDice API
        private void CompareResult(Dictionary<string, dynamic> test, Dictionary<string, dynamic> result)
        {
            Dictionary<string, dynamic> rawExpected = test["expected"].ToObject<Dictionary<string, dynamic>>();
            Dictionary<string, dynamic> expected;
            if (this.perTestInsert) {
                expected = this.TranslateColumnNames(rawExpected);
            } else {
                expected = rawExpected;                
            }

            if (!this.CompareDictionary(expected, result)) {
                this.NumFails += 1;
                this.FailedTests.Add(test["name"]);

                string expectedString = JsonConvert.SerializeObject(expected).Trim();
                string resultString = JsonConvert.SerializeObject(result).Trim();

                System.Console.WriteLine(string.Format("  Expected: {0}", expectedString));
                System.Console.WriteLine(string.Format("  Result: {0}", resultString));
                System.Console.WriteLine("  Status: Failed\n");
                return;
            }

            this.NumSuccesses += 1;
            System.Console.WriteLine("  Status: Passed\n");
        }

        private bool CompareDictionary(IDictionary<string, dynamic> expected, IDictionary<string, dynamic> got)
        {
            // early-exit checks
            if (null == got) {
                return null == expected;
            }
            if (null == expected) {
                return false;
            }
            if (object.ReferenceEquals(expected, got)) {
                return true;
            }

            // check if keys and values are the same
            foreach (string k in expected.Keys) {
                if (!got.ContainsKey(k)) {
                    return false;
                }
                string expectedString = expected[k].ToString();

                if(expectedString == "ignore") {
                    continue;
                }

                dynamic expectedValue = expected[k];
                dynamic gotValue = got[k];
                if(!this.CompareDictionaryValue(expectedValue, gotValue)) {
                    return false;
                }
            }

            return true;
        }

        private bool CompareList(List<dynamic> expected, List<dynamic> got)
        {
            // early-exit checks
            if (null == got) {
                return null == expected;
            }
            if (null == expected) {
                return false;
            }
            if (object.ReferenceEquals(expected, got)) {
                return true;
            }

            if (expected.Count != got.Count) {
                return false;
            }

            // check if keys and values are the same
            for (var i = 0; i < expected.Count; i++) {
                dynamic expectedValue = expected[i];
                bool hasValue = false;
                for (var j = 0; j < got.Count; j++) {
                    dynamic gotValue = got[j];

                    if (this.CompareDictionaryValue(expectedValue, gotValue)) {
                        hasValue = true;
                    }
                }

                if (!hasValue) {
                    return false;
                }
            }

            return true;
        }

        private bool CompareDictionaryValue(dynamic expected, dynamic got)
        {
            if(expected is Dictionary<string, dynamic> || expected is JObject) {
                if (expected is JObject) {
                    expected = expected.ToObject<Dictionary<string, dynamic>>();
                    got = got.ToObject<Dictionary<string, dynamic>>();
                }

                if(!this.CompareDictionary(expected, got)) {
                    return false;
                }
            } else if(expected is List<dynamic> || expected is JArray) {
                if (expected is JArray) {
                    expected = expected.ToObject<List<dynamic>>();
                    got = got.ToObject<List<dynamic>>();
                }

                if(!this.CompareList(expected, got)) {
                    return false;
                }
            } else {
                string expectedString = expected.ToString();
                string gotString = got.ToString();

                if (!expectedString.Equals(gotString)) {
                    return false;
                }
            }

            return true;
        }
    }
}
