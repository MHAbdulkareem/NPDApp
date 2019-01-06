namespace NPDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "MachineType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Machines", "MachineType");
        }
    }
}
