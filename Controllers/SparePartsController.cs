using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyChallenge.Entitiy;
using MyChallenge.Entity;
using MyChallenge.Models;

namespace MyChallenge.Controllers
{
    public class SparePartsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: SpareParts
        public ActionResult Index()
        {
            var spareParts = db.SpareParts.Include(s => s.Product);
            return View(spareParts.ToList());
        }

        // GET: SpareParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SparePart sparePart = db.SpareParts.Find(id);
            if (sparePart == null)
            {
                return HttpNotFound();
            }

            return View(sparePart);
        }

        // GET: SpareParts/Create
        public ActionResult Create(string code)
        {
            ViewData["code"] = code;
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PartCode,PartName,PartPrice,ProductId")]
            SparePart sparePart)
        {
            if (ModelState.IsValid)
            {
                db.SpareParts.Add(sparePart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", sparePart.ProductId);
            return View(sparePart);
        }

        // GET: SpareParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SparePart sparePart = db.SpareParts.Find(id);
            if (sparePart == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", sparePart.ProductId);
            return View(sparePart);
        }

        // POST: SpareParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PartCode,PartName,PartPrice,ProductId")]
            SparePart sparePart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sparePart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", sparePart.ProductId);
            return View(sparePart);
        }

        // GET: SpareParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SparePart sparePart = db.SpareParts.Find(id);
            if (sparePart == null)
            {
                return HttpNotFound();
            }

            return View(sparePart);
        }

        // POST: SpareParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SparePart sparePart = db.SpareParts.Find(id);
            db.SpareParts.Remove(sparePart);
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

        public ActionResult PartOfProduct(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var spare = db.SpareParts
                .Where(i => i.ProductId == id)
                .Select(i => new SparePartModel()
                {
                    Id = i.Id,
                    ProductName = i.Product.ProductName,
                    ProductId = i.ProductId,
                    PartCode = i.PartCode,
                    PartName = i.PartName,
                    PartPrice = i.PartPrice,
                }).AsQueryable();
            


            if (id == null)
            {
                return HttpNotFound();
            }

            return View(spare);
        }
    }
}