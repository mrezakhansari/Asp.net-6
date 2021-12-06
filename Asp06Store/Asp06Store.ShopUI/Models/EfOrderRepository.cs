namespace Asp06Store.ShopUI.Models
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly StoreDbContext storeDbContext;

        public EfOrderRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public void Save(Order order)
        {
            // yani chizi ke az ghabl boode va niazi nist ke to dobare beri oon ro sabt koni
            // baraya hamin az dastoore zir estefade mikonim. faghat khode order va order detail ro baramoon
            // ezafe mikone
            storeDbContext.AttachRange(order.orderDetails.Select(d => d.Product));
            storeDbContext.Orders.Add(order);
            storeDbContext.SaveChanges();
        }
    }
}
