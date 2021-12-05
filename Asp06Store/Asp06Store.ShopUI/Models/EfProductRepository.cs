namespace Asp06Store.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        public StoreDbContext StoreDbContext { get; }
        public EfProductRepository(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
        }

        public List<Product> GetAll(int pageNumber,int pageSize)
        {
            return StoreDbContext.Products.Skip((pageNumber -1)*pageSize).Take(pageSize).ToList();
        }
    }
}
