using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            Orders = context.Orders.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Orders.FindAsync(id);

            if (user != null)
            {
                context.Orders.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
