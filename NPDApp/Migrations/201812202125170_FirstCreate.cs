namespace NPDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumberOrName = c.String(),
                        Street = c.String(),
                        Town = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        LoggedDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Urgency = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        MachineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Machines", t => t.MachineID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.MachineID);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Manufacturer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Timelines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Outcome = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.JobID, cascadeDelete: true)
                .Index(t => t.JobID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Role = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timelines", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "MachineID", "dbo.Machines");
            DropForeignKey("dbo.Jobs", "ClientID", "dbo.Clients");
            DropIndex("dbo.Timelines", new[] { "JobID" });
            DropIndex("dbo.Jobs", new[] { "MachineID" });
            DropIndex("dbo.Jobs", new[] { "ClientID" });
            DropTable("dbo.Staffs");
            DropTable("dbo.Timelines");
            DropTable("dbo.Machines");
            DropTable("dbo.Jobs");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
