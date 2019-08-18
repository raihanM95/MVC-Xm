namespace EFLoadingRelatedData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_IsActive_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "IsActive");
        }
    }
}
