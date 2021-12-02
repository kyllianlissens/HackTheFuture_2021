using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{
    internal static class B2
    {

        private static string testUrl = "api/path/2/medium/Sample";
        private static string productionUrl = "api/path/2/medium/Puzzle";

        private static readonly HTTPInstance clientInstance = new HTTPInstance();
        internal static void LocalExecution()
        {
            Console.WriteLine("-Local Execution: \n");
          

        }

        internal static void TestExecution()
        {
            Console.WriteLine("-Test Execution: \n");
        }

        internal static void ProductionExecution()
        {
            Console.WriteLine("-Production Execution: \n");
        }
    }
}
