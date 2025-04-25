//// See https://aka.ms/new-console-template for more information
using System;
//using AM.ApplicationCore.Domain;
//using AM.ApplicationCore.Services;
//using AM.InfraStructure;

Console.WriteLine("Hello, World!");

////Plane p0 = new Plane(12,new DateTime(2025,03,03),1,PlaneType.Airbus); ///Constructeur parametrer
////Console.WriteLine(p0.ToString());

//Plane p1 = new Plane { Capacity=100, PlaneType=PlaneType.Airbus }; // initialiser sans faire un constructeur
//Console.WriteLine(p1.Capacity);

//Passenger p2 = new Passenger { FullName=new FullName { LastName = "jiji", FirstName = "aaa" } };//tester la methode check pour verifier (nom,prenom)==nom,prenom,
//Console.WriteLine("Test CheckProfile  " + p2.checkProfile("jiji", "aaa"));


//Passenger p3 = new Passenger { FullName=new FullName { LastName = "jiji", FirstName = "aaa" } ,EmailAddress="aaa@gmail.com"};//tester la methode check pour verifier (nom,prenom,email)==nom,prenom,email
//Console.WriteLine("Test CheckProfile  " + p3.checkProfile("jiji", "aaa","aaa@gmail.com"));


//Console.WriteLine("Test CheckProfile1 " + p3.checkProfile1("jiji", "aaa", "aaa@gmail.com"));//tester avec la nouvelle methode qui simuler les deux autre methode precedente(retourne true car email existe)
//Console.WriteLine("Test CheckProfile1 " + p3.checkProfile1("jiji", "aaa"));//retourne false car emila n'est pas dispo


//p3.PassengerType();


//Staff s = new Staff();
//s.PassengerType();


//Traveller tr = new Traveller();
//tr.PassengerType();

//Console.WriteLine("***Methode  GetFlightDates");
////FlightMethods f1 = new FlightMethods();
////f1.Flights = TestData.listFlights;
////foreach(var item in f1.GetFlightDates("Paris"))
////{
////    Console.WriteLine(item);
////}

/////

//Console.WriteLine("*** Methode GetFlights ***");
//foreach (var item in f1.GetFlights("EstimatedDuration", "200"))
//{
//    Console.WriteLine(item.EstimatedDuration);
//}



////

//Console.WriteLine("***Methode ShowFlightDetails");
//f1.ShowFlightDetails(TestData.Airbusplane);

////

//Console.WriteLine("***Methode  ProgrammedFlightNumber");
//Console.WriteLine("Programmes flighrsNumber"+f1.ProgrammedFlightNumber(new DateTime(2022, 02, 01)));

////
//Console.WriteLine("***Methode  DurationAverage");
//Console.WriteLine("Durée moyenne des vols "+f1.DurationAverage("Madrid"));

////

//Console.WriteLine("***Methode  OrderedDurationFlights");
//foreach (var  item in f1.OrderedDurationFlights())
//{
//    Console.WriteLine(item.Destination+item.EstimatedDuration);
//}

////

//Console.WriteLine("***Methode  SeniorTravellers");
//foreach (var item in f1.SeniorTravellers(TestData.flight1))
//{
//    Console.WriteLine(item.BrithDate);
//}

////

//Console.WriteLine("***Methode  DestinationGroupFlihghts");
//Console.WriteLine(f1.DestinationGroupFlihghts());


//p3.UpperFullName();
//Console.WriteLine(p3.FullName.FirstName + " " + p3.FullName.LastName);

//AMContext a =new AMContext();
////a.Planes.Add(TestData.BoingPlane);
////a.Flights.Add(TestData.flight2);
//a.SaveChanges();
//Console.WriteLine("Ajout avec success");

//foreach (var item in a.Flights)
//    Console.WriteLine(item.Destination + item.plane.Capacity);









