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
    public class NodesController : Controller
    {
        private inventoryMgmtPocEntities db = new inventoryMgmtPocEntities();

        // GET: Nodes
        public async Task<ActionResult> Index()
        {
            var nodes = db.Nodes.Include(n => n.Rack);
            return View(await nodes.ToListAsync());
        }

        // GET: Nodes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // GET: Nodes/Create
        public ActionResult Create()
        {
            ViewBag.rack_id = new SelectList(db.Racks, "id", "name");
            return View();
        }

        // POST: Nodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,rack_id,ip,originalHostName,mac,ipmi,states,comment")] Node node)
        {
            if (ModelState.IsValid)
            {
                node.id = Utilities.Utility.getUniqueKey();
                db.Nodes.Add(node);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.rack_id = new SelectList(db.Racks, "id", "name", node.rack_id);
            return View(node);
        }

        // GET: Nodes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            ViewBag.rack_id = new SelectList(db.Racks, "id", "name", node.rack_id);
            return View(node);
        }

        // POST: Nodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,rack_id,ip,originalHostName,mac,ipmi,states,comment")] Node node)
        {
            if (ModelState.IsValid)
            {
                db.Entry(node).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.rack_id = new SelectList(db.Racks, "id", "name", node.rack_id);
            return View(node);
        }

        // GET: Nodes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: Nodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Node node = await db.Nodes.FindAsync(id);
            db.Nodes.Remove(node);
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
