using lab_4.Data;
using lab_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_4.Controllers
{
    public class ProjectController: Controller
    {
        private readonly DbConnection _db;
        public ProjectController(DbConnection db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Project> project = _db.Project;
            return View(project);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {

            if (ModelState.IsValid)
            {
                await _db.Project.AddAsync(project);
                await _db.SaveChangesAsync();
                TempData["success"] = "Project was added successfully";
                return RedirectToAction("Index");
            }

            return View(project);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _project = await _db.Project.FindAsync(id);

            if (_project == null)
            {
                return NotFound();
            }

            return View(_project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Project _project)
        {
            if (ModelState.IsValid)
            {
                _db.Project.Update(_project);
                await _db.SaveChangesAsync();
                TempData["success"] = "Project was updated successfully";
                return RedirectToAction("Index");
            }
            return View(_project);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _project = await _db.Project.FindAsync(id);

            if (_project == null)
            {
                return NotFound();
            }

            return View(_project);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var _project = await _db.Project.FindAsync(id);

            if (_project == null)
            {
                return NotFound();
            }
            _db.Project.Remove(_project);
            await _db.SaveChangesAsync();
            TempData["success"] = "Project was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
