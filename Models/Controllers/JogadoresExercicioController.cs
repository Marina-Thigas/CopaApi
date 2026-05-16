using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using CopaHAS.Models;
using CopaHAS.Models.Enuns;
using Microsoft.AspNetCore.Mvc;

namespace CopaHAS.Models.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresExercicioController : ControllerBase
    {
        private static List<Jogador> listaJogadores = new List<Jogador>()
        {
            new Jogador(){Id = 1, Nome = "Hugo Souza", NumeroCamisa=1, Posicao = "Goleiro", Status= Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 2, Nome = "Yuri Alberto", NumeroCamisa=9, Posicao = "Atacante", Status= Models.Enuns.statusJogador.Titular}, 
            new Jogador(){Id = 3, Nome = "Danilo", NumeroCamisa = 2, Posicao = "Lateral Direito", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 4, Nome = "Marquinhos", NumeroCamisa = 4, Posicao = "Zagueiro", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 5, Nome = "Casemiro", NumeroCamisa = 5, Posicao = "Volante", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 6, Nome = "Alex Sandro", NumeroCamisa = 6, Posicao = "Lateral Esquerdo", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 7, Nome = "Lucas Paquetá", NumeroCamisa = 7, Posicao = "Meio Campo", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 8, Nome = "Bruno Guimarães", NumeroCamisa = 8, Posicao = "Meio Campo", Status = Models.Enuns.statusJogador.Reserva},
            new Jogador(){Id = 9, Nome = "Richarlisson", NumeroCamisa = 10, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 10, Nome = "Vinicius Jr", NumeroCamisa = 11, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
            new Jogador(){Id = 11, Nome = "Rodrygo", NumeroCamisa = 19, Posicao = "Atacante", Status = Models.Enuns.statusJogador.DepartamentoMedico},
            new Jogador(){Id = 12, Nome = "Alisson", NumeroCamisa = 23, Posicao = "Goleiro", Status = Models.Enuns.statusJogador.NaoRelacionado}
        };

        //Ex a)
        [HttpGet("GetByNome/{nome}")]
        public IActionResult ObterJogadorPorNome(string nome)
        {
            Jogador jogador = listaJogadores.Find(j => j.Nome.ToLower().Equals(nome.ToLower()));
            if(jogador != null)
                return Ok(jogador);
            else
                return BadRequest("NotFound");
        }

        // Ex. b)
        [HttpGet("GetTitulares")]
        public IActionResult ObterTitulares()
        {
            List<Jogador> lJogadores = listaJogadores.FindAll(j => j.Status.Equals(Models.Enuns.statusJogador.Titular));
            return Ok(lJogadores.OrderByDescending(j => j.NumeroCamisa));
        }

        // Ex. c)
        [HttpGet("GetEstatisticas")]
        public IActionResult ObterEstatisticas()
        {
            int contaJog = listaJogadores.Count();
            int somaNumCamisa = listaJogadores.Sum(x => x.NumeroCamisa);
            
            Dictionary<string, int> DicEstatisticas = new Dictionary<string, int>();

            DicEstatisticas["quantidadeJogadores"] = contaJog;
            DicEstatisticas["somatorioNumCamisa"] = somaNumCamisa;
            
            return Ok(DicEstatisticas);
        }

        // Ex. d)
        [HttpPost("PostValidacao")]
        public IActionResult PostarComValidacao(Jogador j){
            if(j.NumeroCamisa <= 100)
            {
                listaJogadores.Add(j);
                return Ok(listaJogadores);
            }
            else
                return BadRequest("O número da camisa deve ser menor que 101!");
        }

        // Ex. e)
        [HttpPost("PostValidacaoNome")]
        public IActionResult PostarComValidacaoNome(Jogador j){
            if(j.Posicao != "Goleiro" && j.NumeroCamisa == 1)
                return BadRequest("Somente o goleiro pode ter o número da camisa igual a 1!");

            listaJogadores.Add(j);
            return Ok(listaJogadores);
        }

        // Ex. f)
        [HttpGet("GetByStatus/{statusDigitadoId}")]
        public IActionResult ObterJogadorPorStatus(int statusDigitadoId){
            statusJogador statusEnum = (statusJogador)statusDigitadoId;

            List<Jogador> lJogadores = listaJogadores.FindAll(j => j.Status == statusEnum);

            return Ok(lJogadores);
        }


    }
}