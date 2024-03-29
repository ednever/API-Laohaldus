﻿using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KasutajaController(ApplicationDbContext context)
        {
            _context = context;
            //Test
            //_context.Kasutajad.Add(new Kasutaja("Admin", "admin@tthk.ee", "qwerty", true));
            //_context.Kasutajad.Add(new Kasutaja("User", "user@tthk.ee", "qwerty", false));
            //_context.SaveChanges();
        }

        [HttpGet("kontroll/{email}/{password}")]
        public string KasutajaKontroll(string email, string password)
        {
            foreach (Kasutaja kasutaja in _context.Kasutajad)
            {
                if (kasutaja.E_post == email && kasutaja.Parool == password)
                    return kasutaja.Kasutajanimi + "," + kasutaja.IsAdmin;
            }
            return null;
        }

        [HttpPost("lisa/{username}/{email}/{password}")]
        public bool Add(string username, string email, string password)
        {
            if (!_context.Kasutajad.Where(kasutaja => kasutaja.E_post == email).Any())
            {
                _context.Kasutajad.Add(new Kasutaja(username, email, password, false));
                _context.SaveChanges();
                return true;
            }            

            return false;
        }
    }
}