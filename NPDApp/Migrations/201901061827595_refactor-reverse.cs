namespace NPDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorreverse : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Machines", "MachineType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Machines", "MachineType", c => c.Int(nullable: false));
        }
    }
}
