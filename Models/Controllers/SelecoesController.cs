using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Data;
using CopaHAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopaApi.Models.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelecoesController : ControllerBase
    {
        private readonly DataContext _context;
        public SelecoesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Selecao selecao = await _context.TB_SELECOES
                .FirstOrDefaultAsync(eBusca => eBusca.Id == id);
                return Ok(selecao);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Selecao> lista = await _context.TB_SELECOES.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }




    }
}