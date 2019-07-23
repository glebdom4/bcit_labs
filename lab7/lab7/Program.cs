using System;
using System.Linq;
using System.Collections.Generic;

namespace lab7
{
    class Lab
    {
        class Employee
        {
            public int Id { get; set; }
            public string Surname { get; set; }
            public int DivisionId { get; set; }

            public override string ToString()
            {
                return $"Сотрудник {Surname} ID={Id}";
            }
        }

        class Division
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"Отдел {Name} Id={Id}";
            }
        }

        class EmployeeToDivisionMap
        {
            public int EmployeeId { get; set; }
            public int DivisionId { get; set; }
        }

        static void Main()
        {
            var emplos = new List<Employee> {
                new Employee() { Id = 1, Surname = "Иванов", DivisionId = 1 },
                new Employee() { Id = 2, Surname = "Сидоров", DivisionId = 1 },
                new Employee() { Id = 5, Surname = "Абаев", DivisionId = 1 },
                new Employee() { Id = 3, Surname = "Ануфриев", DivisionId = 2 },
                new Employee() { Id = 4, Surname = "Антонов", DivisionId = 2 }
            };
            var divs = new List<Division> {
                new Division() { Id = 1, Name = "Test 1" },
                new Division() { Id = 2, Name = "Not a test 2" }
            };

            Console.WriteLine("Все сотрудники и отделы, отсортированные по отделам:");
            Console.WriteLine("=== Сотрудники ===");
            emplos.OrderBy(em => em.DivisionId).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("=== Отделы ===");
            divs.OrderBy(x => x.Id).ToList().ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Все сотрудники, фамилия которых начинается на А");
            emplos.Where(x => x.Surname.StartsWith("А")).ToList().ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Список всех отделов и кол-во сотрудиников в них:");
            divs.ForEach(d => {
                Console.WriteLine(d);
                Console.WriteLine("Кол-во сотрудников: {0}", emplos.Where(x => x.DivisionId == d.Id).Count());
            });

            Console.WriteLine();
            Console.WriteLine("Отделы, в которых у всех сотрудников фамилия начинается на А:");
            divs.Where(d => emplos.Where(e => e.DivisionId == d.Id).All(e => e.Surname.StartsWith("А"))).ToList().ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Отделы, в которых у хотя бы одного сотрудника фамилия начинается на А:");
            divs.Where(d => emplos.Where(e => e.DivisionId == d.Id).Any(e => e.Surname.StartsWith("А"))).ToList().ForEach(Console.WriteLine);

            var emplToDivsMap = new List<EmployeeToDivisionMap> {
                new EmployeeToDivisionMap() { EmployeeId = 1, DivisionId = 1 },
                new EmployeeToDivisionMap() { EmployeeId = 1, DivisionId = 2 },
                new EmployeeToDivisionMap() { EmployeeId = 2, DivisionId = 2 },
                new EmployeeToDivisionMap() { EmployeeId = 2, DivisionId = 1 },
                new EmployeeToDivisionMap() { EmployeeId = 3, DivisionId = 2 },
                new EmployeeToDivisionMap() { EmployeeId = 4, DivisionId = 1 },
                new EmployeeToDivisionMap() { EmployeeId = 5, DivisionId = 2 }
            };

            Console.WriteLine();
            Console.WriteLine("Список всех отделов и список сотрудников в каждом отделе:");

            var ms = from m in emplToDivsMap
                     join mapO in divs on m.DivisionId equals mapO.Id
                     join mapO2 in emplos on m.EmployeeId equals mapO2.Id
                     group mapO2 by mapO2.DivisionId;

            ms.ToList().ForEach(divi => {
                Console.WriteLine(divs.Where(d => d.Id == divi.Key).Single());
                Console.WriteLine(divi.Count());
            });

            Console.ReadKey();
        }
    }

}
