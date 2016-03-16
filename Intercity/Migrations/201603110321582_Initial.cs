namespace Intercity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        PointOfContact = c.String(),
                        PrimaryPhone = c.String(),
                        SecondaryPhone = c.String(),
                        EmailAddress = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerRefNo = c.String(),
                        RefNo = c.Int(nullable: false),
                        DeliveryCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeightCharge = c.Decimal(precision: 18, scale: 2),
                        ReturnCharge = c.Decimal(precision: 18, scale: 2),
                        WaitingTimeCharge = c.Decimal(precision: 18, scale: 2),
                        CodCharge = c.Decimal(precision: 18, scale: 2),
                        TotalCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArrivalTime = c.DateTime(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        DeliveryDateTime = c.DateTime(nullable: false),
                        IsPrepaid = c.Boolean(nullable: false),
                        IsReg = c.Boolean(nullable: false),
                        IsRush = c.Boolean(nullable: false),
                        IsCod = c.Boolean(nullable: false),
                        ReceivedBy = c.String(),
                        Created = c.DateTime(nullable: false),
                        Attention = c.String(),
                        Comments = c.String(),
                        CustomerId = c.Int(nullable: false),
                        PickupId = c.Int(),
                        ReceiverId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Pickups", t => t.PickupId)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.PickupId)
                .Index(t => t.ReceiverId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        HomePhone = c.String(),
                        MobilePhone = c.String(),
                        EmailAddress = c.String(),
                        Social = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateHired = c.DateTime(nullable: false),
                        HourlyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Freights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Type = c.String(),
                        Description = c.String(),
                        Weight = c.String(),
                        Delivery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deliveries", t => t.Delivery_Id)
                .Index(t => t.Delivery_Id);
            
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        PointOfContact = c.String(),
                        PrimaryPhone = c.String(),
                        EmailAddress = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        PointOfContact = c.String(),
                        PrimaryPhone = c.String(),
                        EmailAddress = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "ReceiverId", "dbo.Receivers");
            DropForeignKey("dbo.Receivers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Deliveries", "PickupId", "dbo.Pickups");
            DropForeignKey("dbo.Pickups", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Freights", "Delivery_Id", "dbo.Deliveries");
            DropForeignKey("dbo.Deliveries", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Deliveries", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Receivers", new[] { "CustomerId" });
            DropIndex("dbo.Pickups", new[] { "CustomerId" });
            DropIndex("dbo.Freights", new[] { "Delivery_Id" });
            DropIndex("dbo.Deliveries", new[] { "DriverId" });
            DropIndex("dbo.Deliveries", new[] { "ReceiverId" });
            DropIndex("dbo.Deliveries", new[] { "PickupId" });
            DropIndex("dbo.Deliveries", new[] { "CustomerId" });
            DropTable("dbo.Receivers");
            DropTable("dbo.Pickups");
            DropTable("dbo.Freights");
            DropTable("dbo.Drivers");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Customers");
        }
    }
}
