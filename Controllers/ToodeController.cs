using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{kategooriaId}")]
        public List<Toode> GetByKategooriaID(int kategooriaId)
        {
            List<Toode> tootedKategoorias = new List<Toode>();
            foreach (Toode toode in _context.Tooted)
            {
                if (toode.KategooriaId == kategooriaId)
                    tootedKategoorias.Add(toode);
            }
            return tootedKategoorias;
        }
    }
}