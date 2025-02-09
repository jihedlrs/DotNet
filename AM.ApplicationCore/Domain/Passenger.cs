using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BrithDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public int id { get; set; }

        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public int TelNumber { get; set; }


        public ICollection<Flight> Flights { get; set; }



        //Polymorphisme par Signature

        public bool checkProfile(string nom, string prenom)
        {
            return nom == LastName && prenom == FirstName ;
        }

        public bool checkProfile(string nom,string prenom,string email)
        {
            return nom == LastName && prenom == FirstName && email.Equals(EmailAddress);
        }


        public bool checkProfile1(string nom, string prenom, string email=null)
        {
            if (email == null)

                return false;
            
            return nom == LastName && prenom == FirstName && email.Equals(EmailAddress);
        }
         


        //Polymorphysme par héritage

        public virtual void PassengerType()
        {

            Console.WriteLine("I'm Passenger");
        }

    }
}
