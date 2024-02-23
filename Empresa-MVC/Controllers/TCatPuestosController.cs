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
    public class TCatPuestosController : Controller
    {
        private readonly GCEmpleadosContext _context;

        public TCatPuestosController(GCEmpleadosContext context)
        {
            _context = context;
        }

        // GET: TCatPuestos
        public async Task<IActionResult> Index()
        {
              return _context.TCatPuestos != null ? 
                          View(await _context.TCatPuestos.ToListAsync()) :
                          Problem("Entity set 'GCEmpleadosContext.TCatPuestos'  is null.");
        }

        // GET: TCatPuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TCatPuestos == null)
            {
                return NotFound();
            }

            var tCatPuesto = await _context.TCatPuestos
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (tCatPuesto == null)
            {
                return NotFound();
            }

            return View(tCatPuesto);
        }

        // GET: TCatPuestos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TCatPuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPuesto,Puesto,Descripcion")] TCatPuesto tCatPuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tCatPuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tCatPuesto);
        }

        // GET: TCatPuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TCatPuestos == null)
            {
                return NotFound();
            }

            var tCatPuesto = await _context.TCatPuestos.FindAsync(id);
            if (tCatPuesto == null)
            {
                return NotFound();
            }
            return View(tCatPuesto);
        }

        // POST: TCatPuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPuesto,Puesto,Descripcion")] TCatPuesto tCatPuesto)
        {
            if (id != tCatPuesto.IdPuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tCatPuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TCatPuestoExists(tCatPuesto.IdPuesto))
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
            return View(tCatPuesto);
        }

        // GET: TCatPuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TCatPuestos == null)
            {
                return NotFound();
            }

            var tCatPuesto = await _context.TCatPuestos
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (tCatPuesto == null)
            {
                return NotFound();
            }

            return View(tCatPuesto);
        }

        // POST: TCatPuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TCatPuestos == null)
            {
                return Problem("Entity set 'GCEmpleadosContext.TCatPuestos'  is null.");
            }
            var tCatPuesto = await _context.TCatPuestos.FindAsync(id);
            if (tCatPuesto != null)
            {
                _context.TCatPuestos.Remove(tCatPuesto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TCatPuestoExists(int id)
        {
          return (_context.TCatPuestos?.Any(e => e.IdPuesto == id)).GetValueOrDefault();
        }
    }
}
