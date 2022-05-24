using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager:IMessageService
    {
        IMessageDal _MessageDal;
     
        public MessageManager(IMessageDal messageDal)
        {
            _MessageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _MessageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _MessageDal.List(x => x.ReceiverMail == p);
        }

       

        public List<Message> GetListSendbox(string p)
        {
            return _MessageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _MessageDal.insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
