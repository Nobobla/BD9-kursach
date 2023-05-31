using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;

namespace BD9.Pages
{
    [Authorize]
    //[IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Order? Order { get; set; }
        public EditModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
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
