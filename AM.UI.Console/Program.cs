// See https://aka.ms/new-console-template for more information

using System;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Console.WriteLine("Hello, World!");

//Plane p0 = new Plane(12,new DateTime(2025,03,03),1,PlaneType.Airbus); ///Constructeur parametrer
//Console.WriteLine(p0.ToString());

Plane p1 = new Plane { Capacity=100, PlaneType=PlaneType.Airbus }; // initialiser sans faire un constructeur
Console.WriteLine(p1.Capacity);

Passenger p2 = new Passenger { LastName = "jiji", FirstName = "aaa" };//tester la methode check pour verifier (nom,prenom)==nom,prenom,
Console.WriteLine("Test CheckProfile  " + p2.checkProfile("jiji", "aaa"));


Passenger p3 = new Passenger { LastName = "jiji", FirstName = "aaa" ,EmailAddress="aaa@gmail.com"};//tester la methode check pour verifier (nom,prenom,email)==nom,prenom,email
Console.WriteLine("Test CheckProfile  " + p3.checkProfile("jiji", "aaa","aaa@gmail.com"));


Console.WriteLine("Test CheckProfile1 " + p3.checkProfile1("jiji", "aaa", "aaa@gmail.com"));//tester avec la nouvelle methode qui simuler les deux autre methode precedente(retourne true car email existe)
Console.WriteLine("Test CheckProfile1 " + p3.checkProfile1("jiji", "aaa"));//retourne false car emila n'est pas dispo


p3.PassengerType();

Staff s = new Staff();
 
s.PassengerType();

Traveller tr = new Traveller();
tr.PassengerType();

FlightMethods f1 = new FlightMethods();
f1.Flights = TestData.listFlights;
foreach(var item in f1.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}



Console.WriteLine(" les dates et les destinations des vols d’un avion::::");
f1.ShowFlightDetails(TestData.Airbusplane);



DateTime startDate = new DateTime(2022, 02, 01); 
int X = f1.ProgrammedFlightNumber(startDate);
Console.WriteLine("Nombre de vols programmés : " + X);






int x = f1.DurationAverage("Paris");
Console.WriteLine("Durée moyenne des vols " + "Paris" + " : " + x );



var orderedFlights = f1.OrderedDurationFlights();

foreach (var flight in orderedFlights)
{
    Console.WriteLine("les Vols ordonnés"+flight.Destination + flight.EstimatedDuration);
}

Flight F2 = TestData.flight1; 


var seniorTravellers = f1.SeniorTravellers(F2);

foreach (var traveller in seniorTravellers)
{
    Console.WriteLine(traveller.FirstName + traveller.LastName );
}


