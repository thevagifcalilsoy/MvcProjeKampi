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
  public  class ContactManager : IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactdal.insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactdal.delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactdal.update(contact);
        }

        public Contact GetById(int id)
        {
            return _contactdal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactdal.List();
        }
    }
}
