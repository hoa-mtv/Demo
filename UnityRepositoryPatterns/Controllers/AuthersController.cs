using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;
using UnityRepositoryPatterns.Repository;

namespace UnityRepositoryPatterns.Controllers
{
    public class AuthersController : Controller
    {
        private readonly IAuthurResponsitory _authurResponsitory;
        private readonly IUnitOfWork _unitOfWork;
        // GET: Authers
        public ActionResult Index()
        {
            //return View(_authurResponsitory.Authers.ToList());
            return View(_authurResponsitory.getlist());
        }

        // GET: Authers/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Auther auther = db.Authers.Find(id);
            Auther auther = _authurResponsitory.FindAutherById(id);
            if (auther == null)
            {
                return HttpNotFound();
            }
            return View(auther);
        }

        // GET: Authers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Auther model)//[Bind(Include = "AutherID,AutherName")] Auther auther
        {
            //Auther auther = new Auther();
            //list_au.AutherName = "";
            if (ModelState.IsValid)
            {
                //db.Authers.Add(model);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Authers/Edit/5
        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Auther auther = db.Authers.Find(id);
            Auther auther = _authurResponsitory.FindAutherById(id);
            if (auther == null)
            {
                return HttpNotFound();
            }
            return View(auther);
        }

        // POST: Authers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutherID,AutherName")] Auther auther)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(auther).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auther);
        }

        // GET: Authers/Delete/5
        public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Auther auther = db.Authers.Find(id);
            Auther auther = _authurResponsitory.FindAutherById(id);
            if (auther == null)
            {
                return HttpNotFound();
            }
            return View(auther);
        }

        // POST: Authers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //Auther auther = db.Authers.Find(id);
            //db.Authers.Remove(auther);
            //db.SaveChanges();
            _authurResponsitory.DeleteAutherById(id);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
