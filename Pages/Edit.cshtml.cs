using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BD9.Pages
{
    [Authorize]
    //[IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Order? Order { get; set; }

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
        public EditModel(ApplicationContext db)
        {
          
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EmpsSelectList(context);
            ClientsSelectList(context);
            ServicesSelectList(context);
            ComplaintsSelectList(context);

            Order = await context.Orders.FindAsync(id);

            if (Order == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Orders.Update(Order!);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
