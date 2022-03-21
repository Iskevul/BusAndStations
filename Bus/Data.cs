using System;
using System.Collections.Generic;
using System.Text;

namespace Bus
{
    public static class Data
    {
        public static List<Station> AllStations = new List<Station>();

        public static List<Bus> AllBuses = new List<Bus>();
        
        public static Dictionary<string, List<Station>> BusDict = new Dictionary<string, List<Station>>();
        public static Dictionary<string, List<Bus>> StDict = new Dictionary<string, List<Bus>>();


        public static void FillStArr()
        {

            foreach (var bus in Data.AllBuses)
            {
                foreach (var st in bus.GetStations())
                {
                    if (!st.GetBusList().Contains(bus))
                        st.GetBusList().Add(bus);
                }
            }
        }

        public static void FillStDict()
        {
            foreach (var station in Data.AllStations)
            {
                StDict[station.GetName()] = station.GetBusList();
            }
        }

        public static void FillData()
        {
            Station st1 = new Station("ЦУМ");
            Station st2 = new Station("Советская");
            Station st3 = new Station("Абжалилова");
            Station st4 = new Station("Театр Камала");
            Station st6 = new Station("Гоголя");
            Station st7 = new Station("Толстого");
            Station st8 = new Station("Высокая Гора");
            Station st9 = new Station("Фучика");
            Station st10 = new Station("Космонавтов");
            Station st11 = new Station("Речной техникум");
            Station st12 = new Station("Адоратского");
            Station st13 = new Station("Кафе полёт");


            Bus bus91 = new Bus("91", new Station[] { st1, st2, st4, st6, st7, st8 });
            Bus bus63 = new Bus("63", new Station[] { st3, st9, st10, st11, st13 });
            Bus bus33 = new Bus("33", new Station[] { st9, st10, st12, st13 });
        }

        public static List<string> FindBusesForStation(string name)
        {
            List<string> numbers = new List<string>();
            List<Bus> buses = StDict[name];
            foreach (var bus in buses)
            {
                numbers.Add(bus.GetNumber());
            }
            
            return numbers;
        }
    }
}
