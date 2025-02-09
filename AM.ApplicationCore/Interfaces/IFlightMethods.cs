using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        public List<DateTime> GetFlightDates(string destination);
        public void  GetFlights(string filterType, string filterValue);
        public void ShowFlightDetails(Plane plane);

        int ProgrammedFlightNumber(DateTime startDate);

        public int DurationAverage(string destination);


        public List<Flight> OrderedDurationFlights();

        public List<Traveller> SeniorTravellers(Flight flight);


    }
}
