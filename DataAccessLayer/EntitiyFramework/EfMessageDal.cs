using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EfMessageDal : GenericRepositories<Message>, IMessageDal
    {
    }
}
