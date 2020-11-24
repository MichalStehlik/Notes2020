using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Notes2020.Data;
using Notes2020.Models;

namespace Notes2020.Areas.Admin.Pages
{
    [Authorize(Policy = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Notes2020.Data.ApplicationDbContext _context;
        public SelectList UsersList { get; set; }

        public CreateModel(Notes2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            UsersList = new SelectList(_context.Users.ToList(), nameof(IdentityUser.Id), nameof(IdentityUser.UserName));
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
