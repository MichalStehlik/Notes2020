using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notes2020.Data;
using Notes2020.Models;

namespace Notes2020.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Notes2020.Data.ApplicationDbContext _context;

        public DetailsModel(Notes2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Notes
                .Include(n => n.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
