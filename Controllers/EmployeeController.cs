using lab_4.Data;
using lab_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_4.Controllers
{
    public class EmployeeController: Controller
    {
        private readonly DbConnection _db;

        public EmployeeController(DbConnection db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _db.Employee;
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {

            if (ModelState.IsValid)
            {
                await _db.Employee.AddAsync(employee);
                await _db.SaveChangesAsync();
                TempData["success"] = "Emplloyee was added successfully";
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _employee = await _db.Employee.FindAsync(id);

            if (_employee == null)
            {
                return NotFound();
            }

            return View(_employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employee.Update(employee);
                await _db.SaveChangesAsync();
                TempData["success"] = "Employee was updated successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _employee = await _db.Employee.FindAsync(id);

            if (_employee == null)
            {
                return NotFound();
            }

            return View(_employee);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var _employee = await _db.Employee.FindAsync(id);

            if (_employee == null)
            {
                return NotFound();
            }
            _db.Employee.Remove(_employee);
            await _db.SaveChangesAsync();
            TempData["success"] = "Employee was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
