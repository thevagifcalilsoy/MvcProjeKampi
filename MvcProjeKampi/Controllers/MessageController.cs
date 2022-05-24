using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidation = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = cm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = cm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messagevalidation.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}