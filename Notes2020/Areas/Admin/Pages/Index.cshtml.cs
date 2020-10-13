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
    public class IndexModel : PageModel
    {
        private readonly Notes2020.Data.ApplicationDbContext _context;

        public IndexModel(Notes2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; }

        public async Task OnGetAsync()
        {
            Note = await _context.Notes
                .Include(n => n.User).ToListAsync();
        }
    }
}
