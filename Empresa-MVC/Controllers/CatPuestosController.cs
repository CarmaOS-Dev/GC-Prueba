using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empresa_MVC.Models.DataBase;

namespace Empresa_MVC.Controllers
{
    public class CatPuestosController : Controller
    {
        private readonly GCEmpleadosContext _context;

        public CatPuestosController(GCEmpleadosContext context)
        {
            _context = context;
        }

        // GET: CatPuestos
        public async Task<IActionResult> Index()
        {
              return _context.CatPuestos != null ? 
                          View(await _context.CatPuestos.ToListAsync()) :
                          Problem("Entity set 'GCEmpleadosContext.CatPuestos'  is null.");
        }

        // GET: CatPuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatPuestos == null)
            {
                return NotFound();
            }

            var catPuesto = await _context.CatPuestos
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (catPuesto == null)
            {
                return NotFound();
            }

            return View(catPuesto);
        }

        // GET: CatPuestos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatPuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPuesto,Puesto,Descripcion")] CatPuesto catPuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catPuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catPuesto);
        }

        // GET: CatPuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatPuestos == null)
            {
                return NotFound();
            }

            var catPuesto = await _context.CatPuestos.FindAsync(id);
            if (catPuesto == null)
            {
                return NotFound();
            }
            return View(catPuesto);
        }

        // POST: CatPuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPuesto,Puesto,Descripcion")] CatPuesto catPuesto)
        {
            if (id != catPuesto.IdPuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catPuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatPuestoExists(catPuesto.IdPuesto))
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
            return View(catPuesto);
        }

        // GET: CatPuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatPuestos == null)
            {
                return NotFound();
            }

            var catPuesto = await _context.CatPuestos
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (catPuesto == null)
            {
                return NotFound();
            }

            return View(catPuesto);
        }

        // POST: CatPuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatPuestos == null)
            {
                return Problem("Entity set 'GCEmpleadosContext.CatPuestos'  is null.");
            }
            var catPuesto = await _context.CatPuestos.FindAsync(id);
            if (catPuesto != null)
            {
                _context.CatPuestos.Remove(catPuesto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatPuestoExists(int id)
        {
          return (_context.CatPuestos?.Any(e => e.IdPuesto == id)).GetValueOrDefault();
        }
    }
}
