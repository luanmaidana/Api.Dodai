using Api.Dodai.Repository.Interface;

namespace SgppAPI.Repository
{
  public interface IUnitOfWork
    {
        IDodaiRepository GetDodaiRepository();
    }
}