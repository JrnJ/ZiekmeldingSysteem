using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ZiekmeldingSysteem.Models
{
    public class ZiekmeldenDb : DbContext
    {
        public ZiekmeldenDb() 
            : base("name=ZiekmeldenDb") 
        { 
            
        }

        // Tables
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Remark> Remarks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
