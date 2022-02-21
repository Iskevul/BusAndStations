using System;
using System.Collections.Generic;
using System.Text;

namespace Bus
{
    public class Bus
    {
        public int Number { get; set; }
        public Station[] Stations { get; set; }

        
        public Bus(int number, Station[] stations)
        {
            Number = number;
            Stations = stations;
            Data.AllBuses.Add(this);
            Data.BusDict[number] = stations;
        }
    }
}
