using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalhador.WebApi.Data;
using Trabalhador.WebApi.Models;

namespace Trabalhador.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class trabalhadorController : ControllerBase
    {
        private readonly IRepository _context;
        public trabalhadorController(IRepository context)
        {
            _context = context;
        }

        [HttpGet("ListaTrabalhadores")]
        public IActionResult GetLista()
        {
            var model = _context.GetTrabalhadores();
            return Ok(model);

        }

        [HttpGet("{nome}")]
        public IActionResult GetTrabalhadorByNome(string nome)
        {
            var model = _context.GetTrabalhador(nome);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> post(TrabalhadorClasse model)
        {
            try
            {
                model.CustoTotal = model.CalcularGastos(model.CargaDeTrabalho, model.ValeTransporte);
                _context.Add(model);

                if(await _context.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch(Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            } 

            return BadRequest();
        }

        [HttpDelete("ListaTrabalhadores/{nome}/Delete")]
        public async Task<IActionResult> delete(string nome)
        {
            try
            {               
                var model = _context.GetTrabalhador(nome);

                if(model != null)
                {
                    _context.Delete(model);
                }
                else
                {
                    return BadRequest("Não encontrado");
                }
                

                if(await _context.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch(Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            } 

            return BadRequest();
        }

        [HttpPut("ListaTrabalhadores/{nome}/Update")]
        public async Task<IActionResult> update(TrabalhadorClasse model, string nome)
        {
            try
            {
                var oldModel = _context.GetTrabalhador(nome);
                oldModel.Nome = model.Nome;
                oldModel.Sobrenome = model.Sobrenome;
                oldModel.ValeTransporte = model.ValeTransporte;
                oldModel.CargaDeTrabalho = model.CargaDeTrabalho;
                
                oldModel.CustoTotal = oldModel.CalcularGastos(oldModel.CargaDeTrabalho, oldModel.ValeTransporte);
                _context.Update(oldModel);

                if(await _context.SaveChangesAsync())
                {
                    return Ok(oldModel);
                }
            }
            catch(Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            } 

            return BadRequest();
        }
    }
}