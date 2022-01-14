using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZiekmeldingSysteem.Models
{
    public class Report
    {
        private int _id;

        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _dateFrom;

        [Required]
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        private DateTime? _dateTo;

        public DateTime? DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _employeeId;

        [Required]
        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        private DateTime? _dateExptected;

        public DateTime? DateExpected
        {
            get { return _dateExptected; }
            set { _dateExptected = value; }
        }

        private Employee _employee;

        [XmlIgnore]
        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }
    }
}
