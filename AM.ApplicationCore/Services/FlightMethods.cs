using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {

        public List<Flight> Flights = new List<Flight>();

        public List<Flight> FlightsVide = new List<Flight>();



        //Avec for

        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> dates = new List<DateTime>();
        //    for (int i = 0; i < Flights.Count; i++)
        //    {
        //        if (Flights[i].Destination == destination)
        //            dates.Add(Flights[i].FlightDate);
        //    }
        //    return dates;
        //}



        //Avec ForEach
        public List<DateTime> GetFlightDates(string destination)
        {

            List<DateTime> dates = new List<DateTime>();
            //foreach (Flight i in Flights)

            //{
            //    if (i.Destination == destination)
            ////        dates.Add(i.FlightDate);
            //}



            //////avec Linq***
            ///
            var query = from f in Flights
                        where f.Destination == destination
                        select f.FlightDate;
            return query.ToList();

        }



        public void GetFlights(string filterType, string filterValue)
        {
            List<Flight> result = new List<Flight>();
            foreach (Flight i in Flights)
            {


                switch (filterType)
                {
                    case "Destination":
                        if (i.Departure == filterValue)
                            Console.WriteLine(i);
                        break;
                    case "EstimatedDuration":
                        if (i.EstimatedDuration == int.Parse(filterValue))
                            Console.WriteLine(i);
                        break;





                }



            }
        }

       

        public void ShowFlightDetails(Plane plane)
        {
            List<Flight> planeFlights = new List<Flight>();
            foreach (var flight in Flights)
            {
                if (flight.plane != null && flight.plane == plane)
                {
                    planeFlights.Add(flight);
                }
            }

             
                foreach (var flight in planeFlights)
                {
                    Console.WriteLine(flight.FlightDate.ToShortDateString());
                    Console.WriteLine(flight.Destination);

                
            }
        }




        public int ProgrammedFlightNumber(DateTime startDate)
        {
            int count = 0;
            DateTime endDate = startDate.AddDays(7); 

            foreach (Flight flight in Flights) 
            {
                if (flight.FlightDate >= startDate && flight.FlightDate < endDate) 
                {
                    count++; 
                }
            }

            return count;

        }

        public int DurationAverage(string destination)
        {
            int totalDuration = 0; 
            int count = 0;

            foreach (Flight flight in Flights) 
            {
                if (flight.Destination == destination) 
                {
                    totalDuration += flight.EstimatedDuration; 
                    count++;
                }
            }

            return totalDuration / count; 
        }



        public List<Flight> OrderedDurationFlights()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration).ToList();

        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            // Vérifie si Passengers est null ou vide
            if (flight.Passengers == null || !flight.Passengers.Any())
            {
                Console.WriteLine("Aucun passager trouvé.");
                return new List<Traveller>(); // Retourne une liste vide si aucun passager
            }

            // Filtrage des passagers de type Traveller et tri par date de naissance
            return flight.Passengers.OfType<Traveller>()
                                    .OrderByDescending(p => p.BrithDate)
                                    .Take(3)
                                    .ToList();
        }





    }
}

