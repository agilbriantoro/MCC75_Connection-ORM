using MCC75_NET.Contexts;
using MCC75_NET.Models;
using MCC75_NET.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace MCC75_NET.Repositories
{
    public class RoleRepository : IRepository<int, Role>
    {
        private readonly MyContext context;

        public int Delete(int key)
        {
            var entity = GetById(key);
            context.Remove(entity);
            return context.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return context.Roles.ToList();
        }

        public Role GetById(int key)
        {
            return context.Roles.Find(key);
        }

        public int Insert(Role entity)
        {
            context.Add(entity);
            return context.SaveChanges();
        }

        public int Update(Role entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
