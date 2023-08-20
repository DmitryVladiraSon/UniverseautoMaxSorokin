using Microsoft.AspNetCore.Mvc;
using Universeauto.Models.Categories;
using Universeauto.Models.Pages;
using Universeauto.Models.Products;

namespace Universeauto.Controllers
{
    public class HomeController : Controller
    {
        private IRroductRepository repository;
        private ICategoryRepository catRepository;
        public HomeController(IRroductRepository repo, ICategoryRepository catRepo)
        {
            repository = repo;
            catRepository = catRepo;
        }
        
        public IActionResult Index(QueryOptions options)
        {
           
            ViewBag.TitlePage = "Услуги";
            ViewBag.Options = options;
            return View(repository.GetProducts(options)); //as IQueryable<Product>
        }

        public IActionResult UpdateProduct(long key)
        {
            ViewBag.Categories = catRepository.Categories;
            ViewBag.TitlePage = "Обновить услугу";
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
