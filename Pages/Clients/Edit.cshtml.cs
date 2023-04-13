using System.Threading.Tasks;

using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BD9.Pages.Clients
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Client? Person { get; set; }
        public EditModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Person = await context.Clients.FindAsync(id);

            if (Person == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Clients.Update(Person!);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
