using Api.Dodai.Models.DTO;
using Api.Dodai.Models.Response;

namespace Api.Dodai.Services.interfaces
{
    public interface IProdutoService
    {
        public Task<ResponseViewModel> getAll();
        public Task<ResponseViewModel> getById(int id);

        public Task<ResponseViewModel> Add(ProdutoDTO produto);
        public Task<ResponseViewModel> Update(ProdutoDTO produto, int id);
        public Task<ResponseViewModel> Delete(int id);

    }
}
