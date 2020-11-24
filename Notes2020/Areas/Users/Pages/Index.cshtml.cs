using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes2020.Data;

namespace Notes2020.Areas.Users
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public void OnGet()
        {
        }
    }
}
