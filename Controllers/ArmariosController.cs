using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaVolume.Models;

namespace GuardaVolume.Controllers
{
    public class ArmariosController : Controller
    {
        private readonly GuardaVolumeContext _context;

        public ArmariosController(GuardaVolumeContext context)
        {
            _context = context;
        }

        // GET: Armarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Armario.ToListAsync());
        }
        

        // GET: Armarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armario = await _context.Armario
                .FirstOrDefaultAsync(m => m.ArmarioId == id);
            if (armario == null)
            {
                return NotFound();
            }

            return View(armario);
        }

        // GET: Armarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArmarioId,Regiao,PontoY,PontoX")] Armario armario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(armario);
        }

        // GET: Armarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armario = await _context.Armario.FindAsync(id);
            if (armario == null)
            {
                return NotFound();
            }
            
            return View(armario);
        }

        // POST: Armarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArmarioId,Regiao,PontoY,PontoX")] Armario armario)
        {
            if (id != armario.ArmarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmarioExists(armario.ArmarioId))
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
            return View(armario);
        }

        // GET: Armarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armario = await _context.Armario
                .FirstOrDefaultAsync(m => m.ArmarioId == id);
            if (armario == null)
            {
                return NotFound();
            }

            return View(armario);
        }

        // POST: Armarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armario = await _context.Armario.FindAsync(id);
            _context.Armario.Remove(armario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     public async Task<IActionResult> ArmarioIndex()
        {
            return View(await _context.Armario.ToListAsync());
        }
         
        public async Task<IActionResult> DisponivelCompartimento()
        {
            return View(await _context.Compartimento.ToListAsync());
        }
         public async Task<IActionResult> ReservarCompartimento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento.FindAsync(id);
            if (compartimento == null)
            {
                return NotFound();
            }
            //var compartimentosDisponveis= _context.Compartimento.Where(c => c.Disponivel==true);
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Regiao", compartimento.ArmarioId);


        return View(compartimento);

            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReservarCompartimento(int id, [Bind("ArmarioId,Regiao,PontoY,PontoX")] Armario armario)
        {
            if (id != armario.ArmarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmarioExists(armario.ArmarioId))
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
            return View(armario);
        }

    
            

        private bool ArmarioExists(int id)
        {
            return _context.Armario.Any(e => e.ArmarioId == id);
        }
    }
}
