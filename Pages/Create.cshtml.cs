using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public CreateModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
