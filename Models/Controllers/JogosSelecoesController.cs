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
    public class JogosSelecoesController : ControllerBase
    {
       private readonly DataContext _context;
        public JogosSelecoesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                JogoSelecao jogoSelecao = await _context.TB_JOGOS_SELECOES
                .FirstOrDefaultAsync(eBusca => eBusca.JogoId == id);
                return Ok(jogoSelecao);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }



         
    }
}