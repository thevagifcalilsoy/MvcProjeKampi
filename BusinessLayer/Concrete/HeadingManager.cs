using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        iHeadingDal _headingdal;

        public HeadingManager(iHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

        public Heading GetById(int id)
        {
            return _headingdal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingdal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingdal.List(x => x.WriterId == id);
        }

        //public List<Heading> GetListByWriter(int id)
        //{
        //    return _headingdal.List(x => x.WriterId == id);
        //}

        //public List<Heading> GetListByWriter(int id)
        //{
        //    return _headingdal.List(x => x.WriterId == id);
        //}

        public void HeadingAdd(Heading heading)
        {
            _headingdal.insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingdal.delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.update(heading);
        }
    }
}
