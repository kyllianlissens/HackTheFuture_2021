using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{
    internal static class Utilities
    {
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

        

        

    }
}
