using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZiekmeldingSysteem.Models
{
    public class Employee
    {
        private int _id;

        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _fullname;

        [Required]
        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        private int _roleId;

        [Required]
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        private int _departmentId;

        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }

        private ICollection<Report> _reports;

        [XmlIgnore]
        public ICollection<Report> Reports
        {
            get { return _reports; }
            set { _reports = value; }
        }
    }
}
