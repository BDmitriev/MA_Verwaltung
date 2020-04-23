using MA_Verwaltung.Models.Db_Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MA_Verwaltung.Models.Seed_Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Employees.Any())
            {
                // John
                Employee john = new Employee
                {
                    Vorname = "John",
                    Nachname = "Doe",
                    Salary = (decimal) 2700.99
                };

                Address johnAddress = new Address {
                                                Strasse = "TestStraße 1",
                                                Plz = "11111",
                                                Stadt = "Berlin",
                                                Land = "Deutschland"
                                            };

                john.Addresses.Add(johnAddress);


                // Michael
                Employee michael = new Employee
                {
                    Vorname  = "Michael",
                    Nachname = "Johnson",
                    Salary   =  (decimal) 4000.99
                };

                Address michaelAddress = new Address
                {
                    Strasse = "TestStraße 2",
                    Plz = "22222",
                    Stadt = "Düsseldorf",
                    Land = "Deutschland"
                };

                michael.Addresses.Add(michaelAddress);

                // Sandra
                Employee sandra = new Employee
                {
                    Vorname = "Sandra",
                    Nachname = "Williams",
                    Salary = (decimal) 3000.99
                };

                Address sandraAddress = new Address
                {
                    Strasse = "TestStraße 3",
                    Plz = "33333",
                    Stadt = "Krefeld",
                    Land = "Deutschland"
                };

                sandra.Addresses.Add( sandraAddress );


                // Amanda
                Employee amanda = new Employee
                {
                    Vorname = "Amanda",
                    Nachname = "Adley",
                    Salary = (decimal) 2000.99
                };

                Address amandaAddress = new Address
                {
                    Strasse = "TestStraße 4",
                    Plz = "44444",
                    Stadt = "Essen",
                    Land = "Deutschland"
                };

                amanda.Addresses.Add( amandaAddress );


                // Billy
                Employee billy = new Employee
                {
                    Vorname = "Billy",
                    Nachname = "Martin",
                    Salary = (decimal) 3500.42
                };

                Address billyAddress = new Address
                {
                    Strasse = "TestStraße 5",
                    Plz = "55555",
                    Stadt = "Münster",
                    Land = "Deutschland"
                };

                billy.Addresses.Add( billyAddress );



                // Rollenzuweisung
                Employee_Roll er1 = new Employee_Roll();
                Employee_Roll er2 = new Employee_Roll();
                Employee_Roll er3 = new Employee_Roll();
                Employee_Roll er4 = new Employee_Roll();
                Employee_Roll er5 = new Employee_Roll();
                Employee_Roll er6 = new Employee_Roll();

                Roll rolle1 = new Roll { 
                                   Occupation = "Arzt",
                                   Rolle = "Chefarzt",
                                   Fachgebiet = "innere Medizin"
                                };

                Roll rolle2 = new Roll
                {
                    Occupation = "Arzt",
                    Rolle = "Vorsitzender des Wissenschaftsrats",
                    Fachgebiet = "innere Medizin"
                };

                Roll rolle3 = new Roll
                {
                    Occupation = "Arzt",
                    Rolle = "Ärzlicher Direktor",
                    Fachgebiet = "innere Medizin"
                };

                Roll rolle4 = new Roll
                {
                    Occupation = "Arzt",
                    Rolle = "Facharzt",
                    Fachgebiet = "innere Medizin"
                };

                Roll rolle5 = new Roll
                {
                    Occupation = "Arzt",
                    Rolle = "Facharzt",
                    Fachgebiet = "Gastroenterologie"
                };

                er1.Employee = john;
                er1.Roll = rolle1;
                er2.Employee = john;
                er2.Roll = rolle2;

                er3.Employee = michael;
                er3.Roll = rolle3;

                er4.Employee = sandra;
                er4.Roll = rolle4;

                er5.Employee = amanda;
                er5.Roll = rolle5;

                er6.Employee = billy;
                er6.Roll = rolle5;

                // Abteilungen
                Department d1 = new Department { Bezeichnung = "Innere Medizin" };
                Department d2 = new Department { Bezeichnung = "Gastroenterologie" };
                d1.Employees.Add(john);
                d1.Employees.Add(michael);
                d1.Employees.Add(sandra);
                d2.Employees.Add(amanda);
                d2.Employees.Add(billy);

                // Abteilungen dem Context hinzufügen
                context.Department.AddRange(
                    d1,
                    d2
                );

                // Mitarbeiter dem Context hinzufügen
                context.Employees.AddRange(
                    john,
                    michael,
                    sandra,
                    amanda,
                    billy
                );

                // Rollen dem Context hinzufügen
                context.Employee_Rolls.AddRange(
                    er1,
                    er2,
                    er3,
                    er4,
                    er5,
                    er6
                );

                context.SaveChanges();
            }
        }


    }
}

