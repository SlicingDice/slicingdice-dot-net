# SlicingDice Official .NET/C# Client (v2.0.2)

Official .NET/C# client for [SlicingDice - Data Warehouse and Analytics Database as a Service](http://www.slicingdice.com/).

[SlicingDice](http://www.slicingdice.com/) is a serverless, SQL & API-based, easy-to-use and really cost-effective alternative to Amazon Redshift and Google BigQuery.

### Build Status: [![CircleCI](https://circleci.com/gh/SlicingDice/slicingdice-dot-net/tree/master.svg?style=svg)](https://circleci.com/gh/SlicingDice/slicingdice-dot-net/tree/master)

### Code Quality: [![Codacy Badge](https://api.codacy.com/project/badge/Grade/6b41f3f06cc34af7bbc255b4d6b5740e)](https://www.codacy.com/app/SimbioseVentures/slicingdice-dot-net?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=SlicingDice/slicingdice-dot-net&amp;utm_campaign=Badge_Grade)

## Documentation

If you are new to SlicingDice, check our [quickstart guide](https://docs.slicingdice.com/docs/quickstart-guide) and learn to use it in 15 minutes.

Please refer to the [SlicingDice official documentation](https://docs.slicingdice.com/) for more information on [how to create a database](https://docs.slicingdice.com/docs/how-to-create-a-database), [how to insert data](https://docs.slicingdice.com/docs/how-to-insert-data), [how to make queries](https://docs.slicingdice.com/docs/how-to-make-queries), [how to create columns](https://docs.slicingdice.com/docs/how-to-create-columns), [SlicingDice restrictions](https://docs.slicingdice.com/docs/current-restrictions) and [API details](https://docs.slicingdice.com/docs/api-details).

## Tests and Examples

Whether you want to test the client installation or simply check more examples on how the client works, take a look at [tests and examples directory](TestsAndExamples/).

## Installing

In order to install the .NET/C# client, you only need to install our package `SlicingDice` through the Package Manager from Visual Studio.

```
Install-Package SlicingDice
```

You can also install our client through the following `nuget` command.

```
nuget install SlicingDice
```

## Usage

`SlicingDice` encapsulates logic for sending requests to the API. Its methods are thin layers around the [API endpoints](https://docs.slicingdice.com/docs/api-details), so their parameters and return values are JSON-like `Dictionary<string, dynamic>` objects with the same syntax as the [API endpoints](https://docs.slicingdice.com/docs/api-details)

### Example:

The following code snippet is an example of how to add and query data
using the SlicingDice C\# client. We entry data informing
`user1@slicingdice.com` has age 22 and then query the database for
the number of users with age between 20 and 40 years old.
If this is the first record ever entered into the system,
 the answer should be 1.

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
            var client = new SlicingDice(masterKey: "API_KEY");

            // Creating a column
            var columnData = new Dictionary<string, dynamic>()
            {
                {"name", "Age"},
                {"api-name", "age"},
                {"description", "User age"},
                {"type", "integer"},
                {"storage", "latest-value"}
            };
            client.CreateColumn(columnData);

            // Inserting data
            var insert = new Dictionary<string, dynamic>()
            {
                {"user1@slicingdice.com", new Dictionary<string, int>(){
                    {"age", 2}
               }}
            };
            client.Insert(insert);

            // Querying data
            var queryData = new Dictionary<string, dynamic>()
                        {
                            {"query-name", "users-between-20-and-40"},
                            {"query",
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

* `key (string)` - [API key](https://docs.slicingdice.com/docs/api-keys) to authenticate requests with the SlicingDice API.
* `timeout (int)` - Amount of time, in seconds, to wait for results for each request.

### Constructors

`SlicingDice(string masterKey=null, string customKey=null, string writeKey=null, string readKey=null, int timeout=60)`
* `masterKey (string)` - [API key](https://docs.slicingdice.com/docs/api-keys) to authenticate requests with the SlicingDice API.
* `customKey (string)` - [API key](https://docs.slicingdice.com/docs/api-keys) to authenticate requests with the SlicingDice API.
* `writeKey (string)` - [API key](https://docs.slicingdice.com/docs/api-keys) to authenticate requests with the SlicingDice API.
* `readKey (string)` - [API key](https://docs.slicingdice.com/docs/api-keys) to authenticate requests with the SlicingDice API.
* `timeout (int)` - Amount of time, in seconds, to wait for results for each request.

### Dictionary&lt;string, dynamic> GetDatabase()
Get information about current database. This method corresponds to a `GET` request at `/database`.

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");

            var result = client.GetDatabase();
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "name": "Database 1",
    "description": "My first database",
    "dimensions": [
    	"default",
        "users"
    ],
    "updated-at": "2017-05-19T14:27:47.417415",
    "created-at": "2017-05-12T02:23:34.231418"
}
```

### Dictionary&lt;string, dynamic> GetColumns()
Get all created columns, both active and inactive ones. This method corresponds to a [GET request at /column](https://docs.slicingdice.com/docs/how-to-list-edit-or-delete-columns).

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");

            var result = client.GetColumns();

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

### Dictionary&lt;string, dynamic> CreateColumn(Dictionary&lt;string, dynamic> query)
Create a new column. This method corresponds to a [POST request at /column](https://docs.slicingdice.com/docs/how-to-create-columns#section-creating-columns-using-column-endpoint).

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            var column = new Dictionary<string, dynamic>()
            {
                {"name", "Year"},
                {"api-name", "year"},
                {"type", "integer"},
                {"description", "Year of manufacturing"},
                {"storage", "latest-value"}
            };
            var result = client.CreateColumn(column);
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

### Dictionary&lt;string, dynamic> Insert(Dictionary&lt;string, dynamic> data)
Insert data to existing entities or create new entities, if necessary. This method corresponds to a [POST request at /insert](https://docs.slicingdice.com/docs/how-to-insert-data).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_WRITE_API_KEY");
            var insert = new Dictionary<string, dynamic>()
            {
                {"auto-create", new List<string>(){
                    "dimension", "column"
                }},
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

            var result = client.Insert(insert);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "inserted-entities": 4,
    "inserted-columns": 10,
    "took": 0.023
}
```

### Dictionary&lt;string, dynamic> ExistsEntity(ids, dimension = null)
Verify which entities exist in a dimension (uses `default` dimension if not provided) given a list of entity IDs. This method corresponds to a [POST request at /query/exists/entity](https://docs.slicingdice.com/docs/exists).

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
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
Count the number of inserted entities in the whole database. This method corresponds to a [POST request at /query/count/entity/total](https://docs.slicingdice.com/docs/total).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            
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

### Dictionary&lt;string, dynamic> CountEntityTotal(List&lt;string> dimensions)
Count the total number of inserted entities in the given dimensions. This method corresponds to a [POST request at /query/count/entity/total](https://docs.slicingdice.com/docs/total#section-counting-specific-tables).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var dimensions = new List<string>()
            {
                "default"
            };
            var result = client.CountEntityTotal(dimensions);
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

### Dictionary&lt;string, dynamic> CountEntity(List&lt;dynamic> query)
Count the number of entities matching the given query. This method corresponds to a [POST request at /query/count/entity](https://docs.slicingdice.com/docs/count-entities).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new List<dynamic>{
                new Dictionary<string, dynamic>()
                    {
                        {"query-name", "corolla-or-fit"},
                        {"query", new List<dynamic>{
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
                        {"bypass-cache", false}
                    },
                new Dictionary<string, dynamic>()
                    {
                        {"query-name", "users-from-ny"},
                        {"query", new List<Dictionary<string, dynamic>>{
                            new Dictionary<string, dynamic>{
                                {"car-model", new Dictionary<string, dynamic>{
                                    {"equals", "ford ka"}
                                }}
                            }
                        }},
                        {"bypass-cache", false}
                    }
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

### Dictionary&lt;string, dynamic> CountEntity(Dictionary&lt;string, dynamic> query)
Count the number of entities matching the given query. This method corresponds to a [POST request at /query/count/entity](https://docs.slicingdice.com/docs/count-entities).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary<string, dynamic>()
            {
                {"query-name", "corolla-or-fit"},
                {"query", new List<dynamic>{
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
      "corolla-or-fit":2
   },
   "took":0.083,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> CountEvent(List&lt;dynamic> query)
Count the number of occurrences for time-series events matching the given query. This method corresponds to a [POST request at /query/count/event](https://docs.slicingdice.com/docs/count-events).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new List<dynamic>{
                new Dictionary<string, dynamic>()
                    {
                        {"query-name", "test-drives-in-ny"},
                        {"query", new List<Dictionary<string, dynamic>>{
                            new Dictionary<string, dynamic>{
                                {"test-drives", new Dictionary<string, dynamic>{
                                    {"equals", "NY"},
                                    {"between", new List<string>{
                                        "2016-08-16T00:00:00Z",
                                        "2016-08-18T00:00:00Z"
                                    }}
                                }}
                            }
                        }},
                        {"bypass-cache", false}
                    },
                new Dictionary<string, dynamic>()
                    {
                        {"query-name", "test-drives-in-ca"},
                        {"query", new List<Dictionary<string, dynamic>>{
                            new Dictionary<string, dynamic>{
                                {"test-drives", new Dictionary<string, dynamic>{
                                    {"equals", "CA"},
                                    {"between", new List<string>{
                                        "2016-04-04T00:00:00Z",
                                        "2016-04-06T00:00:00Z"
                                    }}
                                }}
                            }
                        }},
                        {"bypass-cache", false}
                    }
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

### Dictionary&lt;string, dynamic> CountEvent(Dictionary&lt;string, dynamic> query)
Count the number of occurrences for time-series events matching the given query. This method corresponds to a [POST request at /query/count/event](https://docs.slicingdice.com/docs/count-events).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary<string, dynamic>()
            {
                    {"query-name", "test-drives-in-ny"},
                    {"query", new List<Dictionary<string, dynamic>>{
                        new Dictionary<string, dynamic>{
                            {"test-drives", new Dictionary<string, dynamic>{
                                {"equals", "NY"},
                                {"between", new List<string>{
                                    "2016-08-16T00:00:00Z",
                                    "2016-08-18T00:00:00Z"
                                }}
                            }}
                        }
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
      "test-drives-in-ny":3
   },
   "took":0.063,
   "status":"success"
}
```

### Dictionary&lt;string, dynamic> TopValues(Dictionary&lt;string, dynamic> query)
Return the top values for entities matching the given query. This method corresponds to a [POST request at /query/top_values](https://docs.slicingdice.com/docs/top-values).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
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
Return the aggregation of all columns in the given query. This method corresponds to a [POST request at /query/aggregation](https://docs.slicingdice.com/docs/aggregations).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
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
Get all saved queries. This method corresponds to a [GET request at /query/saved](https://docs.slicingdice.com/docs/saved-queries).

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
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
Create a saved query at SlicingDice. This method corresponds to a [POST request at /query/saved](https://docs.slicingdice.com/docs/saved-queries).

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
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
Update an existing saved query at SlicingDice. This method corresponds to a [PUT request at /query/saved/QUERY_NAME](https://docs.slicingdice.com/docs/saved-queries).

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
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
Executed a saved query at SlicingDice. This method corresponds to a [GET request at /query/saved/QUERY_NAME](https://docs.slicingdice.com/docs/saved-queries).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
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
Delete a saved query at SlicingDice. This method corresponds to a [DELETE request at /query/saved/QUERY_NAME](https://docs.slicingdice.com/docs/saved-queries).

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
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
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
Retrieve inserted values for entities matching the given query. This method corresponds to a [POST request at /data_extraction/result](https://docs.slicingdice.com/docs/result-extraction).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
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
                {"columns", new List<string>{"car-model", "year"}},
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
Retrieve inserted values as well as their relevance for entities matching the given query. This method corresponds to a [POST request at /data_extraction/score](https://docs.slicingdice.com/docs/score-extraction).

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
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
                {"columns", new List<string>{"car-model", "year"}},
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

### Dictionary&lt;string, dynamic> Sql(string query)
Retrieve inserted values using a SQL syntax. This method corresponds to a POST request at /query/sql.

#### Query statement

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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = "SELECT COUNT(*) FROM default WHERE age BETWEEN 0 AND 49";

            var result = client.Sql(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Insert statement
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
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = "SINSERT INTO default([entity-id], name, age) VALUES(1, 'john', 10)";

            var result = client.Sql(query);
            System.Console.WriteLine(JsonConvert.SerializeObject(result).ToString());
        }
    }
}
```

#### Output example

```json
{
   "took":0.063,
   "result":[
       {"COUNT": 3}
   ],
   "count":1,
   "status":"success"
}
```

## License

[MIT](https://opensource.org/licenses/MIT)
