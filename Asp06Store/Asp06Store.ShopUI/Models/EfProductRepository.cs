namespace Asp06Store.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        public StoreDbContext StoreDbContext { get; }
        public EfProductRepository(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
        }

        public PageData<Product> GetAll(int pageNumber, int pageSize)
        {
            var result = new PageData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber
                }
            };
            result.Data =  StoreDbContext.Products.Skip((pageNumber -1)*pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = StoreDbContext.Products.Count();
            return result;
        }
    }
}
