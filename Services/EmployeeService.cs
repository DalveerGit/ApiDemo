using DemoWebApiWithSwagger.Context;
using DemoWebApiWithSwagger.Interfaces;
using DemoWebApiWithSwagger.Models;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DemoWebApiWithSwagger.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDBContext _appDBContext;

        public EmployeeService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Employee> addEmployee(Employee employee)
        {
            var newEmp = await _appDBContext.Employees.AddAsync(employee);
            await _appDBContext.SaveChangesAsync();
            return newEmp.Entity;
        }

        public async Task deleteEmployee(int id)
        {
            var emp = await _appDBContext.Employees.FirstOrDefaultAsync(x=>x.Id==id);

            if (emp!=null)
            {
                _appDBContext.Employees.Remove(emp);
                await _appDBContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> getAllEmployees()
        {
            var emplist = await _appDBContext.Employees.ToListAsync();
            return emplist;
        }

        public async Task<Employee> getEmployeeById(int id)
        {
            return await _appDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> updateEmployee(Employee employee)
        {
            if (employee.Id != 0)
            {
                var emp = await _appDBContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
                if (emp!=null)
                {
                    emp.Name = employee.Name;
                    emp.Age = employee.Age;
                    emp.Address = employee.Address;
                    emp.Gender = employee.Gender;

                    await _appDBContext.SaveChangesAsync();
                    return emp;
                }
                return null;
            }
            return null;
        }
    }
}
