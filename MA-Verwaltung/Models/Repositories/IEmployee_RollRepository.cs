using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models.Repositories
{
    public interface IEmployee_RollRepository
    {
        public IQueryable<Employee_Roll> Employee_Rolls { get; }

        public void saveEmployee_Roll(Employee_Roll Employee_Roll);
    }
}
