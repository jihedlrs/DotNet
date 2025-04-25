using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    {
        public DateTime DateReservation { get; set; }
        public float Prix { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Passenger Passenger { get; set; }

        //clé etranger 
        [ForeignKey("Ticket")]
        public int ticketfk { get; set; } //"pourqoi int"car prend le meme  type de cle primare de table ticket

        //clé etranger 
        [ForeignKey("Passenger")]
        public string Passengersfk { get; set; } // "pourqoi string"car prend le meme  type de cle primare de table Passengers
    }
}
