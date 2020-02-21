using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionariosController : ControllerBase 
    {

        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }
            

    [HttpGet]
    public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        } 
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionario encontrado :(");
            }
            return Ok(funcionarioBuscado);
        }

    [HttpPost]
    public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            _funcionarioRepository.Cadastrar(novoFuncionario);

            return StatusCode(201);
        }

    [HttpPut]
    public IActionResult PutIdCorpo(FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.IdFuncionario);

            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.AtualizarId(funcionarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
                (
                new
                {
                    mensagem = "Funcionario não encontrado",
                    erro = true
                }
            );
        }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
        {
            _funcionarioRepository.Deletar(id);

            return Ok("Funcionario deletado com sucesso :)");
        }

    }
}
