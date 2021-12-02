using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{
    internal static class A2
    {

        private static string testUrl = "api/path/1/medium/Sample";
        private static string productionUrl = "api/path/1/medium/Puzzle";

        private static readonly HTTPInstance clientInstance = new HTTPInstance();

        internal static void LocalExecution()
        {
            Console.WriteLine("-Local Execution: \n");
            Console.WriteLine($"Simple calculation algorithm: {String.Join("; ", Utilities.simpleElevatorAlgorithm(9))} \n");
            Console.WriteLine($"Future calculation algorithm: {String.Join("; ", Utilities.futureElevatorAlgorithm(9))} \n");

        }

        internal static async void TestExecution()
        {
            Console.WriteLine("-Test Execution: \n");
            var testData = await clientInstance.client.GetFromJsonAsync<List<string>>(testUrl);
            Console.WriteLine($"Test endpoint data: {string.Join("; ", testData)}");

            //TODO: Solution & process


            //var testPostResponse = await clientInstance.client.PostAsJsonAsync<int>(testUrl, testSolution);
            //var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
            //Console.WriteLine($"Test endpoint response: {testPostResponseValue}");
        }

        internal static void ProductionExecution()
        {
            Console.WriteLine("-Production Execution: \n");
        }
    }
}
