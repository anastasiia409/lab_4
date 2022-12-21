using lab_4.Data;
using lab_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_4.Controllers
{
    public class EmployeeProjectController: Controller
    {
        private readonly DbConnection _db;

        public EmployeeProjectController(DbConnection db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmployeeProject> _eprojects = _db.EmployeeProject;
            return View(_eprojects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeProject eproject)
        {
            if (ModelState.IsValid)
            {
                await _db.EmployeeProject.AddAsync(eproject);
                await _db.SaveChangesAsync();
                TempData["success"] = "EmployeeProjec was added successfully";
                return RedirectToAction("Index");
            }

            return View(eproject);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _eproject = await _db.EmployeeProject.FindAsync(id);

            if (_eproject == null)
            {
                return NotFound();
            }

            return View(_eproject);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeProject eproject)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeeProject.Update(eproject);
                await _db.SaveChangesAsync();
                TempData["success"] = "EmployeeProject was updated successfully";
                return RedirectToAction("Index");
            }
            return View(eproject);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _eproject = await _db.EmployeeProject.FindAsync(id);

            if (_eproject == null)
            {
                return NotFound();
            }

            return View(_eproject);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var _eproject = await _db.EmployeeProject.FindAsync(id);

            if (_eproject == null)
            {
                return NotFound();
            }
            _db.EmployeeProject.Remove(_eproject);
            await _db.SaveChangesAsync();
            TempData["success"] = "EmployeeProject was deleted successfully";
            return RedirectToAction("Index");
        }

    }

}
