# SlicingDice Official .NET/C# Client (v1.0)

Official .NET/C# client for [SlicingDice](http://www.slicingdice.com/), Data Warehouse and Analytics Database as a Service.  

[SlicingDice](http://www.slicingdice.com/) is a serverless, API-based, easy-to-use and really cost-effective alternative to Amazon Redshift and Google BigQuery.

## Documentation

If you are new to SlicingDice, check our [quickstart guide](http://panel.slicingdice.com/docs/#quickstart-guide) and learn to use it in 15 minutes.

Please refer to the [SlicingDice official documentation](http://panel.slicingdice.com/docs/) for more information on [analytics databases](http://panel.slicingdice.com/docs/#analytics-concepts), [data modeling](http://panel.slicingdice.com/docs/#data-modeling), [indexing](http://panel.slicingdice.com/docs/#data-indexing), [querying](http://panel.slicingdice.com/docs/#data-querying), [limitations](http://panel.slicingdice.com/docs/#current-slicingdice-limitations) and [API details](http://panel.slicingdice.com/docs/#api-details).

## Tests and Examples

Whether you want to test the client installation or simply check more examples on how the client works, take a look at [tests and examples directory](TestsAndExamples/).

## Installing

In order to install the .NET/C# client, you only need to install our package `Slicer` through the Package Manager from Visual Studio.

```
Install-Package Slicer
```

You can also install our client through the following `nuget` command.

```
nuget install Slicer
```

## Usage

`SlicingDice` encapsulates logic for sending requests to the API. Its methods are thin layers around the [API endpoints](http://panel.slicingdice.com/docs/#api-details-api-endpoints), so their parameters and return values are JSON-like `Dictionary<string, dynamic>` objects with the same syntax as the [API endpoints](http://panel.slicingdice.com/docs/#api-details-api-endpoints)

### Example:

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace Slicer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the client
            var client = new SlicingDice(masterKey: "API_KEY", usesTestEndpoint: false);

            // Creating a field
            var fieldData = new Dictionary<string, dynamic>()
            {
                {"name", "Age"},
                {"api-name", "age"},
                {"description", "User age"},
                {"type", "integer"},
                {"storage", "latest-value"}
            };
            client.CreateField(fieldData);

            // Indexing data
            var indexData = new Dictionary<string, dynamic>()
            {
                {"user1@slicingdice.com", new Dictionary<string, int>(){
                    {"age", 2}
               }}
            };
            client.Index(indexData);

            // Querying data
            var queryData = new Dictionary<string, dynamic>()
            {
                {"users-between-20-and-40",
                    new List<Dictionary<string, dynamic>>()
                    {
                        new Dictionary<string, dynamic>(){
                            {"age", new Dictionary<string, dynamic>(){
                                    {"range", new List<int>(){ 20, 40 }}
                                }
                            }
                        }
                    }
                }
            };

            var result = client.CountEntity(queryData);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

### Attributes

* `key (string)` - [API key](http://panel.slicingdice.com/docs/#api-details-api-connection-api-keys) to authenticate requests with the SlicingDice API.
* `timeout (int)` - Amount of time, in seconds, to wait for results for each request.

### Constructors

`SlicingDice(string masterKey=null, string customKey=null, string writeKey=null, string readKey=null, int timeout=60)`
* `masterKey (string)` - [API key](http://panel.slicingdice.com/docs/#api-details-api-connection-api-keys) to authenticate requests with the SlicingDice API.
* `customKey (string)` - [API key](http://panel.slicingdice.com/docs/#api-details-api-connection-api-keys) to authenticate requests with the SlicingDice API.
* `writeKey (string)` - [API key](http://panel.slicingdice.com/docs/#api-details-api-connection-api-keys) to authenticate requests with the SlicingDice API.
* `readKey (string)` - [API key](http://panel.slicingdice.com/docs/#api-details-api-connection-api-keys) to authenticate requests with the SlicingDice API.
* `timeout (int)` - Amount of time, in seconds, to wait for results for each request.
* `usesTestEndpoint (bool)` - If false the client will send requests to production end-point, otherwise to tests end-point.

### Dictionary&lt;string, dynamic> GetProjects()
Get all created projects, both active and inactive ones. This method corresponds to a [GET request at /project](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-project).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);

            var result = client.GetProjects();
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "active": [
        {
            "name": "Project 1",
            "description": "My first project",
            "data-expiration": 30,
            "created-at": "2016-04-05T10:20:30Z"
        }
    ],
    "inactive": [
        {
            "name": "Project 2",
            "description": "My second project",
            "data-expiration": 90,
            "created-at": "2016-04-05T10:20:30Z"
        }
    ]
}
```

### Dictionary&lt;string, dynamic> GetFields()
Get all created fields, both active and inactive ones. This method corresponds to a [GET request at /field](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-field).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);

            var result = client.GetFields();

            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "active": [
        {
          "name": "Model",
          "api-name": "car-model",
          "description": "Car models from dealerships",
          "type": "string",
          "category": "general",
          "cardinality": "high",
          "storage": "latest-value"
        }
    ],
    "inactive": [
        {
          "name": "Year",
          "api-name": "car-year",
          "description": "Year of manufacture",
          "type": "integer",
          "category": "general",
          "storage": "latest-value"
        }
    ]
}
```

### Dictionary&lt;string, dynamic> CreateField(Dictionary&lt;string, dynamic> query)
Create a new field. This method corresponds to a [POST request at /field](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-field).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);
            var field = new Dictionary<string, dynamic>()
            {
                {"name", "Year"},
                {"api-name", "year"},
                {"type", "integer"},
                {"description", "Year of manufacturing"},
                {"storage", "latest-value"}
            };
            var result = client.CreateField(field);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "api-name": "year"
}
```

### Dictionary&lt;string, dynamic> Index(Dictionary&lt;string, dynamic> index, bool autoCreateFields = false)
Index data to existing entities or create new entities, if necessary. This method corresponds to a [POST request at /index](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-index).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_WRITE_API_KEY", usesTestEndpoint: false);
            var index = new Dictionary<string, dynamic>()
            {
                {"user1@slicingdice.com", new Dictionary<string, dynamic>{
                    {"car-model", "Ford Ka"},
                    {"year", 2006}
                }},
                {"user2@slicingdice.com", new Dictionary<string, dynamic>{
                    {"car-model", "Honda Fit"},
                    {"year", 2006}
                }},
                {"user3@slicingdice.com", new Dictionary<string, dynamic>{
                    {"car-model", "Toyota Corolla"},
                    {"year", 2010},
                    {"test-drives", new List<Dictionary<string, dynamic>>{
                        new Dictionary<string, dynamic>{
                            {"value", "NY"},
                            {"date", "2016-08-17T13:23:47+00:00"}
                        },
                        new Dictionary<string, dynamic>{
                            {"value", "NY"},
                            {"date", "2016-08-17T13:23:47+00:00"}
                        },
                        new Dictionary<string, dynamic>{
                            {"value", "CA"},
                            {"date", "2016-04-05T10:20:30Z"}
                        }
                    }}
                }},
                {"user4@slicingdice.com", new Dictionary<string, dynamic>{
                    {"car-model", "Ford Ka"},
                    {"year", 2005},
                    {"test-drives", new List<Dictionary<string, dynamic>>{
                        new Dictionary<string, dynamic>{
                            {"value", "NY"},
                            {"date", "2016-08-17T13:23:47+00:00"}
                        }
                    }}
                }}
            };

            var result = client.Index(index);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "indexed-entities": 4,
    "indexed-fields": 10,
    "took": 0.023
}
```

### Dictionary&lt;string, dynamic> ExistsEntity(ids)
Verify which entities exist in a project given a list of entity IDs. This method corresponds to a [POST request at /query/exists/entity](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-exists-entity).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);
            var ids = new List<string>{
                "user1@slicingdice.com",
                "user2@slicingdice.com",
                "user3@slicingdice.com"
            };
            var result = client.ExistsEntity(ids);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "exists": [
        "user1@slicingdice.com",
        "user2@slicingdice.com"
    ],
    "not-exists": [
        "user3@slicingdice.com"
    ],
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> CountEntityTotal()
Count the number of indexed entities. This method corresponds to a [GET request at /query/count/entity/total](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-query-count-entity-total).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var result = client.CountEntityTotal();
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "result": {
        "total": 42
    },
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> CountEntity(Dictionary&lt;string, dynamic> query)
Count the number of entities attending the given query. This method corresponds to a [POST request at /query/count/entity](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-count-entity).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"corolla-or-fit", new List<dynamic>{
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "toyota corolla"}
                        }}
                    },
                    "or",
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "honda fit"}
                        }}
                    }
                }},
                {"users-from-ny", new List<Dictionary<string, dynamic>>{
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "ford ka"}
                        }}
                    }
                }},
                {"bypass-cache", false}
            };

            var result = client.CountEntity(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "result":{
      "ford-ka":2,
      "corolla-or-fit":2
   },
   "took":0.083,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> CountEvent(Dictionary&lt;string, dynamic> query)
Count the number of occurrences for time-series events attending the given query. This method corresponds to a [POST request at /query/count/event](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-count-event).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"test-drives-in-ny", new List<Dictionary<string, dynamic>>{
                    new Dictionary<string, dynamic>{
                        {"test-drives", new Dictionary<string, dynamic>{
                            {"equals", "NY"},
                            {"between", new List<string>{
                                "2016-08-16T00:00:00Z",
                                "2016-08-18T00:00:00Z"
                            }}
                        }}
                    },
                }},
                {"test-drives-in-ca", new List<Dictionary<string, dynamic>>{
                    new Dictionary<string, dynamic>{
                        {"test-drives", new Dictionary<string, dynamic>{
                            {"equals", "CA"},
                            {"between", new List<string>{
                                "2016-04-04T00:00:00Z",
                                "2016-04-06T00:00:00Z"
                            }}
                        }}
                    },
                }},
                {"bypass-cache", false}
            };

            var result = client.CountEvent(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "result":{
      "test-drives-in-ny":3,
      "test-drives-in-ca":0
   },
   "took":0.063,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> TopValues(Dictionary&lt;string, dynamic> query)
Return the top values for entities attending the given query. This method corresponds to a [POST request at /query/top_values](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-top-values).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"car-year", new Dictionary<string, dynamic>{
                    {"year", 2}
                }},
                {"car models", new Dictionary<string, dynamic>{
                    {"car-model", 3}
                }}
            };

            var result = client.TopValues(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "result":{
      "car models":{
         "car-model":[
            {
               "quantity":2,
               "value":"ford ka"
            },
            {
               "quantity":1,
               "value":"honda fit"
            },
            {
               "quantity":1,
               "value":"toyota corolla"
            }
         ]
      },
      "car-year":{
         "year":[
            {
               "quantity":2,
               "value":"2016"
            },
            {
               "quantity":1,
               "value":"2010"
            }
         ]
      }
   },
   "took":0.034,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> Aggregation(Dictionary&lt;string, dynamic> query)
Return the aggregation of all fields in the given query. This method corresponds to a [POST request at /query/aggregation](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-aggregation).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"query", new List<Dictionary<string, dynamic>>{
                    new Dictionary<string, dynamic>{
                        {"year", 2},
                    },
                    new Dictionary<string, dynamic>{
                        {"car-model", 2},
                        {"equals", new List<string>{
                            "honda fit",
                            "toyota corolla"
                        }}
                    }
                }}
            };

            var result = client.Aggregation(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }

