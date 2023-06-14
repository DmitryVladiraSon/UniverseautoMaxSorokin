using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.X509;
using Universeauto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Universeauto.Controllers
{

    public class OrdersController : Controller
    {
        private IRepository productRepository;
        private ICustomerRepository customerRepository;
        private IOrdersRepository ordersRepository;
        public OrdersController(IRepository productRepo,
            IOrdersRepository ordersRepo,
            ICustomerRepository customerRepo
            )
        {
            productRepository = productRepo;
            ordersRepository = ordersRepo;
            customerRepository = customerRepo;
        }

        public IActionResult Index()
        {
            var orders = ordersRepository.Orders;
            return View(ordersRepository.Orders);
        }// => View(ordersRepository.Orders);


        public IActionResult EditOrder(Order order)
        {
            Order order1 = order.Id == 0 ? new Order() : ordersRepository.GerOrder(order.Id);


                ViewBag.Customers = customerRepository.Customers;

                var products = productRepository.Products;
                IDictionary<long, OrderLine> linesMap
                    = order1.Lines?.ToDictionary(l => l.ProductId)
                    ?? new Dictionary<long, OrderLine>();
                ViewBag.Lines = products.Select(p => linesMap.ContainsKey(p.Id)
                ? linesMap[p.Id]
                : new OrderLine { Product = p, ProductId = p.Id, Quantity = 0 });
               
            
            return View(order1);


        }

        [HttpPost]
        public IActionResult AddOrUpdateOrder(Order order)
        {

                order.Lines = order.Lines
    .Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToArray();
                if (order.Id == 0)
                {
                    ordersRepository.AddOrder(order);
                }
                else
                {
                    ordersRepository.UpdateOrder(order);
                }
                return RedirectToAction("Index");


        }
    

        [HttpPost]
        public IActionResult DeleteOrder(Order order)
        {
            ordersRepository.DeleteOrder(order);
            return RedirectToAction(nameof(Index));
        }
    }
}
