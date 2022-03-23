using System;
using System.Collections.Generic;

namespace Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                                List<string> stations = new List<string>(bus.GetStations().Length);
                                foreach (var station in Data.BusDict[bus.GetNumber()])
                                {
                                    stations.Add(station.GetName());
                                }
                                var stringStations = String.Join(' ', stations);
                                Console.WriteLine($"Bus {bus.GetNumber()}: {stringStations}");
                            }
                            break;
                        }
                        Console.WriteLine("No buses");
                        break;

                    case "NEW_BUS":
                        string number = command[1];

                        int count = Convert.ToInt32(command[2]);

                        Station[] stationsArr = new Station[count];

                        for (int i = 0; i < count; i++)
                        {
                            Station st = new Station(command[i + 3]);
                            stationsArr[i] = st;
                        }

                        Bus newBus = new Bus(number, stationsArr);

                        break;

                    case "BUSES_FOR_STOP":
                        string stationName = command[1];
                        Console.WriteLine(Data.FindBusesForStation(stationName));
                        break;

                    case "STOPS_FOR_BUS":
                        string busNumber = command[1];
                        foreach (var station in Data.FindStationsForBus(busNumber))
                        {
                            Console.WriteLine(station);
                        }
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
