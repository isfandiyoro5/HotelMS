using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IEmployeeRepository
    {
        public int AddEmployee(Employee employee);

        public Employee GetEmployeeById(int id);

        public List<Employee> GetAllEmployees();

        public int UpdateEmployee(Employee employee);

        public int DeleteEmployee(Employee employee);
    }
}
