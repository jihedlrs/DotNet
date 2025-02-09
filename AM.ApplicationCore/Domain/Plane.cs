using System;
using System.Collections.Generic;
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

        public int Capacity {get; set;}//prop light version 
        public DateTime ManufactureDate { get; set; }
        public int Planeld { get; set; }

        public PlaneType PlaneType { get; set; }

        public ICollection<Flight> Flights { get; set; }


        //public override string ToString()
        //{
        //    return "Capacity : " + Capacity + " Manifacture  :" + ManufactureDate;
        //}



    }
}
