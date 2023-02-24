
using MCC75_NET.Models;
using MCC75_NET.Repositories.Interface;
using MCC75_NET.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace MCC75_NET.Repositories
{
    public class RoleRepository : IRepository<int, Role>
    {
        private readonly MyContext context;

        public RoleRepository(MyContext context)
        {
            this.context = context;
        }
        public int Delete(int key)
        {
            int result = 0;
            var role = GetById(key);

            if (role == null)
            {
                return result;
            }
            context.Remove(role);
            result = context.SaveChanges();

            return result;
        }

        public List<Role> GetAll()
        {
            return context.Roles.ToList() ?? null;
        }

        public Role GetById(int key)
        {
            return context.Roles.Find(key) ?? null;
        }

        public int Insert(Role entity)
        {
            int result = 0;
            context.Add(entity);
            result = context.SaveChanges();

            return result;
        }

        public int Update(Role entity)
        {
            int result = 0;
            context.Entry(entity).State = EntityState.Modified;
            result = context.SaveChanges();

            return result;
        }
    }
}

