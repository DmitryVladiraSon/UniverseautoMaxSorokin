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

		public IActionResult Index()
		{
			ViewBag.TitlePage = "Машины";

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

        [HttpPost]
        public IActionResult AddOrUpdateCar(Car car)
        {
            if (ModelState.IsValid)
            {

                if (car.Id == 0)
                {
                    carRepository.AddCar(car);
                }
                else
                {
                    carRepository.UpdateCar(car);
                }
                return RedirectToAction(nameof(Index));

			}
			else
			{
                return RedirectToAction(nameof(EditCar),car);

            }
        }


        public IActionResult EditCar(Car car)
		{
			ViewBag.EditId = car.Id;
			ViewBag.Customers = customerRepository.Customers;
            ViewBag.TitlePage = "Редактировать машину";

            ViewBag.AutoClasses = new List<AutoClass>
    {
        new AutoClass("C-Класс"),
        new AutoClass("E-Класс"),
        new AutoClass("SUV, S-Класс"),
        new AutoClass("Внедорожник")
    };

           if(car.Id != 0)
			{
                car = carRepository.GetCar(car.Id);

            }
            return View(car);
            

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
