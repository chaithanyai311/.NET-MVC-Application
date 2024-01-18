using MongoRepo.Interfaces.Manager;
using MongoRepo.Interfaces.Repository;
using WebApplication1.Models;

namespace WebApplication1.Interface.Repository
{
    public interface IProductRepository:ICommonRepository<Product>
    {
    }
}
