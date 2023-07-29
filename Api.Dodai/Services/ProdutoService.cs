using Api.Dodai.Entities;
using Api.Dodai.Models.DTO;
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

        public async Task<ResponseViewModel> Add(ProdutoDTO produto)
        {
            try
            {
                if (produto == null) return await Task.FromResult((new ResponseViewModel
                {
                    Status = new StatusResponseViewModel
                    {
                        Code = 400,
                        Message = "Dados Incompletos!"
                    }
                }));

                if (_repository.Entity<Produto>().Exists(x => x.Descricao.Equals(produto.Descricao))) return await Task.FromResult((new ResponseViewModel
                {
                    Status = new StatusResponseViewModel
                    {
                        Code = 400,
                        Message = "Descrição Já Cadastrada!"
                    }
                }));

                var prod = new Produto
                {
                    Descricao = produto.Descricao
                };

                 _repository.Produto.Add(prod);
                _repository.Save();

                return await Task.FromResult(new ResponseViewModel
                {
                    Data = prod,
                    Status = new StatusResponseViewModel
                    {
                        Code = 201,
                        Message = "Sucesso!"
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ResponseViewModel> Delete(int id)
        {
            throw new NotImplementedException();
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

        public Task<ResponseViewModel> getById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel> Update(ProdutoDTO produto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
