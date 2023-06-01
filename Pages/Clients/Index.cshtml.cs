using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BD9.Pages.Clients
{
    [Authorize]
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<Client> Clients { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Clients = context.Clients.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Clients.Include(x => x.Orders).FirstOrDefaultAsync(x => x.id == id);

            if (user != null)
            {
                context.Clients.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
