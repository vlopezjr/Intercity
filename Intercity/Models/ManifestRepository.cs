using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intercity.Models
{
    public class ManifestRepository : IDisposable
    {
        private ManifestContext _context;

        public ManifestRepository(ManifestContext context)
        {
            _context = context;
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

        public List<Pickup> GetAllPickupsForCustomer(int CustomerId)
        {
            return _context.Pickups.Where(p=>p.CustomerId==CustomerId).ToList();
        }

        public Pickup GetPickupById(int id)
        {
            return _context.Pickups.Find(id);
        }

        public void AddPickup(Pickup pickup)
        {
            _context.Pickups.Add(pickup);
            _context.SaveChanges();
        }      

        public void AddDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }
        
        public List<Receiver> GetAllReceiversForCustomer(int CustomerId)
        {
            return _context.Receivers.Where(p => p.CustomerId == CustomerId).ToList();
        }

        public Receiver GetReceiverById(int id)
        {
            return _context.Receivers.Find(id);
        }

        public void AddReceiver(Receiver receiver)
        {
            _context.Receivers.Add(receiver);
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