using Microsoft.AspNetCore.Mvc;
using Universeauto.Models.Categories;

namespace Universeauto.Controllers
{
    public class CategoriesController : Controller
	{
		private ICategoryRepository repository;

		public CategoriesController(ICategoryRepository repo)
			=> repository = repo;

		public IActionResult Index()
		{
			ViewBag.TitlePage = "Категории услуг";
			return View(repository.Categories);
		}

		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			if (ModelState.IsValid)
			{
				repository.AddCategory(category);
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}

		}
		public IActionResult EditCategory(long id)
		{
			ViewBag.EditId = id;
            ViewBag.TitlePage = "Редактирование";

            return View("Index", repository.Categories);
		}

		[HttpPost]
		public IActionResult UpdateCategory(Category category)
		{
            if (ModelState.IsValid)
            {
				repository.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
		}

		[HttpPost]
		public IActionResult DeleteCategory(Category category)
		{
			repository.DeleteCategory(category);
			return RedirectToAction(nameof(Index));
		}

	}
}

