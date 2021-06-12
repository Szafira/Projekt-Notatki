using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_Notatki.Data.Migrations;
using Projekt_Notatki.Models;

namespace Projekt_Notatki.Controllers
{
    public class NotatkasController : Controller
    {
        private readonly NotatkiContext _context;

        public NotatkasController(NotatkiContext context)
        {
            _context = context;
        }

        // GET: Notatkas
        public async Task<IActionResult> Index()
        {
            return View(await _context.notatka.ToListAsync());
        }

        // GET: Notatkas/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notatka = await _context.notatka
                .FirstOrDefaultAsync(m => m.id_notatka == id);
            if (notatka == null)
            {
                return NotFound();
            }

            return View(notatka);
        }

        // GET: Notatkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notatkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_notatka,id_uzytkownik,tytul,tekst,przedmiot,klasa")] notatka notatka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notatka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notatka);
        }

        // GET: Notatkas/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notatka = await _context.notatka.FindAsync(id);
            if (notatka == null)
            {
                return NotFound();
            }
            return View(notatka);
        }

        // POST: Notatkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id_notatka,id_uzytkownik,tytul,tekst,przedmiot,klasa")] notatka notatka)
        {
            if (id != notatka.id_notatka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notatka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!notatkaExists(notatka.id_notatka))
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
            return View(notatka);
        }

        // GET: Notatkas/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notatka = await _context.notatka
                .FirstOrDefaultAsync(m => m.id_notatka == id);
            if (notatka == null)
            {
                return NotFound();
            }

            return View(notatka);
        }

        // POST: Notatkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var notatka = await _context.notatka.FindAsync(id);
            _context.notatka.Remove(notatka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool notatkaExists(decimal id)
        {
            return _context.notatka.Any(e => e.id_notatka == id);
        }
    }
}
