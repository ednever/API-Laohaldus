using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TellimusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TellimusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Tellimus> Get()
        {
            return _context.Tellimused.ToList();
        }

        [HttpGet("{id}")] 
        public Tellimus GetByID(int id)
        {
            var tellimus = _context.Tellimused.Find(id);

            if (tellimus == null)
                return null;

            return tellimus;
        }

        [HttpPost("lisa/{tooteId}/{kogus}")]
        public List<Tellimus> Add(int tooteId, int kogus)
        {
            _context.Tellimused.Add(new Tellimus(tooteId, kogus));
            _context.SaveChanges();           

            return _context.Tellimused.ToList();
        }

        [HttpDelete("kustuta/{id}")]
        public List<Tellimus> Delete(int id)
        {
            var tellimus = _context.Tellimused.Find(id);

            if (tellimus == null)
                return _context.Tellimused.ToList();

            _context.Tellimused.Remove(tellimus);
            _context.SaveChanges();
            return _context.Tellimused.ToList();
        }

        [HttpPut("muuda/{id}")]
        public Tellimus ChangeActive(int id)
        {
            var tellimus = _context.Tellimused.Find(id);

            if (tellimus == null)
                return null;           

            _context.Tellimused.Update(tellimus);
            _context.SaveChanges();

            return tellimus;
        }
    }
}
