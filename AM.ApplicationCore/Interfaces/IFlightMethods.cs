using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods : IService<Flight>
    {
        public List<DateTime> GetFlightDates(string destination);
        public List<Flight>  GetFlights(string filterType, string filterValue);

        public void ShowFlightDetails(Plane plane);

        int ProgrammedFlightNumber(DateTime startDate);

        public double DurationAverage(string destination);


         public IEnumerable<Flight> OrderedDurationFlights();

         public IEnumerable<Traveller> SeniorTravellers(Flight flight);

        IEnumerable<IGrouping<string,Flight>> DestinationGroupFlihghts();


        IEnumerable<Flight> ListFlight(int n);

        IEnumerable<Staff> GetStaffByFlightId(int volId);








    }
}
