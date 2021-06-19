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
        [Route("api/[controller]")]
        [ApiController]
        public class UzytkownikController : ControllerBase
        {
            private readonly UzytkownikContext _context;
            public UzytkownikController(UzytkownikContext context)
            {
                _context = context;
            }
            // GET:
            [HttpGet]
            public IEnumerable<uzytkownik> getUsers()
            {
                return _context.Uzytkownik.ToList();
            }

            // GET api/<NotesController>/5
            [HttpGet("{id}")]
            public ActionResult<uzytkownik> GetUser(int id)
            {
                var Uzytkownik = _context.Uzytkownik.Find(id);

                if (Uzytkownik == null)
                {
                    return NotFound();
                }

                return Uzytkownik;
            }

            // POST api/<NotesController>
            [HttpPost]
            public ActionResult<uzytkownik> PostUser(uzytkownik uzytkownik)
            {
                _context.Uzytkownik.Add(uzytkownik);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetUser), new { id = uzytkownik.id_uzytkownika }, uzytkownik);
            }

            // PUT api/<NotesController>/5
            [HttpPut("{id}")]
            public IActionResult PutUser(int id, uzytkownik uzytkownik)
            {
                if (id != uzytkownik.id_uzytkownika)
                {
                    return BadRequest();
                }

                _context.Uzytkownik.Update(uzytkownik);
                _context.SaveChanges();

                return NoContent();
            }
            // DELETE api/<NotesController>/5
            [HttpDelete("{id}")]
            public IActionResult DeleteUser(decimal id)
            {
                var Uzytkownik = _context.Uzytkownik.Find(id);

                if (Uzytkownik == null)
                {
                    return NotFound();
                }

                _context.Uzytkownik.Remove(Uzytkownik);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }