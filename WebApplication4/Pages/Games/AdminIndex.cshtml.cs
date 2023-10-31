using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Pages.Games
{
    public class AdminIndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdminIndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Games != null)
            {
                Game = await _context.Games.ToListAsync();
            }
        }
    }
}
