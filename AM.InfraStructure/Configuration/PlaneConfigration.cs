using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.InfraStructure.Configuration
{
    public class PlaneConfigration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(e=>e.PlaneId);//equivalent au [key]
            builder.ToTable("MyPlane");//rename table
            builder.Property(e => e.Capacity).HasColumnName("PlaneCapacity");//rename column

        }
    }
}
