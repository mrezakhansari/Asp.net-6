namespace Asp06Store.ShopUI.Models
{
    public interface IProductRepository
    {
        List<Product> GetAll(int pageNumber, int pageSize);
    }
}
