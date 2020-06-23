using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityRepositoryPatterns.Models;
using UnityRepositoryPatterns.Repository;
using System.Data;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Persistence.Contexts;

namespace UnityRepositoryPatterns.Controllers
{
    public class HomeController : Controller
    {
        //UnitOfWork a = new UnitOfWork(new DBEntities());
        //UnitOfWork a = new UnitOfWork(BookManageDbContext context);
        //private readonly IUnitOfWork _unitOfWork;

        private readonly IAuthurResponsitory _authurResponsitory;
        private readonly ICustomRepository _customRepository;

        public HomeController()
        {
            //_authurResponsitory = authurResponsitory;
            //_customRepository = customRepository;
            this._authurResponsitory = new AuthorRespository(new BookManageDbContext());
            this._customRepository = new CustomRepository(new BookManageDbContext());
        }


        public ActionResult Index()
        {
            var books = _customRepository.GetTop5CostlyBook();
            return View(books.AsEnumerable());
            //var authors = _authurResponsitory.getlist();
            ////var books = from book in _authurResponsitory.getlist()
            ////            select book;
            //return View(authors.AsEnumerable());
        }
        public ActionResult loadauthor(Auther model)
        {
            
            Auther list_au = new Auther();
            //list_au.AutherName = "";
           if(ModelState.IsValid)
            {
                //a.hehe.Add(list_au);
                //a.SaveChanges();
                _authurResponsitory.getlist();
            }
            else
            {
                ModelState.AddModelError("DateEncaissement", "The DateEncaissement must be set");
            }
            
            //List<Auther> list = new List<Auther>();
            var list = _authurResponsitory.getlist();
            //DataTable dt = _authurResponsitory.getdb();
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
            return PartialView(books);

            //try
            //{              
            //    using (var unitOfWork = new UnitOfWork())
            //    {
            //        if (BookID == 1)
            //        {
            //            //Called by GENERIC METHOD
            //            books = unitOfWork.abc.GetAll().ToList();
            //        }
            //        else if (BookID == 2)
            //        {
            //            //Called by CUSTOM METHOD
            //            books = unitOfWork.abc.GetTop5CostlyBook().ToList();
            //        }
            //        else if (BookID == 3)
            //        {
            //            //Called by CUSTOM METHOD
            //            books = unitOfWork.abc.GetBookAutherWise(2).ToList();
            //        }
            //        else if (BookID == 4)
            //        {
            //            //Called by CUSTOM METHOD
            //            books = unitOfWork.abc.GetBookAutherWise(1).ToList();
            //        }
            //    }
            //    return PartialView(books);
            //}
            //catch
            //{
            //    throw;
            //}
        }

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}