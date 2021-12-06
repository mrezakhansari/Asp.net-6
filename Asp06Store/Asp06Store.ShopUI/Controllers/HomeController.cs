using Asp06Store.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp06Store.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        public IProductRepository productRepository { get; }
        private int pageSize = 1;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(string category = "", int pageNumber = 1)
        {
            var viewModel = new ProductListViewModel
            {
                CurrentCategory = category,
                Data = productRepository.GetAll(pageNumber, pageSize, category)
            };
            return View(viewModel);
        }
    }
}
