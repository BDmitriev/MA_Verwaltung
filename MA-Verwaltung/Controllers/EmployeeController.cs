using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MA_Verwaltung.Models;
using MA_Verwaltung.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MA_Verwaltung.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository employeesRepo;
        private readonly IEmployee_RollRepository erRepo;

        public EmployeeController(IEmployeeRepository employeesRepo, IEmployee_RollRepository erRepo)
        {
            this.employeesRepo = employeesRepo;
            this.erRepo = erRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> temp = employeesRepo.Employees;

            return View(temp);
        }


        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp, string Abteilung, string Beruf, string Fachgebiet, string Zuständigkeiten, List<String> Addresses)
        {
            String[] ZArray = Zuständigkeiten.Split(",");

             emp.Addresses.Add( new Address { 
                                             Strasse = Addresses[0],
                                             Plz     = Addresses[1],
                                             Stadt   = Addresses[2],
                                             Land    = Addresses[3],
             } );

            emp.Department = new Department { Bezeichnung = Abteilung };

            employeesRepo.saveEmployee(emp);

            foreach (var item in ZArray)
            {
                Employee_Roll er = new Employee_Roll
                {
                    Employee = emp,
                    Roll = new Roll
                    {
                        Occupation = Beruf,
                        Fachgebiet = Fachgebiet,
                        Rolle = item
                    }
                };

                erRepo.saveEmployee_Roll(er);
            }

            return RedirectToAction(nameof(Index));
        }



    }
}