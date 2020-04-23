using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>() ;
        public ICollection<Employee_Roll> Employee_Rolls { get; set; } = new HashSet<Employee_Roll>();
        public Department Department { get; set; } = null;


        public string Vorname { get; set; }
        public string Nachname { get; set; }


        [Column(TypeName = "decimal(9,2)")]
        public decimal Salary { get; set; }

    }
}
