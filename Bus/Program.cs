using System;
using System.Linq;

namespace Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data.FillData();
            Data.FillStArr();
            Data.FillStDict();

            Console.WriteLine("Введите название остановки:");
            string statName = Console.ReadLine();

            foreach (var station in Data.StDict[statName])
            {
                Console.WriteLine(station.Number);
            }
        }
    }
}
