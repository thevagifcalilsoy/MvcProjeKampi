using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
       
        int writeridinfo;
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalues = wm.GetByID(id);
            return View(writervalues);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidatior writervalidation = new WriterValidatior();
            ValidationResult result = writervalidation.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
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
        [AllowAnonymous]
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
           writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
           
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;


            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.d = writeridinfo;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId =  writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var Headingvalues = hm.GetById(id);
            return View(Headingvalues);

        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        { 
            var HeadingValue = hm.GetById(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");

            




        }
        public ActionResult AllHeading( int p=1)
        {
            var headings = hm.GetList().ToPagedList(p, 3);
            return View(headings);
        }
    }
}