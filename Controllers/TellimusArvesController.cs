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
            /*int[] beforeDotArray = new int[massiiv.Length];
            int[] afterDotArray = new int[massiiv.Length];

            for (int i = 0; i < massiiv.Length; i++)
            {
                string[] parts = massiiv[i].Split('.');

                beforeDotArray[i] = beforeDecimal;
                afterDotArray[i] = afterDecimal;


            }*/

            /*foreach (int toodeid in massiiv)
            {
                var tellimus = _context.Tellimused.FirstOrDefault(obj => obj.ToodeId == toodeid);
                _context.TellimusedArves.Add(new TellimusArves(tellimus.Id, _context.Arved.ToList().Last().Id));
            }
            _context.SaveChanges();*/

            return true;
        }
    }
}

//<?php if (isset($_GET['code'])) { die(highlight_file(__FILE__, 1)); } ?>
//Добавить ссылку на XML файл