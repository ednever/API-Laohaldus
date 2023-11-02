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
    }
}