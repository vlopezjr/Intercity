using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Intercity.Models
{
    public class ManifestRepository : IDisposable
    {
        private ManifestContext _context;

        public ManifestRepository()     
            : this (new ManifestContext()) {}
       
        public ManifestRepository(ManifestContext context) 
        {
            _context = context;
        }

        public List<Delivery> GetAllDeliveries()
        {
            return _context.Deliveries
                .Include(p => p.Customer)
                .Include(p => p.Driver)
                .Include(p => p.Parcels)
                .ToList();
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public void AddCustomer(Customer Customer)
        {
            _context.Customers.Add(Customer);
            _context.SaveChanges();
        }

        public List<Address> GetAllAddressesForCustomer(int CustomerId)
        {
            return _context.Addresses.Where(p=>p.CustomerId==CustomerId).ToList();
        }

        public Address GetPickupById(int id)
        {
            return _context.Addresses.Find(id);
        }

        public void AddPickup(Address pickup)
        {
            _context.Addresses.Add(pickup);
            _context.SaveChanges();
        }      

        public void AddDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }
        
      

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}