        using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.ViewModel;

namespace POS.Controllers
{
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MealsController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meals.Where(ch=>ch.IsChild==false).Include(c=>c.Category).ToListAsync());
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // GET: Meals/Create
        public IActionResult Create()
        {
            AddMealViewModel model = new AddMealViewModel
            {
                Categories = _context.Categories.ToList(),
            };

            return View(model);
        }

        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMealViewModel model)
        {
            Meal meal = new Meal();
            meal.Name = model.Name;
            meal.Price = model.Price;
            meal.Quantity = model.Quantity;
            meal.Photo = UploadedFile(model);
            meal.Category = _context.Categories.Where(id => id.Id == model.Category.Id).FirstOrDefault();
            meal.HasSize = model.HasSize;
            meal.IsChild = false;
            if (ModelState.IsValid)
            {
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
        }
        //UPLOAD MEAL PHOTO
        private string UploadedFile(AddMealViewModel model)
        {
            string uniqueFileName = null;

            if (model.MealImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MealImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.MealImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        // GET: Meals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Meal meal)
        {
            if (id != meal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    meal.IsChild = false;
                    _context.Update(meal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
        }
        //CREATE SIZE  GET
        [HttpGet]
        public async Task<IActionResult> CreateSize()
        {
            var size = new AddMealViewModel
            {
                Meals = await _context.Meals.Where(ch => ch.HasSize == true).ToListAsync(),
            };
            return View(size);
        }
        //CREATE SIZE  POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSize(AddMealViewModel model)
        {

            if (ModelState.IsValid)
            {
                Meal meal = new Meal();
                meal.Name = model.Name;
                meal.Price = model.Price;
                meal.Quantity = model.Name;
                meal.Photo = UploadedFile(model);
                meal.ParentId = model.MealId;
                meal.IsChild = true;
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.Id == id);
        }
    }
}
