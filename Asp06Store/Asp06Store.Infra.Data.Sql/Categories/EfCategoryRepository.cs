namespace Asp06Store.ShopUI.Models
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private StoreDbContext StoreDbContext;
        public EfCategoryRepository(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
        }
        public List<string> GetAllCategories() => StoreDbContext.Categories.Select(c => c.Name).ToList();
    }
}
