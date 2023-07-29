using Api.Dodai.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dodai.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProutoController : ControllerBase
    { 
        private readonly IProdutoService _produtoService;

        public ProutoController(IProdutoService produtoService)
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
    }
}
