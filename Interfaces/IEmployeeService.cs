using MyLMS.Entities;

namespace MyLMS.Interfaces
{

    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmpById(int id);
    }
}