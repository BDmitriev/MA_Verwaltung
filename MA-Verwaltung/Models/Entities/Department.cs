using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>() ;

        public string Bezeichnung { get; set; }
    }
}
