using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : Service<Flight>,  IFlightMethods
    {

        public List<Flight> Flights = new List<Flight>();

        public List<Flight> FlightsVide = new List<Flight>();

        public FlightMethods(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }



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
            //    var query = from f in Flights
            //                where f.Destination == destination
            //                select f.FlightDate;
            //    return query.ToList();

            //}


            // Avec  Lamda Expression

            return Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();

        }


        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> result = new List<Flight>();

            foreach (Flight i in Flights)
            {
                switch (filterType)
                {
                    case "Destination":
                        if (i.Departure == filterValue)
                        {
                            result.Add(i);
                            Console.WriteLine(i); // Affichage pour vérification
                        }
                        break;
                    case "EstimatedDuration":
                        if (i.EstimatedDuration == int.Parse(filterValue))
                        {
                            result.Add(i);
                            Console.WriteLine(i); // Affichage pour vérification
                        }
                        break;
                }
            }

            return result;
        }




        public void ShowFlightDetails(Domain.Plane plane)
        {
            //Avec Linq

            //var req = from f in Flights
            //          where f.plane == plane
            //          select new { f.Destination, f.FlightDate };
            //foreach (var q in req)
            //{
            //    Console.WriteLine(q.ToString());
            //}

            //Avec Lamda

            var req=Flights.Where(f=>f.plane == plane).Select(f => new {f.Destination,f.FlightDate});
            foreach (var q in req)
            {
                Console.WriteLine(q.ToString());
            }

        }



        public int ProgrammedFlightNumber(DateTime startDate)
        {

            var query = from f in Flights
                        where DateTime.Compare(startDate, f.FlightDate) <= 0
                        && (f.FlightDate-startDate).TotalDays <= 7
                        select f;
            return query.Count();


        }


        public double DurationAverage(string destination)

            //Avec Linq
        {
            //var query = from flight in Flights
            //            where flight.Destination == destination
            //            select flight.EstimatedDuration;
            //            return query.Average();

            //Avec Lamda

            return Flights.Where(f=>f.Destination== destination).Select(f=>f.EstimatedDuration).Average();

        }


        public IEnumerable<Flight> OrderedDurationFlights()
        {// Avec Linq

            //var query = from f in Flights
            //            orderby f.EstimatedDuration descending
            //            select f;
            //return query;

            //Avec Lamda

            return Flights.OrderByDescending(f => f.EstimatedDuration);


        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight) {

            // Avec Linq

            //var req = from f in flight.Passengers.OfType<Traveller>()
            //          orderby f.BrithDate ascending
            //          select f;
            //return req.Take(3);

            //Avec Lamda

            return flight.Passengers.OfType<Traveller>().OrderBy(f=>f.BrithDate).Take(3);

        }

        public IEnumerable<IGrouping<string,Flight>> DestinationGroupFlihghts()
        {
            var req = from f in Flights
                      group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine(g.Key);
                foreach (var v in g)

                    Console.WriteLine("Décollage : " + v.FlightDate);
            }
            return req;
        }




        //- Retourner les vols ordonnés par date de départ des n derniers avions(patron de conception).  
        public IEnumerable<Flight> ListFlight(int n)
        {
            return GetAll().OrderBy(f => f.FlightDate).TakeLast(n);
            
        }


        public IEnumerable<Staff> GetStaffByFlightId(int volId)
        {
            return GetById(volId).Passengers.OfType<Staff>();
        }

       
    }       
}