```

#### Output example

```json
{
   "result":{
      "year":[
         {
            "quantity":2,
            "value":"2016",
            "car-model":[
               {
                  "quantity":1,
                  "value":"honda fit"
               }
            ]
         },
         {
            "quantity":1,
            "value":"2005"
         }
      ]
   },
   "took":0.079,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> GetSavedQueries()
Get all saved queries. This method corresponds to a [GET request at /query/saved](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-query-saved).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);
            var result = client.GetSavedQueries();
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "saved-queries": [
        {
            "name": "users-in-ny-or-from-ca",
            "type": "count/entity",
            "query": [
                {
                    "state": {
                        "equals": "NY"
                    }
                },
                "or",
                {
                    "state-origin": {
                        "equals": "CA"
                    }
                }
            ],
            "cache-period": 100
        }, {
            "name": "users-from-ca",
            "type": "count/entity",
            "query": [
                {
                    "state": {
                        "equals": "NY"
                    }
                }
            ],
            "cache-period": 60
        }
    ],
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> CreateSavedQuery(Dictionary&lt;string, dynamic> query)
Create a saved query at SlicingDice. This method corresponds to a [POST request at /query/saved](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-saved).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"name", "my-saved-query"},
                {"type", "count/entity"},
                {"query", new List<dynamic>{
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "honda fit"}
                        }}
                    },
                    "or",
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "toyota corolla"}
                        }}
                    }
                }},
                {"cache-period", 100}
            };

            var result = client.CreateSavedQuery(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "took":0.053,
   "query":[
      {
         "car-model":{
            "equals":"honda fit"
         }
      },
      "or",
      {
         "car-model":{
            "equals":"toyota corolla"
         }
      }
   ],
   "name":"my-saved-query",
   "type":"count/entity",
   "cache-period":100,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> UpdateSavedQuery(string queryName, Dictionary&lt;string, dynamic> query)
Update an existing saved query at SlicingDice. This method corresponds to a [PUT request at /query/saved/QUERY_NAME](http://panel.slicingdice.com/docs/#api-details-api-endpoints-put-query-saved-query-name).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"type", "count/entity"},
                {"query", new List<dynamic>{
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "ford ka"}
                        }}
                    },
                    "or",
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "toyota corolla"}
                        }}
                    }
                }},
                {"cache-period", 100}
            };
            
            var result = client.UpdateSavedQuery("my-saved-query", query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "took":0.037,
   "query":[
      {
         "car-model":{
            "equals":"ford ka"
         }
      },
      "or",
      {
         "car-model":{
            "equals":"toyota corolla"
         }
      }
   ],
   "type":"count/entity",
   "cache-period":100,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> GetSavedQuery(string queryName)
Executed a saved query at SlicingDice. This method corresponds to a [GET request at /query/saved/QUERY_NAME](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-query-saved-query-name).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var result = client.GetSavedQuery("my-saved-query");
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "result":{
      "query":2
   },
   "took":0.035,
   "query":[
      {
         "car-model":{
            "equals":"honda fit"
         }
      },
      "or",
      {
         "car-model":{
            "equals":"toyota corolla"
         }
      }
   ],
   "type":"count/entity",
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> DeleteSavedQuery(string queryName)
Delete a saved query at SlicingDice. This method corresponds to a [DELETE request at /query/saved/QUERY_NAME](http://panel.slicingdice.com/docs/#api-details-api-endpoints-delete-query-saved-query-name).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY", usesTestEndpoint: false);
            var result = client.DeleteSavedQuery("my-saved-query");
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "took":0.029,
   "query":[
      {
         "car-model":{
            "equals":"honda fit"
         }
      },
      "or",
      {
         "car-model":{
            "equals":"toyota corolla"
         }
      }
   ],
   "type":"count/entity",
   "cache-period":100,
   "status":"success",
   "deleted-query":"my-saved-query"
}
```

### Dictionary&lt;string, dynamic> Result(Dictionary&lt;string, dynamic> query)
Retrieve indexed values for entities attending the given query. This method corresponds to a [POST request at /data_extraction/result](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-data-extraction-result).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"query", new List<dynamic>{
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "ford ka"}
                        }}
                    },
                    "or",
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "toyota corolla"}
                        }}
                    },
                }},
                {"fields", new List<string>{"car-model", "year"}},
                {"limit", 2}
            };

            var result = client.Result(query);
            
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "took":0.113,
   "next-page":null,
   "data":{
      "customer5@mycustomer.com":{
         "year":"2005",
         "car-model":"ford ka"
      },
      "user1@slicingdice.com":{
         "year":"2016",
         "car-model":"ford ka"
      }
   },
   "page":1,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> Score(Dictionary&lt;string, dynamic> query)
Retrieve indexed values as well as their relevance for entities attending the given query. This method corresponds to a [POST request at /data_extraction/score](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-data-extraction-score).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;
using Newtonsoft.Json;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY", usesTestEndpoint: false);
            var query = new Dictionary<string, dynamic>()
            {
                {"query", new List<dynamic>{
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "ford ka"}
                        }}
                    },
                    "or",
                    new Dictionary<string, dynamic>{
                        {"car-model", new Dictionary<string, dynamic>{
                            {"equals", "toyota corolla"}
                        }}
                    },
                }},
                {"fields", new List<string>{"car-model", "year"}},
                {"limit", 2}
            };

            var result = client.Score(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "took":0.063,
   "next-page":null,
   "data":{
      "user3@slicingdice.com":{
         "score":1,
         "year":"2010",
         "car-model":"toyota corolla"
      },
      "user2@slicingdice.com":{
         "score":1,
         "year":"2016",
         "car-model":"honda fit"
      }
   },
   "page":1,
   "status":"success"
}
```
