using MCC75_NET.Models;
using MCC75_NET.Repositories.Interface;
using MCC75_NET.ViewModels;
using MCC75_NET.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MCC75_NET.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private MyContext context;
        private readonly EmployeeRepository employeeRepository; 

        public EmployeeRepository(MyContext context)
        {
            this.context = context;
          /*  this.educationRepository = educationRepository;*/
        }

        public int Delete(int key)
        {
            int result = 0;
            var employee = GetById(key);
            if (employee == null)
            {
                return result;
            }
            context.Remove(employee);
            result = context.SaveChanges();
            return result;
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList() ?? null;
        }

        public Employee GetById(int key)
        {
            return context.Employees.Find() ?? null;
        }

        public int Insert(Employee entity)
        {
            int result = 0;
            context.Add(entity);
            result = context.SaveChanges();
            return result;
        }

        public int Update(Employee entity)
        {
            int result = 0;
            context.Entry(entity).State = EntityState.Modified;
            result = context.SaveChanges();
            return result;
        }

        public object GetById(string employeesNik)
        {
            throw new NotImplementedException();
        }

        internal string GetById()
        {
            throw new NotImplementedException();
        }
    }
}
