using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
   public interface Irepository<T>
    {
        List<T> List();
        void insert(T p);
        T Get(Expression<Func<T, bool>> filter);
        void delete(T p);
        void update(T p);
        List<T> List(Expression<Func<T, bool>> filter);

    }
}
