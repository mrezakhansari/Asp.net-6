namespace Asp06Store.ShopUI.Models
{
    public interface IProductRepository
    {
        PageData<Product> GetAll(int pageNumber, int pageSize,string category);
        
        Product GetById(int id);
    }

    public interface ICategoryRepository
    {
        List<string> GetAllCategories();
    }
}
