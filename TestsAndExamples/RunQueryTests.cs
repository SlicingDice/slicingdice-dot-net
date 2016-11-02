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
            List<string> queryTypes = new List<string>(){
                "count_entity",
                "count_event",
                "top_values",
                "aggregation"
            };

            SlicingDiceTester sdTester = new SlicingDiceTester(
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfX3NhbHQiOiJkZW1vMW0iLCJwZXJtaXNzaW9uX2xldmVsIjozLCJwcm9qZWN0X2lkIjoyMCwiY2xpZW50X2lkIjoxMH0.xRBHeDxTzYAgFyuU94SWFbjITeoxgyRCQGdIee8qrLA",
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
