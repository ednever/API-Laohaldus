using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KategooriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KategooriaController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}