using System;
using System.Collections.Generic;

namespace KaspHackTask12
{
    public enum DataType
    {
        None = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',');
            var invalidVals = new List<string>();
            var validVals = new int[]{0, 0, 0, 0, 0};
            int intValue; 
            foreach (var value in input)
            {
                var isInt = int.TryParse(value, out intValue);
                if (isInt && Enum.IsDefined(typeof(DataType), intValue))
                {
                    validVals[intValue]++;
                }
                else if (Enum.IsDefined(typeof(DataType), value))
                {
                    intValue = (int)Enum.Parse(typeof(DataType), value);
                    validVals[intValue]++;
                }
                else
                {
                    invalidVals.Add(value);
                }
            }
            Console.WriteLine("Input data types:");
            for (int i = 0; i < validVals.Length; i++)
            {
                Console.WriteLine($"{Enum.GetName(typeof(DataType), i)}({i}) - {validVals[i]}");
            }
            Console.WriteLine("Errors:");
            Console.WriteLine($"Not valid input strings: {string.Join(',', invalidVals)}");
        }
    }
}
