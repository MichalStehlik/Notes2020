using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Notes2020.Data;
using Notes2020.Models;
using Notes2020.ViewModels;

namespace Notes2020.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Notes2020.Data.ApplicationDbContext _context;

        public CreateModel(Notes2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NoteIM Input { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var UserId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

            Note newNote = new Note
            {
                Title = Input.Title,
                Text = Input.Text,
                UserId = UserId
            };

            _context.Notes.Add(newNote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
