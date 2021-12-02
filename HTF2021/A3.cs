using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;

namespace HTF2021
{
    internal class A3Json_Tile
    {
        public int Id { get; set; }
        public int Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Direction: {Direction}, X: {X}, Y: {Y}";
        }
    }
    internal class A3Json
    {
        public List<string> Directions { get; set; }
        public List<A3Json_Tile> Tiles { get; set; }

        public override string ToString()
        {
            return $"Start: {string.Join("; ", Directions)}";
        }
    }
    internal static class A3
    {
        private static string testUrl = "api/path/1/hard/Sample";
        private static string productionUrl = "api/path/1/hard/Puzzle";

        private static readonly HTTPInstance clientInstance = new HTTPInstance();

        internal static void LocalExecution()
        {
            
        }

        internal static async Task TestExecution()
        {
            Console.WriteLine("-Test Execution: \n");
            var testData = await clientInstance.client.GetFromJsonAsync<A3Json>(testUrl);

            Console.WriteLine($"Test endpoint data: {string.Join(", ", testData.Directions)}");

            Dictionary<int, (int x, int y)> directions = new()
            {
                [0] = (0, -1),
                [1] = (1, -1),
                [2] = (1, 0),
                [3] = (1, 1),
                [4] = (0, 1),
                [5] = (-1, 1),
                [6] = (-1, 0),
                [7] = (-1, -1)
            };

            Node[,] nodes = new Node[(testData.Tiles.Count / 2) - 1, (testData.Tiles.Count / 2) - 1];

            foreach (var tile in testData.Tiles) {
                nodes[tile.X - 1, tile.Y - 1] = new Node { Coords = (tile.X - 1, tile.Y - 1), ID = tile.Id, Direction = tile.Direction };
            }

            Node home = null;
            for (var y = 0; y < (testData.Tiles.Count / 2) - 1; y++) { 
                for (var x = 0; x < (testData.Tiles.Count / 2) - 1; x++)
                {

                    var node = nodes[x, y];

                    Console.Write($"({node.ID}, {node.Direction} )");
                    if (node.Direction == 8)
                    {
                        home = node;
                        continue;
                    }

                    var direction = directions[node.Direction];
                    MarkNodes(nodes, node, direction);
                }
                Console.WriteLine("\n");
            }

            FindPath(home);

            pathOrder.Reverse();
            pathOrder = pathOrder.ToList();

            Console.WriteLine($"Finished: {string.Join(", ", pathOrder)}");



            var testPostResponse = await clientInstance.client.PostAsJsonAsync<List<int>>(testUrl, pathOrder);
            var testPostResponseValue = await testPostResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Test endpoint response: {testPostResponseValue}");
        }

        internal static async Task ProductionExecution()
        {
            Console.WriteLine("-Production Execution: \n");

            var productionData = await clientInstance.client.GetFromJsonAsync<A3Json>(productionUrl);

            Console.WriteLine($"Production endpoint data: {string.Join(", ", productionData.Directions)}");

            Dictionary<int, (int x, int y)> directions = new()
            {
                [0] = (0, -1),
                [1] = (1, -1),
                [2] = (1, 0),
                [3] = (1, 1),
                [4] = (0, 1),
                [5] = (-1, 1),
                [6] = (-1, 0),
                [7] = (-1, -1)
            };

            Node[,] nodes = new Node[5, 5];

            foreach (var tile in productionData.Tiles)
            {
                nodes[tile.X - 1, tile.Y - 1] = new Node { Coords = (tile.X - 1, tile.Y - 1), ID = tile.Id, Direction = tile.Direction };
            }

            Node home = null;
            for (var y = 0; y < 5 ; y++)
            {
                for (var x = 0; x < 5 ; x++)
                {

                    var node = nodes[x, y];

                    Console.Write($"({node.ID}, {node.Direction} )");
                    if (node.Direction == 8)
                    {
                        home = node;
                        continue;
                    }

                    var direction = directions[node.Direction];
                    MarkNodes(nodes, node, direction);
                }
                Console.WriteLine("\n");
            }

            FindPath(home);

            pathOrder.Reverse();
            pathOrder = pathOrder.ToList();

            Console.WriteLine($"Finished: {string.Join(", ", pathOrder)}");


        }

        internal static List<int> pathOrder = new List<int>();
        internal static List<int> successHistory = new List<int>();



        internal static Node FindSuccessParent(List<Node> nodes)
        {
            var filteredList = new List<Node>();

            foreach (var node in nodes)
            {
                if (node.Coords.x == 0 && node.Coords.y == 0) continue;
                if (pathOrder.Contains(node.ID)) continue;
                filteredList.Add(node);
            }
            if (filteredList.Count == 0) return null;
            if (filteredList.Count == 1) return filteredList[0];

            foreach (var child in filteredList)
            {
                //if (successHistory.Contains(child.ID)) return child;

                //successHistory.Add(child.ID);

                var result = FindSuccessParent(child.Parents);
                if (result != null) return child;
            }
            return null;
        }

        internal static void FindPath(Node currentNode)
        {
            pathOrder.Add(currentNode.ID);

            if (pathOrder.Count >= 23 && currentNode.Coords.x == 0 && currentNode.Coords.y == 0)
            {
                return;
            }

            if (currentNode.Parents.Count == 1)
            {
                FindPath(currentNode.Parents[0]);
            }
            else if (currentNode.Parents.Count > 1)
            {
                FindPath(FindSuccessParent(currentNode.Parents));
                successHistory = new List<int>();
            }
        
        }
      

        internal static void MarkNodes(Node[,] nodes, Node node, (int x, int y) direction)
        {
            var (x, y) = node.Coords;
            while (true)
            {
                x += direction.x;
                y += direction.y;

                if (x >= nodes.GetLength(0) || y >= nodes.GetLength(1) || x < 0 || y < 0)
                    return;


                node.Parents.Add(nodes[x, y]);

                //nodes[x, y].Parents.Add(node);
            }
        }
    }
}