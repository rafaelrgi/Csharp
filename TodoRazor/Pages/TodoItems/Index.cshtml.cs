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
  public class IndexModel : PageModel
  {
    private readonly Todo.Data.ApplicationDbContext _context;

    public IndexModel(Todo.Data.ApplicationDbContext context)
    {
      _context = context;
    }

    public IList<TodoItem> TodoItem { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.TodoItems != null)
      {
        TodoItem = await _context.TodoItems
          .OrderBy(x => x.Done)
          .ThenBy(x => x.Title)
          .ToListAsync();
      }
    }
  }
}
