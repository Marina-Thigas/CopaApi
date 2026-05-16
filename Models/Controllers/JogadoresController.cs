using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CopaHAS.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopaHAS.Models.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresController : ControllerBase
    {

        private readonly DataContext _context;

        public JogadoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Jogador j = await _context.TB_JOGADORES.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(j);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + "-" + ex.InnerException);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Jogador> lista = await _context.TB_JOGADORES.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Jogador novoJogador)
        {
            try
            {
                if (novoJogador.NumeroCamisa >= 100)
                    return BadRequest("Número da camisa não pode ser maior/igual a 100.");

                await _context.TB_JOGADORES.AddAsync(novoJogador);
                await _context.SaveChangesAsync();

                return Ok(novoJogador.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

    [HttpPut]
public async Task<IActionResult> Update(Jogador jogador)
        {
            try
            {
                if (jogador.NumeroCamisa >= 100)
                    return BadRequest("Número da camisa não pode ser maior/igual a 100.");
                _context.TB_JOGADORES.Update(jogador);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        /*
        private static List<Jogador> listaJogadores = new List<Jogador>()
        {
            new Jogador(){Id = 1, Nome = "Hugo Souza", NumeroCamisa=1, Posicao = "Goleiro", Status= Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 2, Nome = "Yuri Alberto", NumeroCamisa=1, Posicao = "Atacante", Status= Models.Enuns.statusJogador.Titular}, 
            new Jogador(){Id = 3, Nome = "Fagner", NumeroCamisa = 23, Posicao = "Lateral Direito", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 4, Nome = "Gustavo Henrique", NumeroCamisa = 13, Posicao = "Zagueiro", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 5, Nome = "Félix Torres", NumeroCamisa = 3, Posicao = "Zagueiro", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 6, Nome = "Matheus Bidu", NumeroCamisa = 21, Posicao = "Lateral Esquerdo", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 7, Nome = "Raniele", NumeroCamisa = 14, Posicao = "Volante", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 8, Nome = "Maycon", NumeroCamisa = 7, Posicao = "Meio Campo", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 8, Nome = "Rodrigo Garro", NumeroCamisa = 10, Posicao = "Meia", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 10, Nome = "Romero", NumeroCamisa = 11, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 11, Nome = "Wesley", NumeroCamisa = 36, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
        };

        [HttpGet("GetAll")]
        public IActionResult ObterJogadores()
        {
            List<Jogador> lista = listaJogadores;
            return Ok(lista);
        }

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            return Ok(listaJogadores[0]);    
        }

        [HttpPost]
        public IActionResult InserirJogador(Jogador j)
        {
            listaJogadores.Add(j);
            return Ok(listaJogadores);
        }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Jogador> listaFinal = listaJogadores.OrderBy(j => j.Nome).ToList();

            return Ok(listaFinal);
        }

        [HttpPut("AtualizarJogador")]
        public IActionResult Atualizar(Jogador j)
        {
            Jogador jEncontrado = listaJogadores.Find(jBusca => jBusca.Id == j.Id );

            if(jEncontrado == null)
                return BadRequest("Jogador não encontrado");

            jEncontrado.Nome = j.Nome;
            jEncontrado.NumeroCamisa = j.NumeroCamisa;

            return Ok(listaJogadores);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            listaJogadores.RemoveAll(j => j.Id == id);
            return Ok(listaJogadores);
        }

        [HttpGet("GetByNomeAproximado/{nome}")]
        public IActionResult GetByNomeAproximado(string nome)
        {
            List<Jogador> lista =
                listaJogadores.FindAll(j =>
                j.Nome.ToLower().Contains(nome.ToLower()));
            return Ok(lista);
        }*/
    }
}