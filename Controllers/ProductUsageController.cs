using ITStepShop.Data;
using ITStepShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ITStepShop.Controllers
{
    public class ProductUsageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductUsageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductUsage
        public async Task<IActionResult> Index()
        {
            var productUsages = await _context.ProductUsage.ToListAsync();
            return View(productUsages);
        }

        // GET: ProductUsage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductUsage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ProductUsage productUsage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productUsage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productUsage);
        }

        // GET: ProductUsage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUsage = await _context.ProductUsage.FindAsync(id);
            if (productUsage == null)
            {
                return NotFound();
            }
            return View(productUsage);
        }

        // POST: ProductUsage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ProductUsage productUsage)
        {
            if (id != productUsage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productUsage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductUsageExists(productUsage.Id))
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
            return View(productUsage);
        }

        // GET: ProductUsage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUsage = await _context.ProductUsage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productUsage == null)
            {
                return NotFound();
            }

            return View(productUsage);
        }

        // POST: ProductUsage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productUsage = await _context.ProductUsage.FindAsync(id);
            _context.ProductUsage.Remove(productUsage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductUsageExists(int id)
        {
            return _context.ProductUsage.Any(e => e.Id == id);
        }
    }
}