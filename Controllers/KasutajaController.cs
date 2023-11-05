using API_Laohaldus.Data;
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
        }

        [HttpGet("kontroll/{email}/{password}")]
        public string KasutajaKontroll(string email, string password)
        {
            foreach (Kasutaja kasutaja in _context.Kasutajad)
            {
                if (kasutaja.E_post == email && kasutaja.Parool == password)
                    return kasutaja.Kasutajanimi;
            }
            return null;
        }

        [HttpPost("lisa/{username}/{email}/{password}")]
        public bool Add(string username, string email, string password)
        {
            if (!_context.Kasutajad.Where(kasutaja => kasutaja.E_post == email).Any())
            {
                _context.Kasutajad.Add(new Kasutaja(username, email, password));
                _context.SaveChanges();
                return true;
            }            

            return false;
        }
    }
}