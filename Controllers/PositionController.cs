using lab_4.Data;
using lab_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_4.Controllers
{

    public class PositionController: Controller
    {
        private readonly DbConnection _db;
        public PositionController(DbConnection db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Position> position = _db.Position;
            return View(position);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {

            if (ModelState.IsValid)
            {
                await _db.Position.AddAsync(position);
                await _db.SaveChangesAsync();
                TempData["success"] = "Position was added successfully";
                return RedirectToAction("Index");
            }

            return View(position);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _position = await _db.Position.FindAsync(id);

            if (_position == null)
            {
                return NotFound();
            }

            return View(_position);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Position _position)
        {
            if (ModelState.IsValid)
            {
                _db.Position.Update(_position);
                await _db.SaveChangesAsync();
                TempData["success"] = "Position was updated successfully";
                return RedirectToAction("Index");
            }
            return View(_position);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var _position = await _db.Position.FindAsync(id);

            if (_position == null)
            {
                return NotFound();
            }

            return View(_position);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var _position = await _db.Position.FindAsync(id);

            if (_position == null)
            {
                return NotFound();
            }
            _db.Position.Remove(_position);
            await _db.SaveChangesAsync();
            TempData["success"] = "Position was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
