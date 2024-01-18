using MongoRepo.Manager;
using WebApplication1.Interface.Manager;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Manager
{
    public class ProductManager:CommonManager<Product>,IProductManager
    {
        public ProductManager() : base(new ProductRepository())
        {

        }
    }
}
