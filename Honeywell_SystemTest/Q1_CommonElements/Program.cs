using System;
using System.Collections.Generic;
using System.Linq;

namespace Q1_CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstElements1 = new List<int>() { 9, 11, 15, 36, 27, 54 };
            List<int> lstElements2 = new List<int>() { 9, 17, 29, 34, 35, 27 };
            foreach (var value in lstElements1.Intersect(lstElements2))
            {
                Console.WriteLine(value);
            }
        }
    }
}
