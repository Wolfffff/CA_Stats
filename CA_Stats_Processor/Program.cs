using System;
using CA_Stats_Processor.Helpers;

namespace CA_Stats_Processor
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Entergy CA Stats CSV Processor \n \n");
            Console.Write("Please type exact directory of CSV files. \nNote: folder should container only relevant CSV files with proper names.\n");
            var location = Console.ReadLine();
            var array = CSVHelper.CombineAndConvert(location);


            var largeGapCountAndMaxGap = ProcessingHelper.ThirtyAndSixty(array);
            Console.Write("Number of gaps with time(in minutes) greater than 30 is " + largeGapCountAndMaxGap.Item1 + ".\n\n");
            Console.Write("Number of gaps with time(in minutes) greater than 60 is " + largeGapCountAndMaxGap.Item2 + ".\n");

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
