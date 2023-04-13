using BD9.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BD9.Pages.Account
{
    
    public class SignInModel : PageModel
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        //private readonly ILogger<SignInModel> _logger;
        //private readonly ApplicationContext _context;

        //public SignInModel(
        //UserManager<User> userManager,
        //SignInManager<User> signInManager,
        //ILogger<SignInModel> logger,
        //ApplicationContext context)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _logger = logger;
        //    _context = context;
        //    //PhysicalActivityDropDownList();
        //}

        //[BindProperty]
        //public string Email { get; set; }

        //[BindProperty]
        //public string Password { get; set; }

        ////[BindProperty]
        ////public string ConfirmPassword { get; set; }
        ////[BindProperty]

        ////public SelectList physicalActivitySL { get; set; }

        ////public void PhysicalActivityDropDownList(object value = null)
        ////{
        ////    var query = _context.PhysicalActivities.OrderBy(x => x.Description);

        ////    physicalActivitySL = new SelectList(query.AsNoTracking(),
        ////    "Id", "Description", value);
        ////}
        //public string ReturnUrl { get; set; }



        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User() { Email = Email, UserName = Email};
        //        var result = await _userManager.CreateAsync(user, Password);

        //        if (result.Succeeded)
        //        {
        //            _logger.LogInformation("User created a new account with password.");

        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            return RedirectToPage("/Index");
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    return Page();
        //}



        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<SignInModel> _logger;
        private readonly ApplicationContext _context;

        public SignInModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<SignInModel> logger,
            ApplicationContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string? ConfirmPassword { get; set; }
        [BindProperty]
        public string? Name { get; set; }
        [BindProperty]
        public int? Age { get; set; }
        [BindProperty]
        public double? Weight { get; set; }
        [BindProperty]
        public double? Height { get; set; }
        [BindProperty]
        public string? Sex { get; set; }
        //[BindProperty]
        //public PhysicalActivity PhysicalActivity { get; set; }

       
        public string ReturnUrl { get; set; }



        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { Email = Email, UserName = Email};
                var result = await _userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
