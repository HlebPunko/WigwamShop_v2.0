using Catalog.Domain.Entities;
using Catalog.Infostructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infostructure
{
    public class DataSeeder
    {
        private readonly CatalogDbContext _context;

        public DataSeeder(CatalogDbContext context)
        {
            _context = context;
        }

        private static IEnumerable<Wigwam> GetWigwams() => new List<Wigwam>()
        {
            new Wigwam()
            {
                Name = "Вигвам 1, классический вариант", 
                Description = "Очень удобный вигвам с своими особенностями для детей",
                Path = "./img/wigwams/1.jpg",
                Price = 300m,
                Weight = 1.1F,
                Width = 150F,
                Height = 200F,
            },
            new Wigwam()
            {
                Name = "Вигвам 2, отличный вариант",
                Description = "Очень удобный и отличный вигвам для детей",
                Path = "./img/wigwams/2.jpg",
                Price = 350m,
                Weight = 1.2F,
                Width = 160F,
                Height = 180F
            },
            new Wigwam()
            {
                Name = "Вигвам 3, модерн классика",
                Description = "Очень удобный и современный вигвам для детей",
                Path = "./img/wigwams/3.jpg",
                Price = 310m,
                Weight = 0.9F,
                Width = 160F,
                Height = 210F
            },
            new Wigwam()
            {
                Name = "Вигвам 4, красивый просто",
                Description = "Очень удобный и красивый вигвам с своими особенностями",
                Path = "./img/wigwams/4.jpg",
                Price = 330m,
                Weight = 1.3F,
                Width = 150F,
                Height = 200F
            },
            new Wigwam()
            {
                Name = "Вигвам 5, удобный просто",
                Description = "Очень удобный вигвам с своими особенностями для детей",
                Path = "./img/wigwams/5.jpg",
                Price = 370m,
                Weight = 1.0F,
                Width = 140F,
                Height = 222F,
            },
            new Wigwam()
            {
                Name = "Вигвам 6, классический",
                Description = "Очень удобный и просто классический вигвам с своими особенностями для детей",
                Path = "./img/wigwams/7.jpg",
                Price = 320m,
                Weight = 1.4F,
                Width = 154F,
                Height = 212F,
            },
            new Wigwam()
            {
                Name = "Вигвам 7, крутой просто",
                Description = "Очень удобный и крутой вигвам для детей с характером",
                Path = "./img/wigwams/7.jpg",
                Price = 400m,
                Weight = 1.5F,
                Width = 170F,
                Height = 220F,
            },
            new Wigwam()
            {
                Name = "Вигвам 8, последний вариант",
                Description = "Очень удобный, да и просто последний вариант с своими особенностями",
                Path = "./img/wigwams/8.jpg",
                Price = 250m,
                Weight = 0.8F,
                Width = 120F,
                Height = 170F,
            }
        };

        public async Task InitializeDBAsync()
        {
            if (!await _context.catalog.AnyAsync())
            {
                await _context.AddRangeAsync(GetWigwams());
                await _context.SaveChangesAsync();
            }
        }
    }
}
