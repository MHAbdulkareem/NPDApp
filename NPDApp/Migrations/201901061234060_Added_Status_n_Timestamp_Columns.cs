namespace NPDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Status_n_Timestamp_Columns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaffJobs",
                c => new
                    {
                        Staff_ID = c.Int(nullable: false),
                        Job_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Staff_ID, t.Job_ID })
                .ForeignKey("dbo.Staffs", t => t.Staff_ID, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_ID, cascadeDelete: true)
                .Index(t => t.Staff_ID)
                .Index(t => t.Job_ID);
            
            AddColumn("dbo.Clients", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Jobs", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Machines", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Timelines", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Staffs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffJobs", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.StaffJobs", "Staff_ID", "dbo.Staffs");
            DropIndex("dbo.StaffJobs", new[] { "Job_ID" });
            DropIndex("dbo.StaffJobs", new[] { "Staff_ID" });
            DropColumn("dbo.Staffs", "RowVersion");
            DropColumn("dbo.Timelines", "RowVersion");
            DropColumn("dbo.Machines", "RowVersion");
            DropColumn("dbo.Jobs", "RowVersion");
            DropColumn("dbo.Jobs", "Status");
            DropColumn("dbo.Clients", "RowVersion");
            DropTable("dbo.StaffJobs");
        }
    }
}
