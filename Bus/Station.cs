using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bus
{
    public class Station
    {
        private string Name { get; set; }
        private List<Bus> BusList { get; set; }
        private Bus[] BusArr { get; set; }

        public Station(string name)
        {
            Name = name;
            Data.AllStations.Add(this);
            BusList = new List<Bus>();
        }

        public string GetName()
        {
            return Name;
        }

        public List<Bus> GetBusList()
        {
            return BusList;
        }

        public List<string> GetBusNumbers()
        {
            List<string> list = new List<string>();
            foreach(var bus in BusList)
            {
                list.Add(bus.GetNumber());
            }
            return list;
        }

        public void AddToBusList(Bus bus)
        {
            BusList.Add(bus);
        }

        public Bus[] GetBusArr()
        {
            return BusArr;
        }

        public void SetBusArr(List<Bus> busList)
        {
            BusArr = busList.ToArray();
        }

        public bool IsBusVisitsStation(Bus bus)
        {
            return BusArr.Contains(bus);
        }
    }
}
