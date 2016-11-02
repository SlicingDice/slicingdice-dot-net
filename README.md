# SlicingDice Official .NET/C# Client (v1.0)

Official .NET/C# client for [SlicingDice](http://www.slicingdice.com/), Data Warehouse and Analytics Database as a Service.

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

namespace Slicer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the client
            var client = new SlicingDice(masterKey: "API_KEY");

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
            client.CreateField(fieldData);

            // Querying data
            var queryData = new Dictionary<string, dynamic>()
            {
                {"users-between-20-and-40",
                    new List<Dictionary<string, dynamic>()
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
            System.Console.WriteLine(client.CountEntity(queryData));
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

### Dictionary&lt;string, dynamic> GetProjects()
Get all created projects, both active and inactive ones. This method corresponds to a [GET request at /project](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-project).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            System.Console.WriteLine(client.GetProjects()["active"]);
            System.Console.ReadLine();
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

### Dictionary&lt;string, dynamic> GetFields(bool test = false)
Get all created fields, both active and inactive ones. This method corresponds to a [GET request at /field](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-field).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            System.Console.WriteLine(client.GetFields()["active"]);
            System.Console.ReadLine();
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

### Dictionary&lt;string, dynamic> CreateField(Dictionary&lt;string, dynamic> query, bool test = false)
Create a new field. This method corresponds to a [POST request at /field](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-field).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            var field = new Dictionary()
            {
                {"name", "Year"},
                {"api-name", "year"},
                {"type", "integer"},
                {"description", "Year of manufacturing"},
                {"storage", "lastest-value"}
            };
            System.Console.WriteLine(client.CreateField(field)["status"]);
            System.Console.ReadLine();
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

### Dictionary&lt;string, dynamic> Index(Dictionary&lt;string, dynamic> index, bool autoCreateFields = false, bool test = false)
Index data to existing entities or create new entities, if necessary. This method corresponds to a [POST request at /index](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-index).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_WRITE_API_KEY");
            var index = new Dictionary()
            {
                {"user1@slicingdice.com", new Dictionary{
                    {"car-model", "Ford Ka"},
                    {"year", 2006}
                }},
                {"user2@slicingdice.com", new Dictionary{
                    {"car-model", "Honda Fit"},
                    {"year", 2006}
                }},
                {"user3@slicingdice.com", new Dictionary{
                    {"car-model", "Toyota Corolla"},
                    {"year", 2010},
                    {"test-drives", new List>{
                        new Dictionary{
                            {"value", "NY"},
                            {"date", "2016-08-17T13:23:47+00:00"}
                        },
                        new Dictionary{
                            {"value", "NY"},
                            {"date", "2016-08-17T13:23:47+00:00"}
                        },
                        new Dictionary{
                            {"value", "CA"},
                            {"date", "2016-04-05T10:20:30Z"}
                        }
                    }}
                }},
                {"user4@slicingdice.com", new Dictionary{
                    {"car-model", "Ford Ka"},
                    {"year", 2005},
                    {"test-drives", new List>{
                        new Dictionary{
                            {"value", "NY"},
                            {"date", "2016-08-17T13:23:47+00:00"}
                        }
                    }}
                }}
            };

            System.Console.WriteLine(client.Index(index)["status"]);
            System.Console.ReadLine();
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

### Dictionary&lt;string, dynamic> ExistsEntity(ids, bool test = false)
Verify which entities exist in a project given a list of entity IDs. This method corresponds to a [POST request at /query/exists/entity](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-exists-entity).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            var ids = new List{
                "user1@slicingdice.com",
                "user2@slicingdice.com",
                "user3@slicingdice.com"
            };
            System.Console.WriteLine(client.ExistsEntity(ids)["status"]);
            System.Console.ReadLine();
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

### Dictionary&lt;string, dynamic> CountEntityTotal(bool test = false)
Count the number of indexed entities. This method corresponds to a [GET request at /query/count/entity/total](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-query-count-entity-total).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            System.Console.WriteLine(client.CountEntityTotal()["status"]);
            System.Console.ReadLine();
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

### Dictionary&lt;string, dynamic> CountEntity(Dictionary&lt;string, dynamic> query, bool test = false)
Count the number of entities attending the given query. This method corresponds to a [POST request at /query/count/entity](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-count-entity).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary()
            {
                {"users-from-ny-or-ca", new List{
                    new Dictionary{
                        {"state", new Dictionary{
                            {"equals", "NY"}
                        }}
                    },
                    "or",
                    new Dictionary{
                        {"state-origin", new Dictionary{
                            {"equals", "CA"}
                        }}
                    }
                }},
                {"users-from-ny", new List{
                    new Dictionary{
                        {"state", new Dictionary{
                            {"equals", "NY"}
                        }}
                    }
                }},
                {"bypass-cache", false}
            };
            System.Console.WriteLine(client.CountEntity(query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "result": {
        "users-from-ny-or-ca": 175,
        "users-from-ny": 296
    },
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> CountEvent(Dictionary&lt;string, dynamic> query, bool test = false)
Count the number of occurrences for time-series events attending the given query. This method corresponds to a [POST request at /query/count/event](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-count-event).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary()
            {
                {"users-from-ny-in-jan", new List{
                    new Dictionary{
                        {"test-drives", new Dictionary{
                            {"equals", "NY"},
                            {"between", new List{
                                "2016-01-01T00:00:00Z",
                                "2016-01-31T00:00:00Z"
                            }},
                            {"minfreq", 2},
                        }}
                    },
                }},
                {"users-from-ny-in-feb", new List{
                    new Dictionary{
                        {"test-drives", new Dictionary{
                            {"equals", "NY"},
                            {"between", new List{
                                "2016-02-01T00:00:00Z",
                                "2016-02-28T00:00:00Z"
                            }},
                            {"minfreq", 2},
                        }}
                    },
                }},
                {"bypass-cache", false}
            };
            System.Console.WriteLine(client.CountEvent(query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "result": {
        "users-from-ny-in-jan": 175,
        "users-from-ny-in-feb": 296
    },
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> TopValues(Dictionary&lt;string, dynamic> query, bool test = false)
Return the top values for entities attending the given query. This method corresponds to a [POST request at /query/top_values](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-top-values).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary()
            {
                {"user-gender", new Dictionary{
                    {"gender", 2}
                }},
                {"operating-systems", new Dictionary{
                    {"os", 3}
                }},
                {"linux-operating-systems", new Dictionary{
                    {"os", 3},
                    {"contains", new List{"linux", "unix"}}
                }}
            };
            System.Console.WriteLine(client.TopValues(query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "result": {
        "user-gender": {
            "gender": [
                {
                    "quantity": 6.0,
                    "value": "male"
                }, {
                    "quantity": 4.0,
                    "value": "female"
                }
            ]
        },
        "operating-systems": {
            "os": [
                {
                    "quantity": 55.0,
                    "value": "windows"
                }, {
                    "quantity": 25.0,
                    "value": "macos"
                }, {
                    "quantity": 12.0,
                    "value": "linux"
                }
            ]
        },
        "linux-operating-systems": {
            "os": [
                {
                    "quantity": 12.0,
                    "value": "linux"
                }, {
                    "quantity": 3.0,
                    "value": "debian-linux"
                }, {
                    "quantity": 2.0,
                    "value": "unix"
                }
            ]
        }
    },
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> Aggregation(Dictionary&lt;string, dynamic> query, bool test = false)
Return the aggregation of all fields in the given query. This method corresponds to a [POST request at /query/aggregation](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-aggregation).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary()
            {
                {"query", new List{
                    new Dictionary{
                        {"gender", 2},
                    },
                    new Dictionary{
                        {"os", 2},
                        {"equals", new List{
                            "linux",
                            "macos",
                            "windows"
                        }}
                    },
                    new Dictionary{
                        {"browser", 2}
                    }
                }}
            };
            System.Console.WriteLine(client.Aggregation(query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "result": {
        "gender": [
            {
                "quantity": 6,
                "value": "male",
                "os": [
                    {
                        "quantity": 5,
                        "value": "windows",
                        "browser": [
                            {
                                "quantity": 3,
                                "value": "safari"
                            }, {
                                "quantity": 2,
                                "value": "internet explorer"
                            }
                        ]
                    }, {
                        "quantity": 1,
                        "value": "linux",
                        "browser": [
                            {
                                "quantity": 1,
                                "value": "chrome"
                            }
                        ]
                    }
                ]
            }, {
                "quantity": 4,
                "value": "female",
                "os": [
                    {
                        "quantity": 3,
                        "value": "macos",
                        "browser": [
                            {
                                "quantity": 3,
                                "value": "chrome"
                            }
                        ]
                    }, {
                        "quantity": 1,
                        "value": "linux",
                        "browser": [
                            {
                                "quantity": 1,
                                "value": "chrome"
                            }
                        ]
                    }
                ]
            }
        ]
    },
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> GetSavedQueries(bool test = false)
Get all saved queries. This method corresponds to a [GET request at /query/saved](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-query-saved).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            System.Console.WriteLine(client.GetSavedQueries()["status"]);
            System.Console.ReadLine();
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

### Dictionary&lt;string, dynamic> CreateSavedQuery(Dictionary&lt;string, dynamic> query, bool test = false)
Create a saved query at SlicingDice. This method corresponds to a [POST request at /query/saved](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-saved).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            var query = new Dictionary()
            {
                {"name", "my-saved-query"},
                {"type", "count/entity"},
                {"query", new List{
                    new Dictionary{
                        {"state", new Dictionary{
                            {"equals", "NY"}
                        }}
                    },
                    "or",
                    new Dictionary{
                        {"state-origin", new Dictionary{
                            {"equals", "CA"}
                        }}
                    }
                }},
                {"cache-period", 100}
            };
            System.Console.WriteLine(client.CreateSavedQuery(query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "name": "my-saved-query",
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
    "cache-period": 100,
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> UpdateSavedQuery(string queryName, Dictionary&lt;string, dynamic> query, bool test = false)
Update an existing saved query at SlicingDice. This method corresponds to a [PUT request at /query/saved/QUERY_NAME](http://panel.slicingdice.com/docs/#api-details-api-endpoints-put-query-saved-query-name).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            var query = new Dictionary()
            {
                {"type", "count/entity"},
                {"query", new List{
                    new Dictionary{
                        {"state", new Dictionary{
                            {"equals", "NY"}
                        }}
                    },
                    "or",
                    new Dictionary{
                        {"state-origin", new Dictionary{
                            {"equals", "CA"}
                        }}
                    }
                }},
                {"cache-period", 100}
            };
            System.Console.WriteLine(client.UpdateSavedQuery("my-saved-query", query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "name": "my-saved-query",
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
    "cache-period": 100,
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> GetSavedQuery(string queryName, bool test = false)
Executed a saved query at SlicingDice. This method corresponds to a [GET request at /query/saved/QUERY_NAME](http://panel.slicingdice.com/docs/#api-details-api-endpoints-get-query-saved-query-name).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            System.Console.WriteLine(client.GetSavedQuery("my-saved-query")["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
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
    "result": {
        "my-saved-query": 175
    },
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> DeleteSavedQuery(string queryName, bool test = false)
Delete a saved query at SlicingDice. This method corresponds to a [DELETE request at /query/saved/QUERY_NAME](http://panel.slicingdice.com/docs/#api-details-api-endpoints-delete-query-saved-query-name).

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_API_KEY");
            System.Console.WriteLine(client.DeleteSavedQuery("my-saved-query")["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "deleted-query": "my-saved-query",
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
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> Result(Dictionary&lt;string, dynamic> query, bool test = false)
<<<<<<< HEAD
Retrieve indexed values for entities attending the given query. This method corresponds to a [POST request at /query/data_extraction/result](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-data-extraction-result).
=======
Retrieve indexed values for entities attending the given query. This method corresponds to a [POST request at /data_extraction/result](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-data-extraction-result).
>>>>>>> 996bee7b0fea03f8c9ad5f36fa854a726f1d08f1

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary()
            {
                {"query", new List{
                    new Dictionary{
                        {"users-from-ny", new Dictionary{
                            {"equals", "NY"}
                        }}
                    },
                    "or",
                    new Dictionary{
                        {"users-from-ca", new Dictionary{
                            {"equals", "CA"}
                        }}
                    },
                }},
                {"fields", new List{"name", "year"}},
                {"limit", 2}
            };
            System.Console.WriteLine(client.Result(query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "data": {
        "user1@slicingdice.com": {
            "name": "John",
            "year": 2016
        },
        "user2@slicingdice.com": {
            "name": "Mary",
            "year": 2005
        }
    },
    "took": 0.103
}
```

### Dictionary&lt;string, dynamic> Score(Dictionary&lt;string, dynamic> query, bool test = false)
<<<<<<< HEAD
Retrieve indexed values as well as their relevance for entities attending the given query. This method corresponds to a [POST request at /query/data_extraction/score](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-query-data-extraction-score).
=======
Retrieve indexed values as well as their relevance for entities attending the given query. This method corresponds to a [POST request at /data_extraction/score](http://panel.slicingdice.com/docs/#api-details-api-endpoints-post-data-extraction-score).
>>>>>>> 996bee7b0fea03f8c9ad5f36fa854a726f1d08f1

#### Request example

```csharp
using System.Collections.Generic;
using Slicer;

namespace SlicerTester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SlicingDice(masterKey: "MASTER_OR_READ_API_KEY");
            var query = new Dictionary()
            {
                {"query", new List{
                    new Dictionary{
                        {"users-from-ny", new Dictionary{
                            {"equals", "NY"}
                        }}
                    },
                    "or",
                    new Dictionary{
                        {"users-from-ca", new Dictionary{
                            {"equals", "CA"}
                        }}
                    },
                }},
                {"fields", new List{"name", "year"}},
                {"limit", 2}
            };
            System.Console.WriteLine(client.Score(query)["status"]);
            System.Console.ReadLine();
        }
    }
}
```

#### Output example

```json
{
    "status": "success",
    "data": {
        "user1@slicingdice.com": {
            "name": "John",
            "year": 2016,
            "score": 2
        },
        "user2@slicingdice.com": {
            "name": "Mary",
            "year": 2005,
            "score": 1
        }
    },
    "took": 0.103
}
```
