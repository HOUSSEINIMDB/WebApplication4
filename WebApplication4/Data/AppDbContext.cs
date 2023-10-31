using Microsoft.EntityFrameworkCore;
using WebApplication4.Model;

namespace WebApplication4.Data
{
    public class AppDbContext : DbContext
    {
        private readonly ILogger<AppDbContext> _logger;
        public DbSet<Game> Games { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<GameItem> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, ILogger<AppDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        public async Task CartsLog()
        {
            try
            {
                _logger.LogInformation("Logging all Cart IDs:");

                var cartIds = await Carts.Select(cart => cart.CartId).ToListAsync();

                foreach (var cartId in cartIds)
                {
                    _logger.LogInformation("Cart ID: {CartId}", cartId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while logging Cart IDs.");
            }
        }
    }
}