using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityRepositoryPatterns.Models;
using UnityRepositoryPatterns.Repository;
using System.Data;

namespace UnityRepositoryPatterns.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork a = new UnitOfWork(new DBEntities());
        public ActionResult Index()
        {
            return View(new List<Book>());
        }
        public ActionResult loadauthor(Auther model)
        {
            
            Auther list_au = new Auther();
            //list_au.AutherName = "";
           if(ModelState.IsValid)
            {
                a.hehe.Add(list_au);
                a.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("DateEncaissement", "The DateEncaissement must be set");
            }
            
            List<Auther> list = new List<Auther>();
            list = a.hehe.getlist().ToList();
            DataTable dt = a.hehe.getdb();
            return PartialView(list);
        }
        public ActionResult LoadData(long BookID)
        {
            /*
                1 = Get All Books
                2 = Get Top 5 Costly Books
                3 = Get All Books Of Chetan Bhagat
                4 = Get All Books Of J.K. Rowling
            */
            List<Book> books = new List<Book>();

            try
            {              
                using (var unitOfWork = new UnitOfWork(new DBEntities()))
                {
                    if (BookID == 1)
                    {
                        //Called by GENERIC METHOD
                        books = unitOfWork.abc.GetAll().ToList();
                    }
                    else if (BookID == 2)
                    {
                        //Called by CUSTOM METHOD
                        books = unitOfWork.abc.GetTop5CostlyBook().ToList();
                    }
                    else if (BookID == 3)
                    {
                        //Called by CUSTOM METHOD
                        books = unitOfWork.abc.GetBookAutherWise(2).ToList();
                    }
                    else if (BookID == 4)
                    {
                        //Called by CUSTOM METHOD
                        books = unitOfWork.abc.GetBookAutherWise(1).ToList();
                    }
                }
                return PartialView(books);
            }
            catch
            {
                throw;
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}