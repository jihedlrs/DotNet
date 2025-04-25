using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        //Retourner true si on peut réserver n places à un vol passé en paramètre.(patron de conception)
        public bool Reserver(Flight f, int n)
        {
            return f.plane.Capacity >=f.Passengers.Count() + n;
        }


        //- Supprimer tous les avions dont la date de fabrication a dépassé 10 ans. (patron de conception)
        public void deletePlane()
        {
            Delete(p => DateTime.Now.Year - p.ManufactureDate.Year > 10);
        }



        public Dictionary<DateTime, int> GetPassengerByFlightDate(DateTime startDate, DateTime endDate)
        {
            return GetAll().SelectMany(p => p.Flights)
                .Where(f => (f.FlightDate) >= startDate && (f.FlightDate) <= endDate)
                .GroupBy(f => (f.FlightDate).Date)
                .ToDictionary(g => g.Key, g => g.Sum(f => f.Passengers.Count()));
        }







    }
}
