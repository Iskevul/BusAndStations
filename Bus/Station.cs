using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bus
{
    public class Station
    {
        public string Name { get; set; }
        public List<Bus> BusList { get; set; }
        public Bus[] BusArr { get; set; }

        public Station(string name)
        {
            Name = name;
            Data.AllStations.Add(this);
            BusList = new List<Bus>();
        }

        public bool IsBusVisitsStation(Bus bus)
        {
            return BusArr.Contains(bus);
        }
    }
}
