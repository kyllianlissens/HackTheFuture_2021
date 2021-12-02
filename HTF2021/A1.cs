using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{
    internal static class A1
    {

        private static string testUrl = "api/path/1/easy/Sample";
        //private static string productionUrl = "api/path/1/easy/Puzzle";

        private static readonly HTTPInstance clientInstance = new HTTPInstance();

        internal static void LocalExecution()
        {
            Console.WriteLine("-Local Execution: \n");
            var randomList = Utilities.randomIntegerList(100, 1, 100);
            Console.WriteLine($"Random generated list: {string.Join("; ", randomList)} \n");
            Console.WriteLine($"digitSum of list: {digitSum(randomList.Sum())} \n");
        }

        internal static async void TestExecution()
        {
            Console.WriteLine("-Test Execution: \n");
            var testData = await clientInstance.client.GetFromJsonAsync<List<int>>(testUrl);
            Console.WriteLine($"Test endpoint data: {string.Join("; ", testData)}");
            var testSolution = digitSum(testData.Sum());
            Console.WriteLine($"digitSum of test data: {testSolution}");
            var testPostResponse = await clientInstance.client.PostAsJsonAsync<int>(testUrl, testSolution);
            var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Test endpoint response: {testPostResponseValue}");

        }

        internal static async void ProductionExecution()
        {
            Console.WriteLine("-Production Execution: \n");
        }

        internal static int digitSum(int n)
        {
            if (n == 0) return 0;
            return (n % 9 == 0) ? 9 : (n % 9);
        }
    }
}
