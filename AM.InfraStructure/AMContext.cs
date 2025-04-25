using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.InfraStructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AM.InfraStructure
{
    public class AMContext : DbContext
    {
        //1 DBSet
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Passenger> Passengers{ get; set; }
        public DbSet<Traveller> Travellers { get; set; }


        //2 chaine de connexion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
         Initial Catalog=AirportManagementDB;Integrated Security=true ; MultipleActiveResultSets=true"); 
            base.OnConfiguring(optionsBuilder); }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //1ere methode(avec classe de configuration)
            modelBuilder.ApplyConfiguration(new PlaneConfigration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());



            // Types d’entité détenus
            modelBuilder.Entity<Passenger>().OwnsOne(f => f.FullName, Full =>//2 émé methode de configuration type détenus
            {
                Full.Property(f => f.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                Full.Property(f => f.LastName).HasColumnName(" PassLastName").IsRequired();
            });




            //configuration TPH (Stratégies d’héritage) (1 ere methode regroupe les 3 tables au meme temps (seront mappées sur une seule table Passengers))

            //tu choisie soit  dans amcontexte ou bien dans un classe de configuration
            //modelBuilder.Entity<Passenger>().HasDiscriminator<int>("PassengerType")
            //    .HasValue<Passenger>(0)
            //    .HasValue<Staff>(1)
            //    .HasValue<Traveller>(2);






            //configuration TPT (Stratégies d’héritage)  (2 eme methode on a  chaque table separer c'est a dire chaque table seul( les entités seront  mappées sur 3 tables. (c'est a dire la table staff , table travellers,table passengers)
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("travellerss");




            //Configuration clé primare composé ( Table porteuse de données )

            modelBuilder.Entity<ReservationTicket>().HasKey(t => new
            {
                t.ticketfk,
                t.Passengersfk,
                t.DateReservation,//en ajoute daterseevation pour mieux comprendre  que l'affectation ne corespond a deux au meme temps comme l'exemple de cristiano il ne affecte pas au deux equipe au meme temps alors en ajout "datereservation" pour mieux separer a quel date par exemple affecte

            });


            //inser









            //2eme methode(sans classe de configuration)
            //modelBuilder.Entity<Plane>().HasKey(e=>e.PlaneId);
            //modelBuilder.Entity<Plane>().ToTable("myplane");
            //modelBuilder.Entity<Plane>().Property(e => e.Capacity).HasColumnName("PlaneCapacity");



        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");//modifier tous les proprietes de type dateTime je dit bien que tous le type datetime par "Date"
            //configurationBuilder.Properties<String>().HaveMaxLength(100);//Afficher tous le proprietes de taille max 100


        }


    }


}
