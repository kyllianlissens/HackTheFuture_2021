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
        //private static string productionUrl = "api/path/1/medium/Puzzle";

        private static readonly HTTPInstance clientInstance = new HTTPInstance();

        internal static void LocalExecution()
        {
            Console.WriteLine("-Local Execution: \n");
            Console.WriteLine($"Simple calculation algorithm: {String.Join("; ", simpleElevatorAlgorithm(9))} \n");
            Console.WriteLine($"Future calculation algorithm: {String.Join("; ", futureElevatorAlgorithm(9))} \n");

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


        internal static List<int> futureElevatorAlgorithm(int endFloor)
        {
            var floors = new List<int>();
            var currentFloor = 0;
            var stepCount = 1;

            while (currentFloor != endFloor)
            {
                if ((currentFloor + stepCount) == endFloor)
                {
                    currentFloor += stepCount;
                }
                else if ((currentFloor + stepCount + stepCount + 1) > endFloor)
                {
                    currentFloor -= stepCount;
                }
                else
                {
                    currentFloor += stepCount;
                }

                ++stepCount;
                floors.Add(currentFloor);

            }
            return floors;
        }
        internal static List<int> simpleElevatorAlgorithm(int endFloor)
        {
            var floors = new List<int>();
            var currentFloor = 0;
            var stepCount = 1;

            while (currentFloor != endFloor)
            {
                if ((currentFloor + stepCount) > endFloor)
                {
                    currentFloor -= stepCount;
                }
                else
                {
                    currentFloor += stepCount;
                }

                ++stepCount;
                floors.Add(currentFloor);

            }
            return floors;
        }
    }
}
