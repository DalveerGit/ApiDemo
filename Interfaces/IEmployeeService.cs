using DemoWebApiWithSwagger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoWebApiWithSwagger.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> getAllEmployees();
        Task<Employee> getEmployeeById(int id);
        Task<Employee> addEmployee(Employee employee);
        Task<Employee> updateEmployee(Employee employee);
        Task deleteEmployee(int id);
    }
}
