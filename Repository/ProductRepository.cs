using MongoRepo.Context;
using MongoRepo.Repository;
using WebApplication1.Database;
using WebApplication1.Interface.Repository;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new ApplicationDbContext(DbConnection.ConnectionString,DbConnection.DBName))
        {

        }
    }
}
