using System.Collections.Generic;

namespace HTF2021
{
    public class Node
    {
        public (int x, int y) Coords;
        public int Direction;
        public int ID;
        public List<Node> Parents = new();
        public bool Visited;

        public override string ToString()
        {
            return $"{ID}";
        }
    }
}