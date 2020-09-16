using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var databaseContext = new DatabaseContext();

            //-----------------CRUD Operations Using Code First technique-------------

            CreateData(databaseContext);
            //ReadData(databaseContext, 2);
            //UpdateData(databaseContext, 2);
            //DeleteData(databaseContext, 2);

        }

        public static Employee GetEmployee(DatabaseContext context, int Id)
        {
            var emp = context.Employees.Where(x => x.Id == Id).FirstOrDefault();
            return emp;
        }

        public static void ReadData(DatabaseContext context, int Id)
        {
            var emp = GetEmployee(context, Id);
            Console.WriteLine("Name: "+emp.Name);
            Console.WriteLine("Contact: "+emp.Contact);
            Console.WriteLine("Email: "+emp.Email);
        }

        public static void UpdateData(DatabaseContext context, int Id)
        {
            var emp = GetEmployee(context, Id);
            emp.Email = "example@gmail.com";
            context.SaveChanges();
        }

        public static void DeleteData(DatabaseContext context, int Id)
        {
            var emp = GetEmployee(context, Id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }

        public static void CreateData(DatabaseContext context)
        {
            var department1 = new Department
            {
                departmentName = "IT",
                deptDetail = "All IT Related Works",
            };

            var manager1 = new Manager
            {
                Name = "Md. Araf Hasan",
                Contact = "01863666925",
                Email = "araf.hasan15@gmail.com",
                department = department1,
            };

            var employee1 = new Employee
            {
                Name = "Jakir Hossain",
                Contact = "01765434542",
                Email = "jakir@gmail.com",
            };
            var employee2 = new Employee
            {
                Name = "Kallol Hasan",
                Contact = "01765453456",
                Email = "kallol@gmail.com",
            };

            manager1.Employees = new List<Employee>();
            manager1.Employees.Add(employee1);
            manager1.Employees.Add(employee2);

            context.Departments.Add(department1);
            context.Managers.Add(manager1);
            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            context.SaveChanges();
        }
    }
}
