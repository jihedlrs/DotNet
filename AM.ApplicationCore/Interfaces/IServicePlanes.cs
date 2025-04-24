using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlanes : IService<Plane>
    {

        IEnumerable<Passenger> GetPassengers(Plane plane);
        IEnumerable<Flight> GetLastNFlightsOrderedByDepartureDate(int n);
        void RemoveOldPlanes();
        Dictionary<DateTime, int> GetPassengerByFlightDate(DateTime startDate, DateTime endDate);
    }
}