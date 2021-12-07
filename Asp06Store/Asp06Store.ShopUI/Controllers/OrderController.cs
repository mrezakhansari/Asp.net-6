using Microsoft.AspNetCore.Mvc;

namespace Asp06Store.ShopUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly Basket basket;

        public OrderController(IOrderRepository orderRepository,Basket basket)
        {
            this.orderRepository = orderRepository;
            this.basket = basket;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(CheckouViewModel model)
        {
            if (!basket.Items.Any())
            {
                ModelState.AddModelError("","There is no item in basket");
            }
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Address = model.Address,
                    Name = model.Name,
                    City = model.City
                };
                foreach (var item in basket.Items)
                {
                    order.orderDetails.Add(new OrderDetail
                    {
                        Product = item.Product,
                        Quantity = item.Quantity
                    });
                }
                orderRepository.Save(order);
                basket.Clear();
                return RedirectToAction("Complete");
            }
            return View(model);
        }
        public IActionResult Complete()
        {
            return View();
        }
    }
}
