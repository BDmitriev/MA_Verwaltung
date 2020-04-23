using MA_Verwaltung.Models.Db_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models.Repositories
{
    public class Employee_RollRepository : IEmployee_RollRepository
    {
        private ApplicationDbContext context;
        public Employee_RollRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Employee_Roll> Employee_Rolls => context.Employee_Rolls;

        public void saveEmployee_Roll(Employee_Roll er)
        {
            context.Employee_Rolls.Add(er);
            context.SaveChanges();
        }
    }
}
