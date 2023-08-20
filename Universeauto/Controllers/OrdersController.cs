using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.X509;
using Universeauto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Universeauto.Models.Products;
using Universeauto.Models.Customers;
using Universeauto.Models.Orders;
using Universeauto.Models.Orders.OrderLines;

namespace Universeauto.Controllers
{

    public class OrdersController : Controller
    {
        private IRroductRepository productRepository;
        private ICustomerRepository customerRepository;
        private IOrdersRepository ordersRepository;
        private IOrderLinesRepository orderLinesRepository;
        private DataContext context;

        public OrdersController(IRroductRepository productRepo,
            IOrdersRepository ordersRepo,
            ICustomerRepository customerRepo,
            IOrderLinesRepository orderLinesRepo,
            DataContext _context
            )
        {
            productRepository = productRepo;
            ordersRepository = ordersRepo;
            customerRepository = customerRepo;
            orderLinesRepository = orderLinesRepo;
            context = _context;
        }

        public IActionResult Index()
        {
            ViewBag.TitlePage = "Заказы";
            var orders = ordersRepository.Orders;
            return View(ordersRepository.Orders);
        }// => View(ordersRepository.Orders);


        public IActionResult EditOrder(long orderId)
        {
            ViewBag.TitlePage = "Заказ";

            Order order = orderId == 0 ? new Order() : ordersRepository.GetOrder(orderId);


            ViewBag.Customers = customerRepository.Customers;

            var products = productRepository.Products;
            IDictionary<long, OrderLine> linesMap
                = order.Lines?.ToDictionary(l => l.ProductId)
                ?? new Dictionary<long, OrderLine>();
            ViewBag.Lines = products.Select(p => linesMap.ContainsKey(p.Id)
            ? linesMap[p.Id]
            : new OrderLine { Product = p, ProductId = p.Id, Quantity = 0 });


            return View(order);


        }


        [HttpPost]  
        public IActionResult AddOrUpdateOrder(Order order)
        {
            ViewBag.TitlePage = "Создать/Обновить заказ";
            order.Lines = order.Lines
.Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToList();
            
            foreach(var line in order.Lines)
            {
                line.Product = productRepository.GetProduct(line.ProductId);
            }

            decimal sum = 0;
foreach(var line in order.Lines)
            {
                sum +=line.Quantity * line.Product.RetailPrice ;
            }
            order.CustomerPrice = sum;
            if (order.DateAdded == null)
            {
                order.DateAdded = DateTime.Now;

            }

            //мне нужно посчитать CustomerSum
            if (order.Id == 0)
            {
                    ordersRepository.AddOrder(order);
            }
            else
            {
                ordersRepository.UpdateOrder(order);
            }

            context.SaveChanges();

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

            return RedirectToAction(nameof(EditOrder), new {  orderId = order.Id});
        }

    }
}
