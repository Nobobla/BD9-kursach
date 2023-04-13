using BD9.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BD9.Pages.Account
{
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public SignOutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Account/LogIn");
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        // await _signInManager.SignOutAsync();
        // return RedirectToPage("/Index");
        //}
    }
}
