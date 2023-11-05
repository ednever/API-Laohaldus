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

        [HttpGet]
        public List<Kategooria> Get()
        {
            return _context.Kategooriad.ToList();
        }

        [HttpGet("{id}")]
        public string GetNameByID(int id)
        {
            var kategooria = _context.Kategooriad.Find(id);
            if (kategooria != null)
                return kategooria.Nimetus;    
            
            return null;
        }
    }
}