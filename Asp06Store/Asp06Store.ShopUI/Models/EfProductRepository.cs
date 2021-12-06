namespace Asp06Store.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        public StoreDbContext StoreDbContext { get; }
        public EfProductRepository(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
        }

        public PageData<Product> GetAll(int pageNumber, int pageSize,string category)
        {
            var result = new PageData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber
                }
            };
            result.Data =  StoreDbContext.Products.Where(c=>string.IsNullOrWhiteSpace(category) || c.Category == category).Skip((pageNumber -1)*pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = StoreDbContext.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category == category).Count();
            return result;
        }

        public List<string> GetAllCategories() => StoreDbContext.Products.Select(c=>c.Category).Distinct().ToList();

        public Product GetById(int id)
        {
            return StoreDbContext.Products.SingleOrDefault(c=>c.Id == id);
        }
    }
}
