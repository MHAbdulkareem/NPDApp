namespace NPDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EndDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
