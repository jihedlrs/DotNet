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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(t => t.ToTable("FP"));//Rename table association

            builder.HasOne(f=>f.plane)
                .WithMany(p=>p.Flights)
                .HasForeignKey(p=>p.planefk)//[forignKey]
                .OnDelete(DeleteBehavior.Cascade);
                




        }
    }
}
