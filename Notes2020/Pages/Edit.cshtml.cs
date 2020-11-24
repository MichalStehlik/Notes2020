using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notes2020.Data;
using Notes2020.Models;
using Notes2020.ViewModels;

namespace Notes2020.Pages
{
    public class EditModel : PageModel
    {
        private readonly Notes2020.Data.ApplicationDbContext _context;

        public EditModel(Notes2020.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NoteIM NoteIM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note item = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            NoteIM.Text = item.Text;
            NoteIM.Title = item.Title;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NoteIM).State = EntityState.Modified;

            try
            {
                Note item = await _context.Notes.FirstOrDefaultAsync(m => m.Id == NoteIM.Id);
                item.Text = NoteIM.Text;
                item.Title = NoteIM.Title;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteIMExists(NoteIM.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NoteIMExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
