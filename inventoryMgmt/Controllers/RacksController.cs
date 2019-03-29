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
    public class RacksController : Controller
    {
        private inventoryMgmtPocEntities db = new inventoryMgmtPocEntities();

        // GET: Racks
        public async Task<ActionResult> Index()
        {
            var racks = db.Racks.Include(r => r.DC);
            return View(await racks.ToListAsync());
        }

        // GET: Racks/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rack rack = await db.Racks.FindAsync(id);
            if (rack == null)
            {
                return HttpNotFound();
            }
            return View(rack);
        }

        // GET: Racks/Create
        public ActionResult Create()
        {
            ViewBag.DC_id = new SelectList(db.DCs, "id", "name");
            return View();
        }

        // POST: Racks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,DC_id")] Rack rack)
        {
            if (ModelState.IsValid)
            {
                db.Racks.Add(rack);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DC_id = new SelectList(db.DCs, "id", "name", rack.DC_id);
            return View(rack);
        }

        // GET: Racks/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rack rack = await db.Racks.FindAsync(id);
            if (rack == null)
            {
                return HttpNotFound();
            }
            ViewBag.DC_id = new SelectList(db.DCs, "id", "name", rack.DC_id);
            return View(rack);
        }

        // POST: Racks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,DC_id")] Rack rack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rack).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DC_id = new SelectList(db.DCs, "id", "name", rack.DC_id);
            return View(rack);
        }

        // GET: Racks/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rack rack = await db.Racks.FindAsync(id);
            if (rack == null)
            {
                return HttpNotFound();
            }
            return View(rack);
        }

        // POST: Racks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Rack rack = await db.Racks.FindAsync(id);
            db.Racks.Remove(rack);
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
