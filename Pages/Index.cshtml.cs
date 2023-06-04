using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using OfficeOpenXml;

namespace BD9.Pages.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<Order> Orders { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Orders = context.Orders
                .Include(x => x.Service)
                .Include(x => x.Emp).ThenInclude(x=>x.ContactInform)
                .Include(x => x.Complaints)
                .Include(x => x.Client)
                .Include(x => x.Complaints)
                .AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Orders.Include(x => x.Service).Include(x => x.Emp).FirstOrDefaultAsync(x => x.id == id);

            if (user != null)
            {
                context.Orders.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostExportToExcel(CancellationToken ct)
        {

            var allOrders = context.Orders
                .Include(x => x.Service)
                .Include(x => x.Emp).ThenInclude(x => x.ContactInform)
                .Include(x => x.Complaints)
                .Include(x => x.Client)
                .Include(x => x.Complaints)
                .AsNoTracking().ToList();

            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Orders");
                worksheet.Cells[1, 1].Value = "Услуга";
                worksheet.Cells[1, 2].Value = "Клиент";
                worksheet.Cells[1, 3].Value = "Мастер";
                worksheet.Cells[1, 4].Value = "Гарантия";
                worksheet.Cells[1, 5].Value = "Описание";
                worksheet.Cells[1, 6].Value = "Дата обращения";
                worksheet.Cells[1, 7].Value = "Жалоба";

                int row = 2;
                foreach (var ord in allOrders)
                {
                    worksheet.Cells[row, 1].Value = ord.Service.ServiceName;
                    worksheet.Cells[row, 2].Value = ord.Client.Surname;
                    worksheet.Cells[row, 3].Value = ord.Emp.ContactInform.Name;
                    worksheet.Cells[row, 4].Value = ord.Warranty;
                    worksheet.Cells[row, 5].Value = ord.Description;
                    worksheet.Cells[row, 6].Value = ord.DateIssue;
                    worksheet.Cells[row, 7].Value = ord.Complaints.Discription;

                    row++;
                }

                using (var range = worksheet.Cells[1, 1, 1, 7])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                package.Save();
            }

            stream.Position = 0;
            string fileName = "Orders.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


        }


    }
}
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using BD9.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using OfficeOpenXml;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.ComponentModel;

//namespace BD9.Pages.Orders
//{
//    [Authorize]
//    public class IndexModel : PageModel
//    {
//        private readonly ApplicationContext context;
//        public List<Order> Orders { get; private set; } = new();

//        public IndexModel(ApplicationContext db)
//        {
//            context = db;
//        }

//        public void OnGet()
//        {
//            Orders = context.Orders.AsNoTracking().ToList();
//        }

//        public async Task<IActionResult> OnPostDeleteAsync(int id)
//        {
//            var order = await context.Orders.FindAsync(id);

//            if (order != null)
//            {
//                context.Orders.Remove(order);
//                await context.SaveChangesAsync();
//            }

//            return RedirectToPage();
//        }

//        public IActionResult OnPostExportToExcel()
//        {
//            // Получаем данные из базы данных
//            List<Order> data = context.Orders.AsNoTracking().ToList();

//            // Создаем новый пакет Excel
//            ExcelPackage package = new ExcelPackage();

//            // Создаем новый лист Excel
//            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Orders");
//            // Заполняем заголовки столбцов
//            worksheet.Cells[1, 1].Value = "Наименование услуги";
//            worksheet.Cells[1, 2].Value = "Клиент";
//            worksheet.Cells[1, 3].Value = "Мастер";
//            worksheet.Cells[1, 4].Value = "Дата принятия заказа";
//            worksheet.Cells[1, 5].Value = "Гарантия";
//            worksheet.Cells[1, 6].Value = "Описание состояния телефона";
//            worksheet.Cells[1, 7].Value = "Жалоба";

//            // Заполняем данные
//            for (int i = 0; i < data.Count; i++)
//            {
//                worksheet.Cells[i + 2, 1].Value = data[i].ServiceId;
//                worksheet.Cells[i + 2, 2].Value = data[i].ClientId;
//                worksheet.Cells[i + 2, 3].Value = data[i].EmploeeId;
//                worksheet.Cells[i + 2, 4].Value = data[i].DateIssue;
//                worksheet.Cells[i + 2, 5].Value = data[i].Warraty;
//                worksheet.Cells[i + 2, 6].Value = data[i].Description;
//                worksheet.Cells[i + 2, 7].Value = data[i].ComplaintId;
//            }

//            // Сохраняем файл Excel
//            byte[] fileContents = Encoding.UTF8.GetBytes(package.GetAsByteArray());
//            string fileName = "Orders.xlsx";

//            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
//        }
//    }
//}


