﻿
namespace Asp06Store.ShopUI.Controllers;

public class BasketController : Controller
{
    private readonly IProductRepository productRepository;
    private readonly Basket  sessionBasket;

    public BasketController(IProductRepository productRepository, Basket sessionBasket)
    {
        this.productRepository = productRepository;
        this.sessionBasket = sessionBasket;
    }

    public IActionResult Index(string returnUrl)
    {
        BasketPageViewModel viewModel = new BasketPageViewModel
        {
            Basket = sessionBasket,
            ReturnUrl = returnUrl
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AddToBasket(int productId, string returnUrl)
    {
        var product = productRepository.GetById(productId);
        sessionBasket.Add(product, 1);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }

    public IActionResult RemoveFromBasket(int productId, string returnUrl)
    {
        var product = productRepository.GetById(productId);
        sessionBasket.Remove(product);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }
}
