using Microsoft.EntityFrameworkCore;
using net_core_template_2025.Models;
using System;

namespace net_core_template_2025.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NegdbContext context;

        public EmployeeRepository(NegdbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = context.Employees.Select(x => new Employee
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
            });

            return await query.ToListAsync();
        }

        public async Task<Employee?> GetEmployee(int employeeId)
        {
            var query = context.Employees.Select(x => new Employee
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
            });

            return await query.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var result = await context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Address = employee.Address;
                result.BirthDate = employee.BirthDate;
                result.PhotoPath = employee.PhotoPath;

                await context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Employee?> DeleteEmployee(int employeeId)
        {
            var result = await context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                context.Employees.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
