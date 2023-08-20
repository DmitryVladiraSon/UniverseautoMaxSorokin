using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Universeauto.Models.Orders;
using Universeauto.Models.Orders.OrderLines;

namespace Universeauto.Controllers
{
    public class ReportsController: Controller
    {
        private readonly IOrdersRepository orderRepository;
        private readonly IOrderLinesRepository orderLinesRepository;

        public ReportsController(IOrdersRepository orderRepository, IOrderLinesRepository orderLinesRepository)
        {
            this.orderRepository = orderRepository;
            this.orderLinesRepository = orderLinesRepository;
        }

        public IActionResult ExportReportOrder(long id)
        {
            Order order = orderRepository.GetOrder(id);
            var orderLines = orderLinesRepository.GetOrderLinesByOrder(order) ;

            using(var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Заказ");

                // Заголовки столбцов
                worksheet.Cells[1, 1].Value = "Id заказа";
                worksheet.Cells[1, 2].Value = "Дата добавления";
                worksheet.Cells[1, 3].Value = "Статус";
                worksheet.Cells[1, 4].Value = "Клиент";
                worksheet.Cells[1, 5].Value = "Машина";
                worksheet.Cells[1, 6].Value = "Дата начала";
                worksheet.Cells[1, 7].Value = "Дата окончания";
                worksheet.Cells[1, 8].Value = "Финальная цена";

                // Заполняем данные из объектa Order
              
                    worksheet.Cells[2, 1].Value = order.Id;
                    worksheet.Cells[2, 2].Value = order.DateAdded;
                    worksheet.Cells[2, 3].Value = order.Status;
                    worksheet.Cells[2, 4].Value = order.Customer?.Name; // Здесь предполагается, что у класса Customer есть свойство Name
                    worksheet.Cells[2, 5].Value = order.Car;
                    worksheet.Cells[2, 6].Value = order.DateStart;
                    worksheet.Cells[2, 7].Value = order.DateFinish;
                    worksheet.Cells[2, 8].Value = order.CustomerPrice;


                worksheet.Cells[4, 1].Value = "Id Услуги";
                worksheet.Cells[4, 2].Value = "Название услуги";
                worksheet.Cells[4, 3].Value = "Стоимость";
                worksheet.Cells[4, 4].Value = "Кол-во";
                worksheet.Cells[4, 5].Value = "Итоговая стоимость услуги";

                int row = 5;
                foreach (var line in orderLines)
                {
                    worksheet.Cells[row, 1].Value = line.Id;
                    worksheet.Cells[row, 2].Value = line.Product.Name;
                    worksheet.Cells[row, 3].Value = line.Product.RetailPrice;
                    worksheet.Cells[row, 4].Value = line.Quantity;
                    worksheet.Cells[row, 5].Value = line.Quantity * line.Product.RetailPrice;
                    row++;
                }

                //Заполнение данными из объекта orderLines

                // Примените авто-подстройку ширины для каждой колонки
                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    worksheet.Column(col).AutoFit();
                }

                // Сохраняем пакет в поток
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);

                    // Возвращаем файл Excel как результат запроса
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Заказ№"+order.Id+".xlsx");
                }
            }
        }

        // Метод для создания отчета в Excel
        public IActionResult ExportOrdersReport()
        {
            // Получаем данные заказов из репозитория (здесь предполагается, что у вас есть реализация IOrderRepository)
            var orders = orderRepository.Orders;

            // Создаем новый пакет Excel
            using (var package = new ExcelPackage())
            {
                // Добавляем новый лист в пакет
                var worksheet = package.Workbook.Worksheets.Add("Заказы");

                // Заголовки столбцов
                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Дата добавления";
                worksheet.Cells[1, 3].Value = "Статус";
                worksheet.Cells[1, 4].Value = "Клиент";
                worksheet.Cells[1, 5].Value = "Машина";
                worksheet.Cells[1, 6].Value = "Дата начала";
                worksheet.Cells[1, 7].Value = "Дата окончания";
                worksheet.Cells[1, 8].Value = "Финальная цена";

                // Заполняем данные из объектов Order
                int row = 2;
                foreach (var order in orders)
                {
                    worksheet.Cells[row, 1].Value = order.Id;
                    worksheet.Cells[row, 2].Value = order.DateAdded;
                    worksheet.Cells[row, 3].Value = order.Status;
                    worksheet.Cells[row, 4].Value = order.Customer?.Name; // Здесь предполагается, что у класса Customer есть свойство Name
                    worksheet.Cells[row, 5].Value = order.Car;
                    worksheet.Cells[row, 6].Value = order.DateStart;
                    worksheet.Cells[row, 7].Value = order.DateFinish;
                    worksheet.Cells[row, 8].Value = order.CustomerPrice;

                    row++;
                }

                // Примените авто-подстройку ширины для каждой колонки
                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    worksheet.Column(col).AutoFit();
                }

                // Сохраняем пакет в поток
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);

                    // Возвращаем файл Excel как результат запроса
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Заказы.xlsx");
                }
            }
        }
    }
}
