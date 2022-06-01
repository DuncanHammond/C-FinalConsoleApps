using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomodoInsurance.Repository;

namespace KomodoInsurance.ConsoleApp
{
    public class OutingsInterface
    {
        OutingsRepository _outingsRepository = new OutingsRepository();
        bool isRunning = true;         

        public void Run()
        {
            _outingsRepository.BaseOutingsData();

            while (isRunning)
            {
                PrintMainMenu();

                string input = GetUserInput();

                ChooseMenuOptionMethod(input);
            }
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("1.) Add new outing event.");
            Console.WriteLine("2.) Display all outings.");
            Console.WriteLine("3.) Calculate total cost of all outings.");
            Console.WriteLine("4.) Calculate total cost of outings by type.");
            Console.WriteLine("5.) Close Program.");

            Console.WriteLine("Enter number choice: ");
        }

        private string GetUserInput()
        {
            return Console.ReadLine();
        }

        private void ChooseMenuOptionMethod(string input)
        {
            switch(input)
            {
                case "1":
                    CreateNewOuting();
                    break;
                case "2":
                    DisplayAllOutings();
                    break;
                case "3":
                    //CalculateAllOutings();
                    break;
                case "4":
                    //CalculateOutingByType();
                    break;
                case "5":
                    isRunning = false;
                    CloseProgram();
                    break;
                default:
                    break;
            }
        }

        private void CreateNewOuting()
        {
            Console.WriteLine("Create new outing: ");

            Console.WriteLine("Outing Name: ");
            string eventName = GetUserInput();

            Console.WriteLine("Select outing category by number: ");
            Console.WriteLine("1.) Golf");
            Console.WriteLine("2.) Bowling");
            Console.WriteLine("3.) Amusement Park");
            Console.WriteLine("4.) Concert");

            int outingTypeChoice = Convert.ToInt32(GetUserInput());

            EventCategory typeOfEvent = EventCategory.Golf;

            switch (outingTypeChoice)
            {
                case 1:
                    typeOfEvent = EventCategory.Golf;
                    break;
                case 2:
                    typeOfEvent = EventCategory.Bowling;
                    break;
                case 3:
                    typeOfEvent = EventCategory.AmusementPark;
                    break;
                case 4:
                    typeOfEvent = EventCategory.Concert;
                    break;
                default:
                    break;
            }

            Console.WriteLine("Enter number of attendees: ");
            int attendees = Convert.ToInt32(GetUserInput());

            // Console.WriteLine("Enter date of outing: $");
            // DateTime calendar = Convert.ToDateTime(GetUserInput());

            
            Console.Write("Enter a day (number DD): ");
            int day = int.Parse(GetUserInput());
            Console.Write("Enter a month (number MM): ");
            int month = int.Parse(GetUserInput());
            Console.Write("Enter a year (number YYYY): ");
            int year = int.Parse(GetUserInput());

            DateTime calendar = new DateTime(year, month, day);


            Console.Write("Enter cost per person: $");
            double costPerPerson = Convert.ToDouble(GetUserInput());

            // Outings newOuting = new Outings(eventName, eventType, attendees, calendar, costPerPerson);

            // _outingsRepository.AddOutingToList(newOuting);

        }

        private void DisplayIndividualOuting(Outings outings)
        {
            Console.WriteLine($"{outings.EventName}" + 
                            $"\n{outings.EventType}" + 
                            $"\n{outings.Attendees}" + 
                            $"\n{outings.Calendar}" + 
                            $"\n{outings.CostPerPerson}");
        }

        private void DisplayAllOutings()
        {
            List<Outings> allOutings = _outingsRepository.GetAllOutingsFromList();

            foreach (Outings interval in allOutings)
            {
                DisplayIndividualOuting(interval);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /*
        public double CalculateOutingCost(double totalEventCost, int Attendees, double CostPerPerson)
        {
            foreach(Outings outings in _outingsList)
            {
                totalEventCost = Attendees * CostPerPerson;
            }

            return totalEventCost;
        }

        public double CalculateAllOutings(double totalEventCost)
        {
            totalCost = 0m;
            foreach(Outings outings in _outingsList)
            {
                totalCost += totalEventCost;
            }

            return totalCost;
        }

        public double CalculateOutingByType(double TotalCost, double totalEventCost, EventCategory EventType, int Attendees, double CostPerPerson)
        {
            int outingType;


            double GolfTotalCosts = 0;
            double BowlingTotalCosts = 0;
            double AmusementParkTotalCosts = 0;
            double ConcertTotalCosts = 0;

            double GolfCosts = 0;
            double BowlingCosts = 0;
            double AmusementParkCosts = 0;
            double ConcertCosts = 0;


            if (outingType = 1)
            {
            foreach (EventCategory.Golf individualOuting in _outingsList)
            {
                GolfCosts = Attendees * CostPerPerson;
                GolfTotalCosts = GolfTotalCosts + GolfCosts;
            }

            return GolfTotalCosts;
            }

            
            else if (outingType = 2)
            {
            foreach (EventCategory.Bowling individualOuting in _outingsList)
            {
                BowlingCosts = Attendees * CostPerPerson;
                BowlingTotalCosts = BowlingTotalCosts + BowlingCosts;
            }

            return BowlingTotalCosts;
            }

            else if (outingType = 3)
            {
            foreach (EventCategory.AmusementPark individualOuting in _outingsList)
            {
                AmusementParkCosts = Attendees * CostPerPerson;
                AmusementParkTotalCosts = AmusementParkTotalCosts + AmusementParkCosts;
            }

            return AmusementParkTotalCosts;
            }

            else if (outingType = 4)
            {
            foreach (EventCategory.Concert individualOuting in _outingsList)
            {
                ConcertCosts = Attendees * CostPerPerson;
                ConcertTotalCosts = ConcertTotalCosts + ConcertCosts;
            }

            TotalCost = GolfTotalCosts + BowlingTotalCosts + AmusementParkTotalCosts + ConcertTotalCosts;

            return TotalCost;
            }
            

            else
            {
                Console.WriteLine("I'm sorry, that's not an option.");
            }
        }
        */
        
        public void CloseProgram()
        {
            Console.WriteLine("Closing down program. Press any key to Close.");
            Console.ReadKey();
        }

    }
}