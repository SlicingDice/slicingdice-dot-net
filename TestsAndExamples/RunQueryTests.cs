using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Test
{
    public class RunQueryTests
    {
        public static void Main(string[] args)
        {
            bool _canceled = false;
            // The query types to test
            List<string> queryTypes = new List<string>(){
                "count_entity",
                "count_event",
                "top_values",
                "aggregation",
                "result",
                "score"
            };

            // Testing class with demo API key
            // To get a new Demo API key visit: http://panel.slicingdice.com/docs/#api-details-api-connection-api-keys-demo-key
            SlicingDiceTester sdTester = new SlicingDiceTester(
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfX3NhbHQiOiJkZW1vODRtIiwicGVybWlzc2lvbl9sZXZlbCI6MywicHJvamVjdF9pZCI6MjQ1LCJjbGllbnRfaWQiOjEwfQ.iJ2GH_OrgunwK8-5iEov7IZbAHObLVNnNzPTcrrpDtY",
                verbose: false);

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                showResults(sdTester);
            };

            foreach(string queryType in queryTypes){
                sdTester.RunTests(queryType);
            }

            showResults(sdTester);
        }

        // Show test results
        private static void showResults(SlicingDiceTester sdTester)
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Results:");
            System.Console.WriteLine(string.Format("  Successes: {0}", sdTester.NumSuccesses));
            System.Console.WriteLine(string.Format("  Fails: {0}", sdTester.NumFails));

            foreach (dynamic failedTest in sdTester.FailedTests)
            {
                System.Console.WriteLine("    - {0}", (string)failedTest);
            }

            System.Console.WriteLine();

            if (sdTester.NumFails > 0)
            {
                bool isSingular = sdTester.NumFails == 1;
                string testOrTests = string.Empty;

                if (isSingular)
                {
                    testOrTests = "test has";
                }
                else
                {
                    testOrTests = "test have";
                }

                System.Console.WriteLine(string.Format("FAIL: {0} {1} failed", sdTester.NumFails, testOrTests));
            }
            else
            {
                System.Console.WriteLine("SUCCESS: All tests passed");
            }
            Environment.Exit(Environment.ExitCode);
        }
    }
}
