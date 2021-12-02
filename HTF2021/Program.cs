using System;
using System.Collections.Generic;
using System.Linq;

namespace HTF2021 // Note: actual namespace depends on the project name.
{
    public class Program
    {

      

        public static void Main(string[] args)
        {
            
            Console.WriteLine("#A-1 \n");

            A1.LocalExecution();
            A1.TestExecution();
            //A1.ProductionExecution();

            Console.WriteLine("#A-2 \n");

            A2.LocalExecution();
            A2.TestExecution();
            //A2.ProductionExecution();

            Console.WriteLine("#A-3 \n");

            A3.LocalExecution();
            A3.TestExecution();
            //A3.ProductionExecution();

            Console.WriteLine("#B-1 \n");

            B1.LocalExecution();
            B1.TestExecution();
            //B1.ProductionExecution();

            Console.WriteLine("#B-2 \n");

            B2.LocalExecution();
            B2.TestExecution();
            //B2.ProductionExecution();

            Console.WriteLine("#B-3 \n");

            B3.LocalExecution();
            B3.TestExecution();
            //B3.ProductionExecution();
        }
    }
}