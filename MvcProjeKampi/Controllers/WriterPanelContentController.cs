using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult MyContent(string p)
        {
           
            p = (string)Session["WriterMail"];
            var writerinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writerinfo);
            return View(contentvalues);
        }
       [HttpGet]
       public ActionResult AddContent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
           string mail = (string)Session["WriterMail"];
            var writerinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writerinfo;
            p.ContentState = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}