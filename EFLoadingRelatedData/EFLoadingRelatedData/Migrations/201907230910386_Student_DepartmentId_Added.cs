namespace EFLoadingRelatedData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_DepartmentId_Added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Students", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DepartmentId");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.Students", "Department_Id");
            AddForeignKey("dbo.Students", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
