using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArveController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArveController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("lisa")]
        public bool Add()
        {
            _context.Arved.Add(new Arve(DateTime.Now));
            _context.SaveChanges();

            return true;
        }
    }
}