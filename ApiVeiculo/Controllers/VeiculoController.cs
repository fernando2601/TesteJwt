using Domain.Model;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVeiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _iveiculoService;
        private readonly IVeiculoRepository _iveiculoRepository;

        public VeiculoController(IVeiculoService iveiculoService, IVeiculoRepository iveiculoRepository)
        {
            _iveiculoService = iveiculoService;
            _iveiculoRepository = iveiculoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _iveiculoService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var book = await _iveiculoService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _iveiculoService.CreateAsync(veiculo);

                return Ok(veiculo.Id);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    
        [HttpPut]
        public async Task<IActionResult> Update(string id, Veiculo veiculo)
        {
            var book = await _iveiculoService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _iveiculoService.UpdateAsync(id, veiculo);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var veiculo = await _iveiculoService.GetByIdAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            await _iveiculoService.DeleteAsync(veiculo.Id);
            return NoContent();
        }
    }
}