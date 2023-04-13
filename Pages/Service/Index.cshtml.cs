using BD9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BD9.Pages.Service
{
    [Authorize]
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<BD9.Models.Service> Servises { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Servises = context.Services.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Services.FindAsync(id);

            if (user != null)
            {
                context.Services.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}