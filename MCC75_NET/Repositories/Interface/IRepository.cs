using MCC75_NET.Models;
using MCC75_NET.Repositories;
using MCC75_NET.ViewModels;

namespace MCC75_NET.Repositories.Interface
{
    interface IRepository<Key, Entity> where Entity : class
    {
        //GetAll
        List<Entity> GetAll();
        //GetById
        Entity GetById(Key key);
        //Create
        int Insert(Entity entity);
        //Update
        int Update(Entity entity);
        //Delete
        int Delete(Key key);
    }
}
