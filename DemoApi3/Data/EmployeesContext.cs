using DemoApi3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace DemoApi3.Data
{
    public class EmployeesContext: DbContext
    {
        
        public DbSet<Employee> Employees { get; set; }

        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        {

        }

    }
}
