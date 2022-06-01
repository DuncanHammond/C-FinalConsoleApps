using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomodoInsurance.Repository
{
    public class OutingsRepository
    {
        private List<Outings> _outingsList = new List<Outings>();



        public void AddOutingToList(Outings outings)
        {
            _outingsList.Add(outings);
        }

        public List<Outings> GetAllOutingsFromList()
        {
            return _outingsList;
        }

        public Outings GetOutingsFromListByEvent(string userInputEventSearch)
        {
            foreach (Outings outings in _outingsList)
            {
                if (outings.EventName.ToUpper() == userInputEventSearch.ToUpper())
                {
                    return outings;
                }
            }

            return null;
        }

        public bool UpdateOutings(Outings outings)
        {
            foreach (Outings existingOuting in _outingsList)
            {
                if (existingOuting.EventName.ToUpper() == outings.EventName.ToUpper())
                {
                    existingOuting.EventName = outings.EventName;
                    existingOuting.EventType = outings.EventType;
                    existingOuting.Attendees = outings.Attendees;
                    existingOuting.Calendar = outings.Calendar;
                    existingOuting.CostPerPerson = outings.CostPerPerson;

                    return true;
                }
            }

            return false;
        }

        public bool UpdateOutings(Outings outings, string eventName)
        {
            foreach (Outings existingOuting in _outingsList)
            {
                if (existingOuting.EventName.ToUpper() == eventName.ToUpper())
                {
                    existingOuting.EventName = outings.EventName;
                    existingOuting.EventType = outings.EventType;
                    existingOuting.Attendees = outings.Attendees;
                    existingOuting.Calendar = outings.Calendar;
                    existingOuting.CostPerPerson = outings.CostPerPerson;

                    return true;
                }
            }

            return false;
        }

        public bool DeleteOutingByEventName(string eventName)
        {
            foreach (Outings outings in _outingsList)
            {
                if (outings.EventName.ToUpper() == eventName.ToUpper())
                {
                    _outingsList.Remove(outings);
                }
            }
            return false;
        }

        public void BaseOutingsData()
        {
            Outings cosmicBowling1 = new Outings("Cosmic Bowling 1", EventCategory.Bowling, 6, DateTime.Parse("2/5/2022"), 4.99);
            Outings cosmicBowling2 = new Outings("Cosmic Bowling 2", EventCategory.Bowling, 5, DateTime.Parse("2/14/2022"), 4.99);
            Outings cosmicBowling3 = new Outings("Cosmic Bowling 3", EventCategory.Bowling, 6, DateTime.Parse("2/26/2022"), 4.99);
            Outings jazzFest1 = new Outings("Jazz Fest 2020", EventCategory.Concert, 8, DateTime.Parse("4/5/2020"), 29.99);
            Outings jazzFest2 = new Outings("Jazz Fest 2021", EventCategory.Concert, 3, DateTime.Parse("4/5/2021"), 29.99);
            Outings jazzFest3 = new Outings("Jazz Fest 2022", EventCategory.Concert, 6, DateTime.Parse("4/5/2022"), 29.99);
            Outings miniGolf1 = new Outings("Great Times Mini Golf July", EventCategory.Golf, 5, DateTime.Parse("7/5/2022"), 9.99);
            Outings miniGolf2 = new Outings("Great Times Mini Golf August", EventCategory.Golf, 12, DateTime.Parse("8/5/2022"), 9.99);
            Outings miniGolf3 = new Outings("Great Times Mini Golf September", EventCategory.Golf, 9, DateTime.Parse("9/5/2022"), 9.99);
            Outings sixFlags = new Outings("Six Flags", EventCategory.AmusementPark, 18, DateTime.Parse("6/30/2021"), 14.99);

            Outings[] outingsArr = { };
            foreach (Outings outings in outingsArr)
            {
                AddOutingToList(outings);
            }
        }


    }
}