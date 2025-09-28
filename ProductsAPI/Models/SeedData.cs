using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Models
{
    public class SeedData
    {

        public static void testVerileriDoldur(IApplicationBuilder app)
        {
            var _context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<ProductsContext>();

            if (_context != null)
            {

                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }

                if (!_context.Products.Any())
                {
                    _context.Products.AddRange(
                        new Product { ProductId = 1, ProductName = "IPhone 14", Price = 60000, IsActive = true },
                        new Product { ProductId = 2, ProductName = "IPhone 15", Price = 70000, IsActive = true },
                        new Product { ProductId = 3, ProductName = "IPhone 16", Price = 80000, IsActive = false },
                        new Product { ProductId = 4, ProductName = "IPhone 17", Price = 90000, IsActive = true },
                        new Product { ProductId = 5, ProductName = "IPhone 18", Price = 95000, IsActive = true }
                    );
                    _context.SaveChangesAsync();
                }

            }
        }
    }
}