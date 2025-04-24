using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
    //[Owned] 1 ere methode de   typedétenus
    public class FullName
    {
        [MinLength(3, ErrorMessage = "les regles ne sont pas respectés"), MaxLength(25, ErrorMessage = "les regles ne sont pas respectés")]

        public string FirstName { get; set; }
        //public int id { get; set; }

        public string LastName { get; set; }
    }
}
