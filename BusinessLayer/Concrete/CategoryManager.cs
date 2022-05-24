using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAdd(Category category)
        {
            _categorydal.insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.update(category);
        }

        public Category GetById(int id)
        {
            return _categorydal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }


        // GenericRepositories<Category> repo = new GenericRepositories<Category>();
        //public List<Category>GetAll()
        //{
        //    return repo.List();

        //}
        //public void CategoryAddbl(Category p)
        //{
        //    if (p.CategoryName==""||p.CategoryName.Length<=3||p.CategoryDescreption==""||p.CategoryName.Length>=51)
        //    {
        //        //Hata Mesaji
        //    }
        //    else
        //    {
        //        repo.insert(p);
        //    }
        //}

    }
}
