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

            var pathOrder = FindPath(nodes[0,0], home, new List<Node>());

            Console.WriteLine($"Finished: {string.Join(", ", pathOrder)}");


        }


        internal static List<Node> FindPath(Node currentNode, Node goal, List<Node> walkedNodes)
        {
            if(currentNode.Coords.Equals(goal.Coords))
            {
                walkedNodes.Add(currentNode);
                return walkedNodes;
            }
            else if(walkedNodes.Contains(currentNode))
            {
                return null;
            }

            else if(currentNode.Parents.Count == 0)
            {
                return null;
            }
            else if (walkedNodes.Count > 25 )
            {
                return null;
            }
            else
            {
                walkedNodes.Add(currentNode);
            }
            

            

            

            foreach (var child in currentNode.Parents)
            {
                var result = FindPath(child, goal, walkedNodes);
                if (result == null){
                    continue;
                }
                else if (result.Count >= 23)
                {

                    foreach (var a in result)
                    {
                        Console.WriteLine($"{a},");
                    }
                    Console.WriteLine("b");
                }
                else
                {
                    Console.WriteLine("a");
                }

            }

            


            return null;




         

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

            }
        }
    }
}