using Universeauto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Universeauto.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository custRepository;
        private ICarRepository carRepository;


        public CustomersController(ICustomerRepository repo, ICarRepository carRepo)
        {
            custRepository = repo;
            carRepository = carRepo;
        }

        public IActionResult Index()
        {
            ViewBag.TitlePage = "Клиенты";
            return View(custRepository.Customers);
        }

        [HttpPost]
        public IActionResult AddOrUpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Cars != null)
                {
                    customer.Cars = customer.Cars
                        .Where(c => c.Id > 0).ToArray();
                }

                if (customer.Id == 0)
                {
                    custRepository.AddCustomer(customer);
                }
                else
                {
                    custRepository.UpdateCustomer(customer);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public IActionResult AddCustomer(Customer customer)
        //{
        //    custRepository.AddCustomer(customer);
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult EditCustomer(long id)
        {
            ViewBag.TitlePage = "Клиент";

            if (ModelState.IsValid)
            {
                var cars = carRepository.Cars;

                Customer customer = id == 0 ? new Customer() : custRepository.GetCustomer(id);

                //IDictionary<long?, List<Car>> customerCars
                //    = customer.Cars?.ToDictionary(car => car.CustomerId)
                //    ?? new Dictionary<long?, List<Car>>();

                IDictionary<long?, List<Car>> customerCars = new Dictionary<long?, List<Car>>();

                foreach (var car in cars)
                {
                    if (car.CustomerId != null)
                    {
                        if (customerCars.ContainsKey(car.CustomerId))
                        {
                            customerCars[car.CustomerId].Add(car);
                        }
                        else
                        {
                            customerCars[car.CustomerId] = new List<Car> { car };
                        }
                    }
                }

                List<Car> CustomerCars = new List<Car>();
                foreach (var listCars in customerCars.Values)
                {
                    foreach (Car car in listCars)
                    {
                        if (car.CustomerId == id)
                        {
                            CustomerCars.Add(car);

                        }
                    }

                }
                ViewData["Cars"] = CustomerCars;
                //ViewBag.Cars = cars.Select(car=>customerCars.ContainsKey(car.Id)
                //    ? customerCars[car.Id]
                //    : new Car {CustomerId = car.Id,Name = car.Name, GovNomber = car.GovNomber });

                return View(customer);
            }
            else
            {
                Customer customer = id == 0 ? new Customer() : custRepository.GetCustomer(id);
                return View(customer);
            }


            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateCustomer(long key)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Cars = carRepository.Cars;
                return View(key == 0 ? new Customer() : custRepository.GetCustomer(key));
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Cars = carRepository.Cars;

                if (customer.Id == 0)
                {
                    custRepository.AddCustomer(customer);

                }
                else
                {
                    custRepository.UpdateCustomer(customer);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteCustomer(Customer customer)
        {
            custRepository.DeleteCustomer(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
