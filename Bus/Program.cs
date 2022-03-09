using System;
using System.Linq;
using System.Collections.Generic;

namespace Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data.FillData();
            //Data.FillStArr();
            //Data.FillStDict();
            //
            //Console.WriteLine("Введите название остановки:");
            //string statName = Console.ReadLine();
            //
            //foreach (var station in Data.StDict[statName])
            //{
            //    Console.WriteLine(station.Number);
            //}
            string line;
            int amount = Convert.ToInt32(Console.ReadLine());
            while ((line = Console.ReadLine()) != null && amount >= 0)
            {
                --amount;
                string[] command = line.Split();
                switch (command[0].ToUpper())
                {
                    case "ALL_BUSES":
                        if (Data.AllBuses.Count > 0)
                        {
                            foreach (var bus in Data.AllBuses)
                            {
                                List<string> stations = new List<string>(bus.Stations.Length);
                                foreach (var station in Data.BusDict[bus.Number])
                                {
                                    stations.Add(station.Name);
                                }
                                var stringStations = String.Join(' ', stations);
                                Console.WriteLine($"Bus {bus.Number}: {stringStations}");
                            }
                            break;
                        }
                        Console.WriteLine("No buses");
                        break;

                    case "NEW_BUS":
                        string number = command[1];

                        int count = Convert.ToInt32(command[2]);

                        Station[] stationsArr = new Station[count];
                        for(int i = 0; i < count; i++)
                        {
                            stationsArr[i] = new Station(command[i + 3]);
                        }
                        Bus newBus = new Bus(number, stationsArr);
                        Data.FillStArr();
                        Data.FillStDict();
                        break;

                    case "BUSES_FOR_STOP":
                        string stationName = command[1];
                        List<string> busNumbers = new List<string>(); 
                        if (Data.StDict.ContainsKey(stationName))
                        {
                            foreach (var bus in Data.StDict[stationName])
                            {
                                busNumbers.Add(bus.Number);
                            }
                            string result = String.Join(' ', busNumbers);
                            Console.WriteLine($"Stop {stationName}: {result}");
                            break;
                        }
                        Console.WriteLine("No stop");
                        break;

                    case "STOPS_FOR_BUS":
                        string busNumber = command[1];
                        List<string> stationNames = new List<string>();
                        if (Data.BusDict.ContainsKey(busNumber))
                        {
                            foreach (var st in Data.BusDict[busNumber])
                            {
                                stationNames.Add(st.Name);
                            }
                            string result = String.Join(' ', stationNames);
                            Console.WriteLine($"Bus {busNumber}: {result}");
                            break;
                        }
                        Console.WriteLine("No bus");
                        break;

                    case "EXIT":
                        return;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
