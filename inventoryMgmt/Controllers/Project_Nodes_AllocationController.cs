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
    public class Project_Nodes_AllocationController : Controller
    {
        private inventoryMgmtPocEntities db = new inventoryMgmtPocEntities();

        // GET: Project_Nodes_Allocation
        public async Task<ActionResult> Index()
        {
            var project_Nodes_Allocation = db.Project_Nodes_Allocation.Include(p => p.Node).Include(p => p.Project);
            return View(await project_Nodes_Allocation.ToListAsync());
        }

        // GET: Project_Nodes_Allocation/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Nodes_Allocation project_Nodes_Allocation = await db.Project_Nodes_Allocation.FindAsync(id);
            if (project_Nodes_Allocation == null)
            {
                return HttpNotFound();
            }
            return View(project_Nodes_Allocation);
        }

        // GET: Project_Nodes_Allocation/Create
        public ActionResult Create()
        {
            ViewBag.node_id = new SelectList(db.Nodes, "id", "rack_id");
            ViewBag.project_id = new SelectList(db.Projects, "id", "name");
            return View();
        }

        // POST: Project_Nodes_Allocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,node_id,project_id")] Project_Nodes_Allocation project_Nodes_Allocation)
        {
            if (ModelState.IsValid)
            {
                project_Nodes_Allocation.id = Utilities.Utility.getUniqueKey();
                db.Project_Nodes_Allocation.Add(project_Nodes_Allocation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.node_id = new SelectList(db.Nodes, "id", "rack_id", project_Nodes_Allocation.node_id);
            ViewBag.project_id = new SelectList(db.Projects, "id", "name", project_Nodes_Allocation.project_id);
            return View(project_Nodes_Allocation);
        }

        // GET: Project_Nodes_Allocation/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Nodes_Allocation project_Nodes_Allocation = await db.Project_Nodes_Allocation.FindAsync(id);
            if (project_Nodes_Allocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.node_id = new SelectList(db.Nodes, "id", "rack_id", project_Nodes_Allocation.node_id);
            ViewBag.project_id = new SelectList(db.Projects, "id", "name", project_Nodes_Allocation.project_id);
            return View(project_Nodes_Allocation);
        }

        // POST: Project_Nodes_Allocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,node_id,project_id")] Project_Nodes_Allocation project_Nodes_Allocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_Nodes_Allocation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.node_id = new SelectList(db.Nodes, "id", "rack_id", project_Nodes_Allocation.node_id);
            ViewBag.project_id = new SelectList(db.Projects, "id", "name", project_Nodes_Allocation.project_id);
            return View(project_Nodes_Allocation);
        }

        // GET: Project_Nodes_Allocation/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Nodes_Allocation project_Nodes_Allocation = await db.Project_Nodes_Allocation.FindAsync(id);
            if (project_Nodes_Allocation == null)
            {
                return HttpNotFound();
            }
            return View(project_Nodes_Allocation);
        }

        // POST: Project_Nodes_Allocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Project_Nodes_Allocation project_Nodes_Allocation = await db.Project_Nodes_Allocation.FindAsync(id);
            db.Project_Nodes_Allocation.Remove(project_Nodes_Allocation);
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
