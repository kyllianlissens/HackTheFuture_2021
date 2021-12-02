using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;

namespace HTF2021
{
    internal static class A3
    {
        private static string testUrl = "api/path/1/hard/Sample";
        private static string productionUrl = "api/path/1/hard/Puzzle";

        private static readonly HTTPInstance clientInstance = new HTTPInstance();

        internal static void LocalExecution()
        {
            Console.WriteLine("-Local Execution: \n");
            string input = @"e se se sw  s
                            s nw nw  n  w
                            ne  s  h  e sw
                            se  n  w ne sw
                            ne nw nw  n  n";

            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            (int x, int y) start = (2, 0);

            var rows = lines.Select(x => x.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            var cols = rows[0].Length;
            Node[,] nodes = new Node[rows.Length, cols];


            var idCounter = 0;
            for (var y = 0; y < cols; y++)
            for (var x = 0; x < rows.Length; x++)
            {
                nodes[x, y] = new Node { Coords = (x, y), ID = idCounter };
                idCounter++;
            }

            Dictionary<string, (int x, int y)> directions = new()
            {
                ["n"] = (0, -1),
                ["ne"] = (1, -1),
                ["e"] = (1, 0),
                ["se"] = (1, 1),
                ["s"] = (0, 1),
                ["sw"] = (-1, 1),
                ["w"] = (-1, 0),
                ["nw"] = (-1, -1)
            };

            Node home = null;
            for (var y = 0; y < rows.Length; y++)
            for (var x = 0; x < cols; x++)
            {
                var type = rows[y][x];

                var node = nodes[x, y];
                if (type == "h")
                {
                    home = node;
                    continue;
                }

                var direction = directions[type];
                Utilities.MarkNodes(nodes, node, direction);
            }

            var path = Utilities.FindPath(start, home);

            Console.WriteLine($"Path IDs: {string.Join("; ", path)}");
            Console.ReadLine();
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