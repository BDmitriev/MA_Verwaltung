using MA_Verwaltung.Models.Db_Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Employee> Employees => context.Employees.Include(Employees => Employees.Addresses)
                                                                  .Include(Employees => Employees.Department)
                                                                  .Include(Employee => Employee.Employee_Rolls)
                                                                  .ThenInclude(Employee_Rolls => Employee_Rolls.Roll);

        public void saveEmployee(Employee e)
        {
            context.Employees.Add(e);
            context.SaveChanges();
        }
    }
}
