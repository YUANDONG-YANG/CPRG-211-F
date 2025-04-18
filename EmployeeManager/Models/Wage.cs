using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Wage
    {
        public int grade_id { get; set; }
        public string grade_name { get; set; }
        public decimal base_wage { get; set; }
        public decimal bonus_percent { get; set; }
    }
}
