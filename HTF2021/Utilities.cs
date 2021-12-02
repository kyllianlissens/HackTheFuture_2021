using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{
    internal static class Utilities
    {
        internal static int digitSum(int n)
        {
            if (n == 0) return 0;
            return (n % 9 == 0) ? 9 : (n % 9);
        }

        internal static List<int> randomIntegerList(int amount, int min, int max)
        {
            var numbers = new List<int>();
            var rnd = new Random();
            for (int i = 0; i <= amount; i++)
            {
                numbers.Add(rnd.Next(min, max));
            }
            return numbers;
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
                    currentFloor  -= stepCount;
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

        internal static List<int> FindPath((int x, int y) target, Node node)
        {
            if (target.x == node.Coords.x && Equals(target.y, node.Coords.y))
                return new List<int> { node.ID };

            node.Visited = true;

            foreach (var parent in node.Parents)
            {
                if (parent.Visited)
                    continue;

                var path = FindPath(target, parent);
                if (path == null) continue;
                path.Add(node.ID);
                return path;
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

                nodes[x, y].Parents.Add(node);
            }
        }

    }
}
