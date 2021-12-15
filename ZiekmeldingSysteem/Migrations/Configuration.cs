namespace ZiekmeldingSysteem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZiekmeldingSysteem.Models.ZiekmeldenDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZiekmeldingSysteem.Models.ZiekmeldenDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Create Roles
            Role adminRole = context.Roles.Add(new Role() { Name = "Admin" });
            Role managerRole = context.Roles.Add(new Role() { Name = "Manager" });
            Role workerRole = context.Roles.Add(new Role() { Name = "Worker" });
            context.SaveChanges();

            // Create Employee
            Employee employee = context.Employees.Add(new Employee() { Fullname = "Jeroen Jochems", RoleId = managerRole.Id });
            context.SaveChanges();

            // Create Department
            Department department = context.Departments.Add(new Department() { Name = "Jeroen Inc.", DepartmentManagerId = employee.Id });
            context.SaveChanges();

            // Set employee's department
            context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault().DepartmentId = department.Id;

            // Create a sick worker
            Employee worker = context.Employees.Add(new Employee() { Fullname = "Roderick Jansen", DepartmentId = department.Id, RoleId = workerRole.Id });
            context.SaveChanges();

            // Create report for worker
            Report report = context.Reports.Add(new Report() 
            { 
                EmployeeId = worker.Id,
                DateFrom = new DateTime(2021, 12, 1),
                Description = "Furry festival (:",
                DateExpected = new DateTime(2021, 12, 30),
            });

            // Create report for worker
            Remark remark = context.Remarks.Add(new Remark() 
            { 
                ReportID = report.Id, 
                EmployeeId = worker.Id, 
                ExtraRemark = "UwU", 
                Date = new DateTime(2021, 12, 1)
            });

            // Create admin
            Employee admin = context.Employees.Add(new Employee() { Fullname = "Root Root", RoleId = adminRole.Id });
            context.SaveChanges();
        }
    }
}
