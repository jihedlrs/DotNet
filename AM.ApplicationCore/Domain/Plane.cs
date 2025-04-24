using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        //public Plane(int capacity, DateTime manufactureDate, int planeld, PlaneType planeType)
        //{
        //    Capacity = capacity;
        //    ManufactureDate = manufactureDate;
        //    Planeld = planeld;
        //    PlaneType = planeType;
        //}

        [Range(0, int.MaxValue)]
        public int Capacity {get; set;}//prop light version 
        public DateTime ManufactureDate { get; set; }

        [Key]
        public int PlaneId { get; set; }

        public PlaneType PlaneType { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }


        //public override string ToString()
        //{
        //    return "Capacity : " + Capacity + " Manifacture  :" + ManufactureDate;
        //}



    }
}
