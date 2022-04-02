using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExoGym.Models;

namespace ExoGym.Controllers
{
    [Authorize]
    public class MemberDatasController : Controller
    {
        private GymDataEntities db = new GymDataEntities();

        // GET: MemberDatas
        public ActionResult Index()
        {
            return View(db.MemberDatas.ToList());
        }

        // GET: MemberDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberData memberData = db.MemberDatas.Find(id);
            if (memberData == null)
            {
                return HttpNotFound();
            }
            return View(memberData);
        }

        // GET: MemberDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Mobile,Address")] MemberData memberData)
        {
            if (ModelState.IsValid)
            {
                db.MemberDatas.Add(memberData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memberData);
        }

        // GET: MemberDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberData memberData = db.MemberDatas.Find(id);
            if (memberData == null)
            {
                return HttpNotFound();
            }
            return View(memberData);
        }

        // POST: MemberDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Mobile,Address")] MemberData memberData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberData);
        }

        // GET: MemberDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberData memberData = db.MemberDatas.Find(id);
            if (memberData == null)
            {
                return HttpNotFound();
            }
            return View(memberData);
        }

        // POST: MemberDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberData memberData = db.MemberDatas.Find(id);
            db.MemberDatas.Remove(memberData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
