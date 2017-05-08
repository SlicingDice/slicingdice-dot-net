using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils
{
    public static class URLResources
    {
        public static string Project { get { return "/project/"; } }
        public static string Field { get { return "/field/"; } }
        public static string Insert { get { return "/insert/"; } }
        public static string QueryCountEntity { get { return "/query/count/entity/"; } }
        public static string QueryCountEvent { get { return "/query/count/event/"; } }
        public static string QueryCountEntityTotal { get { return "/query/count/entity/total/"; } }
        public static string QueryAggregation { get { return "/query/aggregation/"; } }
        public static string QueryTopValues { get { return "/query/top_values/"; } }
        public static string QueryExistsEntity { get { return "/query/exists/entity/"; } }
        public static string QuerySaved { get { return "/query/saved/"; } }
        public static string QueryDataExtractionResult { get { return "/data_extraction/result/"; } }
        public static string QueryDataExtractionScore { get { return "/data_extraction/score/"; } }
    }
}
