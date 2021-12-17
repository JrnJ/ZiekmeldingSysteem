namespace ZiekmeldingSysteem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeereports : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reports", "EmployeeId");
            AddForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Reports", new[] { "EmployeeId" });
        }
    }
}
