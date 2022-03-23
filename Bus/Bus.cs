using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bus
{
    public class Bus
    {
        private string Number { get; set; }
        private Station[] Stations { get; set; }

        public Bus(string number, Station[] stations)
        {
            Number = number;
            Stations = stations;
            Data.AllBuses.Add(this);
            if (!Data.BusDict.ContainsKey(number))
                Data.BusDict[number] = stations.ToList();
            foreach (Station station in Stations)
            {
                station.AddToBusList(this);
                if (!Data.StDict.ContainsKey(station.GetName()))
                    Data.StDict[station.GetName()] = new List<Bus> { this, };
                else
                    Data.StDict[station.GetName()].Add(this);
            }
            Data.FillStDict();
        }

        public string GetNumber()
        {
            return Number;
        }

        public Station[] GetStations()
        {
            return Stations;
        }

        public bool CanMoveToStation(Station station)
        {
            return Stations.Contains(station);
        }
    }
}
