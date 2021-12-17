using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZiekmeldingSysteem.Models;
using System.Data.Entity;

namespace ZiekmeldingSysteem.Classes
{
    public static class Db
    {
        // public:
        public static Employee Login(string fullname, string password = "")
        {
            try
            {
                using (ZiekmeldenDb ziekmeldenDb = new ZiekmeldenDb())
                {
                    return ziekmeldenDb.Employees.FirstOrDefault(x => x.Fullname == fullname);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("*********************************************************\nERROR: " + ex.Message);
                return null;
            }
        }

        public static string GetRoleById(int id)
        {
            try
            {
                using (ZiekmeldenDb ziekmeldenDb = new ZiekmeldenDb())
                {
                    return ziekmeldenDb.Roles.FirstOrDefault(x => x.Id == id).Name;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ObservableCollection<Report> GetReportsById(int id)
        {
            try
            {
                using (ZiekmeldenDb ziekmeldenDb = new ZiekmeldenDb())
                {
                    ObservableCollection<Report> reports = new ObservableCollection<Report>();

                    foreach (Report report in ziekmeldenDb.Reports.Include(x => x.Employee))
                    {
                        if (report.EmployeeId == id)
                        {
                            reports.Add(report);
                        }
                    }

                    return reports;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool AddReport(Report report)
        {
            try
            {
                // Add user
                using (ZiekmeldenDb ziekmeldenDb = new ZiekmeldenDb())
                {
                    // Add report
                    ziekmeldenDb.Reports.Add(report);
                    ziekmeldenDb.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ChangeReportStatus(int id)
        {
            try
            {
                using (ZiekmeldenDb ziekmeldenDb = new ZiekmeldenDb())
                {
                    Report report = ziekmeldenDb.Reports.FirstOrDefault(x => x.Id == id);

                    if (report != null)
                    {
                        ziekmeldenDb.Reports.Remove(report);
                        ziekmeldenDb.SaveChanges();

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static ObservableCollection<Employee> GetDepartmentEmployees(int id)
        {
            try
            {
                using (ZiekmeldenDb ziekmeldenDb = new ZiekmeldenDb())
                {
                    ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

                    foreach (Employee employee in ziekmeldenDb.Employees)
                    {
                        if (employee.DepartmentId == id)
                        {
                            employees.Add(employee);
                        }
                    }

                    return employees;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
