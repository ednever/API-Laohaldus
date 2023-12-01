using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TellimusArvesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TellimusArvesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("lisa")]
        public bool Add([FromBody] string[] massiiv)
        {
            int[] tellimusId = new int[massiiv.Length];
            for (int i = 0; i < massiiv.Length; i++)
            {
                string[] parts = massiiv[i].Split('.');
                
                foreach (var tellimus in _context.Tellimused)
                {
                    if (tellimus.ToodeId == int.Parse(parts[0])) // && tellimus.Kogus == int.Parse(parts[1])
                    {
                        tellimusId[i] = tellimus.Id;

                    }
                }
            }

            foreach (var id in tellimusId) 
            {
                _context.TellimusedArves.Add(new TellimusArves(id, _context.Arved.ToList().Last().Id));
            }
            _context.SaveChanges();
            return true;
        }
    }
}