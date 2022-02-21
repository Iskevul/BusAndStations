using System;
using System.Collections.Generic;
using System.Text;

namespace Bus
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Bus> BusList { get; set; }
        public Bus[] BusArr { get; set; }

        public Station(int id, string name)
        {
            Id = id;
            Name = name;
            Data.AllStations.Add(this);
            BusList = new List<Bus>();
        }
    }
}
