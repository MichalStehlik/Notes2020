using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notes2020.Data;
using Notes2020.Models;

namespace Notes2020.Pages
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly Notes2020.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _um;

        public ListModel(Notes2020.Data.ApplicationDbContext context, UserManager<IdentityUser> um)
        {
            _context = context;
            _um = um;
        }

        public IList<Note> Note { get;set; }

        public async Task OnGetAsync()
        {
            var userId1 = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value; // id
            //var user = await _um.GetUserAsync(User); // kompletní user
            //var userId = _um.GetUserId(User); // id
            Note = await _context.Notes.Where(n => n.UserId == userId1).ToListAsync();
        }
    }
}
