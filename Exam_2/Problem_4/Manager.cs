using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_4
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public Department department { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
