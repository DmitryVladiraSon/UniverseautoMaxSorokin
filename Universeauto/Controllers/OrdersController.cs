using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.X509;
using Universeauto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Universeauto.Controllers
{

    public class OrdersController : Controller
    {
        private IRepository productRepository;
        private ICustomerRepository customerRepository;
        private IOrdersRepository ordersRepository;
        private IOrderLinesRepository orderLinesRepository;
        public OrdersController(IRepository productRepo,
            IOrdersRepository ordersRepo,
            ICustomerRepository customerRepo,
            IOrderLinesRepository orderLinesRepo
            )
        {
            productRepository = productRepo;
            ordersRepository = ordersRepo;
            customerRepository = customerRepo;
            orderLinesRepository = orderLinesRepo;
        }

        public IActionResult Index()
        {
            ViewBag.TitlePage = "Заказы";
            var orders = ordersRepository.Orders;
            return View(ordersRepository.Orders);
        }// => View(ordersRepository.Orders);


        public IActionResult EditOrder(Order order)
        {
            ViewBag.TitlePage = "Заказ";

            Order order1 = order.Id == 0 ? new Order() : ordersRepository.GetOrder(order.Id);


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
            ViewBag.TitlePage = "Создать/Обновить заказ";
            order.Lines = order.Lines
.Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToList();


            var customerPrice = orderLinesRepository.GetOrderLinesByOrder(order)
                .Join(productRepository.Products,
                    line => line.ProductId,
                    product => product.Id,
                    (line, product) => line.Quantity * (product.RetailPrice ))
                .Sum();
            order.CustomerPrice = customerPrice;

            //мне нужно посчитать CustomerSum
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

        [HttpPost]
        public IActionResult AddOrderLine(Order order)
        {
            order.Lines = order.Lines
    .Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToArray();

            ordersRepository.UpdateOrder(order);

            return RedirectToAction(nameof(EditOrder), order);
        }

    }
}
