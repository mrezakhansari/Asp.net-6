namespace Asp06Store.ShopUI.Models
{
    public interface IProductRepository
    {
        PageData<Product> GetAll(int pageNumber, int pageSize);
    }
}
