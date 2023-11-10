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

        /*[HttpGet]
        public List<Tellimus> Get()
        {
            return _context.Tellimused.ToList();
        }*/

        [HttpGet("{kasutajaEmail}")]
        public List<Tellimus> GetByKasutajaEmail(string kasutajaEmail)
        {
            if (_context.Kasutajad.Where(kasutaja => kasutaja.E_post == kasutajaEmail).Any())
            {
                var kasutaja = _context.Kasutajad.FirstOrDefault(obj => obj.E_post == kasutajaEmail);

                List<Tellimus> tellimusedKasutajal = new List<Tellimus>();
                foreach (Tellimus tellimus in _context.Tellimused)
                {
                    if (tellimus.KasutajaId == kasutaja.Id)
                        tellimusedKasutajal.Add(tellimus);
                }
                return tellimusedKasutajal;
            }
            return null;
        }

        [HttpPost("lisa/{toodeId}/{kogus}/{kasutajaEmail}")]
        public bool Add(int toodeId, int kogus, string kasutajaEmail)
        {
            var kasutaja = _context.Kasutajad.FirstOrDefault(obj => obj.E_post == kasutajaEmail);
            foreach (Tellimus tellimus in _context.Tellimused)
            {
                if (tellimus.ToodeId == toodeId && tellimus.Kogus == kogus && tellimus.KasutajaId == kasutaja.Id)
                {
                    return false;
                }
            }
            _context.Tellimused.Add(new Tellimus(toodeId, kogus, kasutaja.Id));
            _context.SaveChanges();

            return true;           
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

        /*[HttpPut("muuda/{id}")]
        public Tellimus ChangeActive(int id)
        {
            var tellimus = _context.Tellimused.Find(id);

            if (tellimus == null)
                return null;           

            _context.Tellimused.Update(tellimus);
            _context.SaveChanges();

            return tellimus;
        }*/
    }
}
