using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Context = DataAccessLayer.Concrete.Context;

namespace DataAccessLayer.Abstract.Repositories
{
    public class GenericRepositories<T> : Irepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public GenericRepositories()
        {
            _object = c.Set<T>();
        }
        public void delete(T p)
        {
            var DeleteEntry = c.Entry(p);
            DeleteEntry.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void insert(T p)
        {
            var AdedEntity = c.Entry(p);
            AdedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void update(T p)
        {
            var UpdateEntry = c.Entry(p);
            UpdateEntry.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}



