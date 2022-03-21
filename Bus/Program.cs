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

                    //case "BUSES_FOR_STOP":
                    //    string stationName = command[1];
                    //    List<string> busNumbers = new List<string>(); 
                    //    if (Data.StDict.ContainsKey(stationName))
                    //    {
                    //        foreach (var bus in Data.StDict[stationName])
                    //        {
                    //            busNumbers.Add(bus.GetNumber());
                    //        }
                    //        string result = String.Join(',', busNumbers);
                    //        Console.WriteLine($"{result}");
                    //        break;
                    //    }
                    //    Console.WriteLine("No stop");
                    //    break;

                    case "BUSES_FOR_STOP":
                        string stationName = command[1];
                        if (Data.StDict.ContainsKey(stationName))
                        {
                            Station st = Data.AllStations.Find(x => x.GetName() == stationName);
                            Console.Write(String.Join(" ", st.GetBusNumbers()));
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("No stop");
                        }
                        break;

                    //case "STOPS_FOR_BUS":
                    //    string busNumber = command[1];
                    //    List<string> stationNames = new List<string>();
                    //    if (Data.BusDict.ContainsKey(busNumber))
                    //    {
                    //        foreach (var st in Data.BusDict[busNumber])
                    //        {
                    //            List<string> buses = new List<string>(); 
                    //            foreach (var bus in Data.StDict[st.GetName()])
                    //            {
                    //                buses.Add(bus.GetNumber().ToString());
                    //            }
                    //            string result = String.Join(' ', buses);
                    //            Console.WriteLine($"Stop {st.GetName()}: {result}");
                    //        }
                    //        break;
                    //    }
                    //    Console.WriteLine("No bus");
                    //    break;

                    case "STOPS_FOR_BUS":
                        string busNumber = command[1];
                        List<string> stationNames = new List<string>();
                        if (Data.BusDict.ContainsKey(busNumber))
                        {
                            foreach (var st in Data.BusDict[busNumber])
                            {
                                stationNames.Add(st.GetName());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No bus");
                            break;
                        }
                        foreach (var stName in stationNames)
                        {
                            Station st = Data.AllStations.Find(x => x.GetName() == stName);
                            var busNumbers = st.GetBusNumbers();
                            busNumbers.Remove(busNumber);
                            if (busNumbers.Count != 0)
                                Console.WriteLine($"Stop {stName}: {String.Join(", ", busNumbers)}");
                            else
                                Console.WriteLine($"Stop {stName}: no interchange");
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
