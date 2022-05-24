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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidation = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = cm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = cm.GetListInbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messagevalidation.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = sender;
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