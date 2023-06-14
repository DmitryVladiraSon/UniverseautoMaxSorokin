using Microsoft.AspNetCore.Mvc;
using Universeauto.Models;

namespace Universeauto.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository carRepository;
        private ICustomerRepository customerRepository;

        public CarsController(ICarRepository carRepo, ICustomerRepository customerRepository = null)
        {
            carRepository = carRepo;
            this.customerRepository = customerRepository;
        }

        public IActionResult Index() {
            ViewBag.Customers = customerRepository.Customers;

            return View(carRepository.Cars);
        }
        public IActionResult Test() => View();

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            if (ModelState.IsValid)
            {
                carRepository.AddCar(car);
            return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult EditCar(long id)
        {
            ViewBag.EditId = id;
            ViewBag.Customers = customerRepository.Customers;
            return View("Index", carRepository.Cars);
        }

        [HttpPost]
        public IActionResult UpdateCar(Car car)
        {
            if (ModelState.IsValid)
            {
                carRepository.UpdateCar(car);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));


        }

        [HttpPost]
        public IActionResult DeleteCar(Car car)
        {
            carRepository.DeleteCar(car);
        return RedirectToAction(nameof(Index));
        }

    }
}
