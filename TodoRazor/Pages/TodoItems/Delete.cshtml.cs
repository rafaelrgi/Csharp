using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo;
using Todo.Data;

namespace Todo.Pages_TodoItems
{
    public class DeleteModel : PageModel
    {
        private readonly Todo.Data.ApplicationDbContext _context;

        public DeleteModel(Todo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TodoItem TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TodoItems == null)
            {
                return NotFound();
            }

            var todoitem = await _context.TodoItems.FirstOrDefaultAsync(m => m.Id == id);

            if (todoitem == null)
            {
                return NotFound();
            }
            else 
            {
                TodoItem = todoitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TodoItems == null)
            {
                return NotFound();
            }
            var todoitem = await _context.TodoItems.FindAsync(id);

            if (todoitem != null)
            {
                TodoItem = todoitem;
                _context.TodoItems.Remove(TodoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
