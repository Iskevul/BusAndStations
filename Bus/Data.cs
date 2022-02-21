using System;
using System.Collections.Generic;
using System.Text;

namespace Bus
{
    public static class Data
    {
        public static List<Bus> AllBuses = new List<Bus>();
        public static List<Station> AllStations = new List<Station>();

        public static Dictionary<int, Station[]> BusDict = new Dictionary<int, Station[]>();
        public static Dictionary<string, Bus[]> StDict = new Dictionary<string, Bus[]>();

        public static void FillStArr()
        {

            foreach (var bus in Data.AllBuses)
            {
                foreach (var st in bus.Stations)
                {
                    if (!st.BusList.Contains(bus))
                        st.BusList.Add(bus);
                }
            }
        }

        public static void FillStDict()
        {
            foreach (var station in Data.AllStations)
            {
                station.BusArr = station.BusList.ToArray();
            }

            foreach (var st in Data.AllStations)
            {
                StDict[st.Name] = st.BusArr;
            }
        }
    }
}
