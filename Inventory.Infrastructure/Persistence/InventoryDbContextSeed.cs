using Inventory.Domain.Entities;
using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects;
using Inventory.Infrastructure.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{

    public static class InventoryDbContextSeed
    {

        public static async Task SeedSampleProductDataAsync(InventoryDbContext context)
        {
            // Seed, if necessary
            if (!context.Products.Any())
            {
                //context.Products.Add(new Product("Dell-1530",new Barcode("1111"),"It is a laptop",new Weight(5),ProductStatus.InStock,new Category("Computer")));
                //context.Products.Add(new Product("Dell-1740", new Barcode("1112"), "It is a laptop", new Weight(2), ProductStatus.Damaged, new Category("Computer")));
                //context.Products.Add(new Product("Dell-1530", new Barcode("1113"), "It is a laptop", new Weight(3), ProductStatus.Sold, new Category("Computer")));
                //context.Products.Add(new Product("Dell-4350", new Barcode("1114"), "It is a laptop", new Weight(1), ProductStatus.InStock, new Category("Computer")));

                await context.SaveChangesAsync();
            }
        }
    }
}