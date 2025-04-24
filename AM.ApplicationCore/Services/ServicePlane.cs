using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AM.ApplicationCore.Service
{
    public class ServicePlane : Service<Plane>, IServicePlanes
    {
        private readonly IGenericRepository<Plane> _planeRepository;
        private readonly IGenericRepository<Flight> _flightRepository;

        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _planeRepository = unitOfWork.Repository<Plane>();
            _flightRepository = unitOfWork.Repository<Flight>();
        }

        public override void Add(Plane plane)
        {
            _planeRepository.Add(plane);
        }

        public IEnumerable<Passenger> GetPassengers(Plane plane)
        {
            return plane.Flights.SelectMany(f => f.Passengers);
        }

        public IEnumerable<Flight> GetLastNFlightsOrderedByDepartureDate(int n)
        {
            return GetAll()
                .SelectMany(p => p.Flights)
                .OrderByDescending(f => f.FlightDate)
                .Take(n);
        }


        public void RemoveOldPlanes()
        {
            var oldPlanes = GetAll()
                .Where(p => (DateTime.Now.Year - p.ManufactureDate.Year) > 10)
                .ToList();

            foreach (var plane in oldPlanes)
            {
                Delete(plane);
            }

            Commit();
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