
namespace Asp06Store.ShopUI.Components;

public class CategorySideBoxViewComponent : ViewComponent
{
    private readonly ICategoryRepository categoryRepository;

    public CategorySideBoxViewComponent(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public IViewComponentResult Invoke()
    {
        var currentCategory = RouteData?.Values["category"];
        ViewBag.Category = currentCategory;
        return View(categoryRepository.GetAllCategories());
    }
}

