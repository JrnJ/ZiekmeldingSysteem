using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiekmeldingSysteem.Models
{
    public class Role
    {
        private int _id;

        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        [Required]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
