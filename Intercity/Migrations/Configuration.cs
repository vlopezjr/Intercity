namespace Intercity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Intercity.Models;
    using System.Data.SqlTypes;

    internal sealed class Configuration : DbMigrationsConfiguration<Intercity.Models.ManifestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Intercity.Models.ManifestContext context)
        {
            Customer customer = new Customer()
            {
                Name = "Best Brakes",
                Address1 = "100 Main Street",
                Address2 = "Ste 1A",
                City = "Ontario",
                State = "CA",
                Zip = "91780",
                PointOfContact = "Maria Gonzalez",
                EmailAddress = "mariag@bestbrakes.com",
                PrimaryPhone = "949-232-4455",
                SecondaryPhone = "800-232-8000" ,   
                Created = new DateTime(2016, 2, 1)
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            context.Drivers.AddOrUpdate(x=>x.Id,
                new Driver() { FirstName="Danny", LastName="Lopez", MiddleName="M", EmailAddress="dannyl@gmail.com", DateHired=new DateTime(2016, 2, 1), DateOfBirth=new DateTime(2016, 2, 1), Created=new DateTime(2016, 2, 1)},
                new Driver() { FirstName = "Victor", LastName = "Lopez", MiddleName = "M", EmailAddress = "victorl@gmail.com", DateHired = new DateTime(2016, 2, 1), DateOfBirth = new DateTime(2016, 2, 1), Created = new DateTime(2016, 2, 1) },
                new Driver() { FirstName = "Johnny", LastName = "Lopez", MiddleName = "C", EmailAddress = "johnnyl@gmail.com", DateHired = new DateTime(2016, 2, 1), DateOfBirth = new DateTime(2016, 2, 1), Created = new DateTime(2016, 2, 1) }
                );
            context.SaveChanges();

            Address pickupFrom = new Address()
            {
               CustomerId = customer.Id, PointOfContact="Jesse James", Address1="6042 Sultana Ave", City="Temple City", State="CA", Zip="91890", Name="Best Brakes - Temple City", Created=new DateTime(2016, 2, 1)
            };

            Address deliverTo = new Address()
            {
                CustomerId = customer.Id,
                PointOfContact = "Jessee Chu",
                Address1 = "877 Monterey Pass Road",
                City = "Monterey Park",
                State = "CA",
                Zip = "91754",
                Name = "Case Parts",
                Created = new DateTime(2016, 2, 1)
            };

            List<Parcel> parcels = new List<Parcel>();
            parcels.Add(new Parcel { Quantity=1, Type="Pallet", Description="Shampoo" });
            parcels.Add(new Parcel { Quantity = 2, Type = "Boxes", Description = "7x4 boxes" });

            Delivery delivery = new Delivery()
            {
                CustomerId = customer.Id,
                ManifestNo = "32232",
                CustomerRefNo="a1223",
                DeliveryDateTime = new DateTime(2016, 2, 1),
                //PickupAddressId = pickupFrom.Id,
                //DeliverToAddressId = deliverTo.Id,
                PickupAddress = pickupFrom,
                DeliverToAddress = deliverTo,
                Attention = "Chuck Norris",
                Comments = "testing",
                CodCharge = 0,
                Created = new DateTime(2016, 2, 1),
                DepartureTime = new DateTime(2016, 2, 1),
                ArrivalTime = new DateTime(2016, 2, 1),
                DriverId = context.Drivers.First().Id,
                DeliveryCharge = 2.50m,
                TotalCharge = 2.50m,
                Parcels = parcels,
                IsCod = false,
                IsRush = false,
                IsReg =true
                
            };

            context.Deliveries.Add(delivery);
            context.SaveChanges();
        }
    }
}
