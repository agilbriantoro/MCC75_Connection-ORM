namespace MCC75NET.Repositories;
using MCC75_NET.Models;
using MCC75_NET.Repositories.Interface;
using MCC75_NET.Contexts;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class EmployeeRepository : IRepository<string, Employee>
{
    private readonly MyContext context;

    public EmployeeRepository(MyContext context)
    {
        this.context = context;
    }
    public int Delete(string key)
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

    public Employee GetById(string key)
    {
        return context.Employees.Find(key) ?? null;
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
}