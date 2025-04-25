using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        internal readonly object Plane;

        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }


        //1ere methode de faire forignkey
        //[ForeignKey("plane")] 

        //2eme methode qui on travailler dans flightConfiguration *Voir  flightConfiguration *
        public int planefk { get; set; }

        //proprieter de navigation 

        public virtual Plane plane { get; set; }

        public string AirlineLogo { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
