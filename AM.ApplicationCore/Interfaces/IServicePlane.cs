using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        bool Reserver(Flight f, int n);

        void deletePlane();

        Dictionary<DateTime, int> GetPassengerByFlightDate(DateTime startDate, DateTime endDate);


    }
}
