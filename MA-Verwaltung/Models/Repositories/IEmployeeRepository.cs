using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models.Repositories
{
    public interface IEmployeeRepository
    {
        public IQueryable<Employee> Employees { get; }

        public void saveEmployee (Employee Employee);
    }
}
