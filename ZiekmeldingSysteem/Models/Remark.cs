using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiekmeldingSysteem.Models
{
    public class Remark
    {
        private int _id;

        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _extraRemark;

        [Required]
        public string ExtraRemark
        {
            get { return _extraRemark; }
            set { _extraRemark = value; }
        }

        private DateTime _date;

        [Required]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _employeeId;

        [Required]
        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        private int _reportId;

        [Required]
        public int ReportID
        {
            get { return _reportId; }
            set { _reportId = value; }
        }
    }
}
