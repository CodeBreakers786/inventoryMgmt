using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inventoryMgmt.Models;

namespace inventoryMgmt.Controllers
{
    public class DCsController : Controller
    {
        private inventoryMgmtPocEntities db = new inventoryMgmtPocEntities();

        // GET: DCs
        public async Task<ActionResult> Index()
        {
            return View(await db.DCs.ToListAsync());
        }

        // GET: DCs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DC dC = await db.DCs.FindAsync(id);
            if (dC == null)
            {
                return HttpNotFound();
            }
            return View(dC);
        }

        // GET: DCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] DC dC)
        {
            if (ModelState.IsValid)
            {
                db.DCs.Add(dC);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dC);
        }

        // GET: DCs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DC dC = await db.DCs.FindAsync(id);
            if (dC == null)
            {
                return HttpNotFound();
            }
            return View(dC);
        }

        // POST: DCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] DC dC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dC).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dC);
        }

        // GET: DCs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DC dC = await db.DCs.FindAsync(id);
            if (dC == null)
            {
                return HttpNotFound();
            }
            return View(dC);
        }

        // POST: DCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DC dC = await db.DCs.FindAsync(id);
            db.DCs.Remove(dC);
            await db.SaveChangesAsync();
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
