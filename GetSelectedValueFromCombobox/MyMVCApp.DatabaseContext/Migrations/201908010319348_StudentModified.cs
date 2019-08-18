namespace MyMVCApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Contact", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Contact");
        }
    }
}
