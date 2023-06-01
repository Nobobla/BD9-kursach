using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD9.Pages
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Order order { get; set; } = new();


        public SelectList EmpsSL { get; set; }
        public SelectList ClientsSL { get; set; }
        public SelectList ServicesSL { get; set; }
        public SelectList ComplaintsSL { get; set; }
        public void ComplaintsSelectList(ApplicationContext context, object value = null)
        {
            var query = context.Complaints.OrderBy(x => x.Discription);
            ComplaintsSL = new SelectList(query.AsNoTracking(), "id", "Discription", value);

        }
        public void ServicesSelectList(ApplicationContext context, object value = null)
        {
            var query = context.Services.OrderBy(x => x.ServiceName);
            ServicesSL = new SelectList(query.AsNoTracking(), "id", "ServiceName", value);

        }
        public void EmpsSelectList(ApplicationContext context, object value = null)
        {
            var query = context.Emps.Include(x => x.ContactInform).OrderBy(x => x.ContactInform.Surname);
            EmpsSL = new SelectList(query.AsNoTracking(), "id", "ContactInform.Surname", value);

        }
        public void ClientsSelectList(ApplicationContext context, object value = null)
        {
            var query = context.Clients.OrderBy(x => x.Surname);
            ClientsSL = new SelectList(query.AsNoTracking(), "id", "Surname", value);

        }

        public CreateModel(ApplicationContext db)
        {
            context = db;
            //EmpsSL = new SelectList(new List<SelectListItem>()); // Инициализация EmpsSL пустым списком
            //EmpsSelectList(context); // Заполнение EmpsSL данными из базы данных
        }
        public IActionResult OnGet()
        {
            EmpsSelectList(context);
            ClientsSelectList(context);
            ServicesSelectList(context);
            ComplaintsSelectList(context);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
