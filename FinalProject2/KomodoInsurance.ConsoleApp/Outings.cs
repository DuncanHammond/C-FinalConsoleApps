using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomodoInsurance.Repository
{
    public class Outings
    {
        public string EventName { get; set; }
        public EventCategory EventType { get; set; }
        public int Attendees { get; set; }
        public DateTime Calendar { get; set; }
        public double CostPerPerson { get; set; }
        // public decimal TotalEventCost { get; set; }

        public Outings(string eventName, EventCategory eventType, int attendees, DateTime calendar, double costPerPerson)
        {
            EventName = eventName;
            EventType = eventType;
            Attendees = attendees;
            Calendar = calendar;
            CostPerPerson = costPerPerson;
            // TotalEventCost = totalEventCost;
        }
    }
    public enum EventCategory { Golf, Bowling, AmusementPark, Concert }
}