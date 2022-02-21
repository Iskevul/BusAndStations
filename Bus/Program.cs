using System;
using System.Linq;

namespace Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Station st1 = new Station(1, "ЦУМ");
            Station st2 = new Station(2, "Советская");
            Station st3 = new Station(3, "Абжалилова");
            Station st4 = new Station(4, "Театр Камала");
            Station st6 = new Station(6, "Гоголя");
            Station st7 = new Station(7, "Толстого");
            Station st8 = new Station(8, "Высокая Гора");
            Station st9 = new Station(9, "Фучика");
            Station st10 = new Station(10, "Космонавтов");
            Station st11 = new Station(11, "Речной техникум");
            Station st12 = new Station(12, "Адоратского");
            Station st13 = new Station(13, "Кафе полёт");


            Bus bus91 = new Bus(91, new Station[] { st1, st2, st4, st6, st7, st8 });
            Bus bus63 = new Bus(63, new Station[] { st3, st9, st10, st11, st13 });
            Bus bus33 = new Bus(33, new Station[] { st9, st10, st12, st13 });

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
