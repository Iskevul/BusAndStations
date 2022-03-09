using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bus
{
    public class Bus
    {
        public string Number { get; set; }
        public Station[] Stations { get; set; }

        
        public Bus(string number, Station[] stations)
        {
            Number = number;
            Stations = stations;
            Data.AllBuses.Add(this);
            Data.BusDict[number] = stations;
        }

        public bool CanMoveToStation(Station station)
        {
            return Stations.Contains(station);
        }
    }
}
