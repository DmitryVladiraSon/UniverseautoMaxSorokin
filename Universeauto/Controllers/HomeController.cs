using Microsoft.AspNetCore.Mvc;
using Universeauto.Models;

namespace Universeauto.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ICategoryRepository catRepository;
        public HomeController(IRepository repo, ICategoryRepository catRepo)
        {
            repository = repo;
            catRepository = catRepo;
        }

        public IActionResult Index()
        {
            // System.Console.Clear();

            return View(repository.Products);//as IQueryable<Product>
        }

        public IActionResult UpdateProduct(long key)
        {
            ViewBag.Categories = catRepository.Categories;
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0 )
                {
                    repository.AddProduct(product);
                }
                else
                {
                    repository.UpdateProduct(product);

                }
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Categories = catRepository.Categories;

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
