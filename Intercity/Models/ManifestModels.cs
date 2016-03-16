namespace Intercity.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cust#")]
        public string CustomerRefNo { get; set; }
        [Display(Name = "Ref.No.")]
        public string ManifestNo { get; set; }
        [Display(Name = "Delivery Charges")]
        public decimal DeliveryCharge { get; set; }
        [Display(Name = "Weight Charge")]
        public decimal? WeightCharge { get; set; }
        [Display(Name = "Return Charges")]
        public decimal? ReturnCharge { get; set; }
        [Display(Name = "Waiting Time")]
        public decimal? WaitingTimeCharge { get; set; }
        [Display(Name = "C.O.D Charge")]
        public decimal? CodCharge { get; set; }
        [Display(Name = "Total Charges")]
        public decimal TotalCharge { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime DepartureTime { get; set; }
        [Display(Name = "Date")]
        public DateTime DeliveryDateTime { get; set; }
        [Display(Name = "Prepaid")]
        public bool IsPrepaid { get; set; }
        [Display(Name = "reg.")]
        public bool IsReg { get; set; }
        [Display(Name = "Rush")]
        public bool IsRush { get; set; }
        [Display(Name = "C.O.D.")]
        public bool IsCod { get; set; }
        public string ReceivedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Created { get; set; }
        public String Attention { get; set; }
        public String Comments { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int? PickupAddressId { get; set; }
        [ForeignKey("PickupAddressId")]
        public virtual Address PickupAddress { get; set; }
        public int DeliverToAddressId { get; set; }
        [ForeignKey("DeliverToAddressId")]
        public virtual Address DeliverToAddress { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public ICollection<Parcel> Parcels { get; set; }
    }
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Social { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateHired { get; set; }
        public decimal HourlyRate { get; set; }
        public DateTime Created { get; set; }
    }
    public class Customer 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PointOfContact { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PointOfContact { get; set; }
        public string PrimaryPhone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Created { get; set; }
    } 
    public class Parcel
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
    }
}