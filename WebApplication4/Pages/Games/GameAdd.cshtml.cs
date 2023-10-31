using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Pages.Games
{
    public class GameAddModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Game> Games { get; set; }

        public GameAddModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Games = await _context.Games.ToListAsync();
            var game = _context.Games.Find(id);

            if (game != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./GameNotFound");
            }
        }

        public async Task<IActionResult> OnPostAsync(int id, string serialNumber)
        {
            var game = _context.Games.Find(id);

            if (game != null)
            {
                var newItem = new GameItem
                {
                    SerialNumber = serialNumber
                };

                game.GameItems.Add(newItem);

                // Save changes
                _context.Items.Add(newItem);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToPage("./GameNotFound");
            }
        }
    }
}