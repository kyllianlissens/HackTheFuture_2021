using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTF2021
{
    internal static class A1
    {
        private static readonly string testUrl = "api/path/1/easy/Sample";
        private static readonly string productionUrl = "api/path/1/easy/Puzzle";

        private static readonly HTTPInstance clientInstance = new();

        internal static void LocalExecution()
        {
            Console.WriteLine("-Local Execution: \n");
            var randomList = Utilities.randomIntegerList(100, 1, 100);
            Console.WriteLine($"Random generated list: {string.Join("; ", randomList)} \n");
            Console.WriteLine($"digitSum of list: {digitSum(randomList.Sum())} \n");
        }

        internal static async Task TestExecution()
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

        internal static async Task ProductionExecution()
        {
            Console.WriteLine("-Production Execution: \n");
            var productionData = await clientInstance.client.GetFromJsonAsync<List<int>>(productionUrl);
            Console.WriteLine($"Test endpoint data: {string.Join("; ", productionData)}");
            var productionSolution = digitSum(productionData.Sum());
            Console.WriteLine($"digitSum of test data {productionData.Sum()}: {productionSolution}");
            var testPostResponse = await clientInstance.client.PostAsJsonAsync<int>(productionUrl, productionSolution);
            var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Test endpoint response: {testPostResponseValue}");
        }

        internal static int digitSum(int n)
        {
            if (n == 0) return 0;
            return n % 9 == 0 ? 9 : n % 9;
        }
    }
}