using MyLMS.Entities;
using MyLMS.Interfaces;

namespace MyLMS.Repositories
{
  public class EmpRepo : IEmployeeService
    {
      private List<Employee> EmpStock = new List<Employee>();
      public void AddEmployee(Employee employee)
      {
          EmpStock.Add(employee);
      }
      public List<Employee> GetAllEmployees()
      {
          return EmpStock;
      }
      public Employee GetEmpById(int id)
      {
          return EmpStock.FirstOrDefault(e => e.Id == id);
      }
  }


}