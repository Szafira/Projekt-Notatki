using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Notatki.Data.Migrations;
using Projekt_Notatki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_Notatki.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotatkiContext _context;
        public NotesController(NotatkiContext context)
        {
            _context = context;
        }
        // GET:
        [HttpGet]
        public IEnumerable<notatka> GetNote()
        {
            return _context.Notatka.ToList();
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult<notatka> GetNotes(int id)
        {
            var Notatka = _context.Notatka.Find(id);

            if (Notatka == null)
            {
                return NotFound();
            }

            return Notatka;
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult<notatka> PostNote(notatka notatka)
        {
            _context.Notatka.Add(notatka);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNote), new { id = notatka.id_notatka }, notatka);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public IActionResult EditNote(int id, notatka notatka)
        {
            if (id != notatka.id_notatka)
            {
                return BadRequest();
            }

            _context.Notatka.Update(notatka);
            _context.SaveChanges();

            return NoContent();
        }
        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(decimal id)
        {
            var Notatka = _context.Notatka.Find(id);

            if (Notatka == null)
            {
                return NotFound();
            }

            _context.Notatka.Remove(Notatka);
            _context.SaveChanges();

            return NoContent();
        }
    }
}