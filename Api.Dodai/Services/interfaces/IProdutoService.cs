using Api.Dodai.Models.Response;

namespace Api.Dodai.Services.interfaces
{
    public interface IProdutoService
    {
        public Task<ResponseViewModel> getAll();
    }
}
