using Api.Dodai.Models.DTO;
using Api.Dodai.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dodai.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoController : ControllerBase
    { 
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _produtoService.getAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] ProdutoDTO produto)
        {
            try
            {
                var response = await _produtoService.Add(produto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message}");
            }
        }
    }
}
