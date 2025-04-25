using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BrithDate { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public virtual IList<ReservationTicket> ReservationTickets { get; set; }

        public FullName FullName { get; set; }//appele de classe fullName




        [Key,StringLength(7)]
        public string PassportNumber { get; set; }


        [RegularExpression("^[0,9]{8}$")]

        public int TelNumber { get; set; }


        public virtual ICollection<Flight> Flights { get; set; }



        //Polymorphisme par Signature

        public bool checkProfile(string nom, string prenom)
        {
            return nom == FullName.LastName && prenom == FullName.FirstName ;
        }

        public bool checkProfile(string nom,string prenom,string email)
        {
            return nom == FullName.LastName && prenom == FullName.FirstName && email.Equals(EmailAddress);
        }


        public bool checkProfile1(string nom, string prenom, string email=null)
        {
            if (email == null)

                return false;
            
            return nom == FullName.LastName && prenom == FullName.FirstName && email.Equals(EmailAddress);
        }
         


        //Polymorphysme par héritage

        public virtual void PassengerType()
        {

            Console.WriteLine("I'm Passenger");
        }

    }
}
