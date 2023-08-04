using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universeauto.Models;
using Universeauto.Models.Pages;

namespace Universeauto.Controllers
{
    public class ProfileController : Controller
    {
        private DataContext context;
        private IRepository repository;
        public ProfileController(DataContext context, IRepository repo)
        {
            this.context = context;
            repository = repo;
        }

        public IActionResult Index(QueryOptions options)
        {
			ViewBag.TitlePage = "Заполнение данными";
			ViewBag.Count = context.Products.Count();
            return View(repository.GetProducts(options));
        }


        [HttpPost]
        public IActionResult CreateSeedData(int count)
        {
            try
            {
                ClearData();

                if (count > 0)
                {
                    context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));

                    for (int i = 1; i <= count / 10; i++)
                    {
                        var category = new Category
                        {
                            Name = $"Category-{i}",
                            Description = "Test Data Category"
                        };
                        context.Categories.Add(category);
                        context.SaveChanges();

                        for (int j = 1; j <= 10; j++)
                        {
                            var pprice = (double)(new Random().NextDouble() * (500 - 5) + 5);
                            var rprice = (double)(new Random().NextDouble() * pprice + pprice);

                            var product = new Product
                            {
                                Name = $"Product{i}-{j}",
                                CategoryId = category.Id,
                                PurchasePrice = (decimal)pprice,
                                RetailPrice = (decimal)rprice
                            };
                            context.Products.Add(product);
                        }
                    }

                    context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Обработка и логирование ошибки
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        public IActionResult CreateProductionData()
        {
            ClearData();

            context.Categories.AddRange(new Category[]
            {
                new Category
                {
                    Name = "Детейлинг экстерьера", Description = "",

                        Products = new Product[]
                        {
                    new Product{Name = "Восстановительная полировка автомобиля",
                        PurchasePrice = 5000, RetailPrice = 7000},
                    new Product{Name = "Высокоабразивная полировка автомобиля",
                        PurchasePrice = 10000, RetailPrice = 12000},
                    new Product{Name = "Нанокерамика Krytex на кузов автомобиля",
                        PurchasePrice = 20000, RetailPrice = 20000},
                    new Product{Name = "Жидкое стекло Krytex на кузов автомобиля",
                        PurchasePrice = 4000, RetailPrice = 8000},
                    new Product{Name = "Твердый воск",
                        PurchasePrice = 2000, RetailPrice = 4000},
                        },
                },
                new Category
                {
                    Name = "Детейлинг интерьера", Description = "",

                        Products = new Product[]{
                    new Product{Name = "Деликатная химчистка интерьера",
                        PurchasePrice = 10000, RetailPrice = 12000},
                    new Product{Name = "Шумо- и виброизоляция 4 слоя (салон полностью, включая багажное отделение)",
                        PurchasePrice = 50000, RetailPrice = 70000},
                    new Product{Name = "Консервация интерьера составом GUEON Q² LeatherShield и озонация",
                        PurchasePrice = 5000, RetailPrice = 7000},
                    new Product{Name = "Ремонт и окрас элементов салона от",
                        PurchasePrice = 5000, RetailPrice = 7000},
                    new Product{Name = "Восстановление и защита глянцевых элементов салона от",
                        PurchasePrice = 2000, RetailPrice = 5000},
                        },
                },

                new Category
                {
                    Name = "Стайлинг",
                    Description = "",

                    Products = new Product[]{
                    new Product{Name = "Оклейка виниловой пленкой (смена цвета) от",
                        PurchasePrice = 140000, RetailPrice = 165000},
                    new Product{Name = "Перетяжка салона от",
                        PurchasePrice = 35000, RetailPrice = 40000},
                    new Product{Name = "Антихром элементов экстерьера любой сложности от",
                        PurchasePrice = 8000, RetailPrice = 10000},
                    new Product{Name = "Ламинация и изготовление деталей из карбона от",
                        PurchasePrice = 6000, RetailPrice = 10000},
                    new Product{Name = "Окрас колесных дисков и тормозных суппортов (за единицу) от",
                        PurchasePrice = 1500, RetailPrice = 3000},
                        },
                },


                new Category
                {
                    Name = "Дооснащение автомобиля",
                    Description = "",

                    Products = new Product[]{
                    new Product{Name = "Установка сигнализаций с обратной связью от",
                        PurchasePrice = 3000, RetailPrice = 5000},
                    new Product{Name = "Установка доводчиков дверей от",
                        PurchasePrice = 9000, RetailPrice = 10000},
                    new Product{Name = "Установка штатных мультимедиа систем от",
                        PurchasePrice = 6000, RetailPrice = 8000},
                    new Product{Name = "Установка камер заднего вида и кругового обзора от",
                        PurchasePrice = 6000, RetailPrice = 8000},
                    new Product{Name = "Установка систем ночного видения от",
                        PurchasePrice = 8000, RetailPrice = 10000},
                        },
                },


            });

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult ClearData()
        {
            try
            {
                // Удаляем данные из таблицы "Orders"
                var orders = context.Orders.ToList();
                context.Orders.RemoveRange(orders);

                // Удаляем данные из таблицы "Categories"
                var categories = context.Categories.ToList();
                context.Categories.RemoveRange(categories);

                // Сохраняем изменения в базе данных
                context.SaveChanges();

                // После успешного завершения очистки, перенаправляем на страницу Index
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // В случае возникновения ошибки, можно добавить обработку и логирование
                // ошибки. Например:
                // _logger.LogError(ex, "Ошибка при очистке данных.");
                // И далее можно отобразить сообщение об ошибке на странице
                // или вернуть пользователю на другую страницу с сообщением об ошибке.

                // Перехватываем исключение, чтобы не выдавать ошибку слишком много информации
                // пользователю. Можно также добавить отладочную информацию в лог для последующего
                // анализа и исправления.
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
