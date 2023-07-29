using Api.Dodai.Entities;
using Api.Dodai.Models.Response;
using Api.Dodai.Repository.Interface;
using Api.Dodai.Services.interfaces;

namespace Api.Dodai.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IDodaiRepository _repository;

        public ProdutoService(IDodaiRepository repository)
        {
            _repository = repository;
        }

        public Task<ResponseViewModel> getAll()
        {
            try
            {
                var result = _repository.Produto.FindAll().ToList();

                return Task.FromResult(new ResponseViewModel
                {
                    Data = result,
                    Status = new StatusResponseViewModel
                    {
                        Code = 200,
                        Message = "Sucesso!"
                    }
                });
            }
            catch (Exception)
            {
                return Task.FromResult(new ResponseViewModel
                {
                    Status = new StatusResponseViewModel
                    {
                        Code = 500,
                        Message = "Erro ao buscar produtos!"
                    }
                });
            }
        }
    }
}
