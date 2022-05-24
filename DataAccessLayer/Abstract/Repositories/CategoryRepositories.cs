﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public class CategoryRepositories : ICategoryDal
    {
        Context c = new Context();
        DbSet<Category> _object;
        public void delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        { 
            throw new NotImplementedException();
        }

        public void update(Category p)
        {
            c.SaveChanges();
        }
    }
}
