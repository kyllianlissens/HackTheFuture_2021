using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{
    public class Node
    {
        public (int x, int y) Coords;
        public int ID;
        public int Direction;
        public List<Node> Parents = new List<Node>();
        public bool Visited;

        public override string ToString()
        {
            return $"{ID}";
        }
    }
}
