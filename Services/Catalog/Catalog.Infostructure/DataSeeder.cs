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
                WigwamTitle = "Вигвам 1, классический вариант", 
                WigwamDescription = "Очень удобный вигвам с своими особенностями для детей",
                Path = "./img/wigwams/1.jpg",
                Price = 300m
            },
            new Wigwam()
            {
                WigwamTitle = "Вигвам 2, отличный вариант",
                WigwamDescription = "Очень удобный и отличный вигвам для детей",
                Path = "./img/wigwams/2.jpg",
                Price = 350m
            },
            new Wigwam()
            {
                WigwamTitle = "Вигвам 3, модерн классика",
                WigwamDescription = "Очень удобный и современный вигвам для детей",
                Path = "./img/wigwams/3.jpg",
                Price = 310m
            },
            new Wigwam()
            {
                WigwamTitle = "Вигвам 4, красивый просто",
                WigwamDescription = "Очень удобный и красивый вигвам с своими особенностями",
                Path = "./img/wigwams/4.jpg",
                Price = 330m
            },
            new Wigwam()
            {
                WigwamTitle = "Вигвам 5, удобный просто",
                WigwamDescription = "Очень удобный вигвам с своими особенностями для детей",
                Path = "./img/wigwams/5.jpg",
                Price = 370m
            },
            new Wigwam()
            {
                WigwamTitle = "Вигвам 6, классический",
                WigwamDescription = "Очень удобный и просто классический вигвам с своими особенностями для детей",
                Path = "./img/wigwams/7.jpg",
                Price = 320m
            },
            new Wigwam()
            {
                WigwamTitle = "Вигвам 7, крутой просто",
                WigwamDescription = "Очень удобный и крутой вигвам для детей с характером",
                Path = "./img/wigwams/7.jpg",
                Price = 400m
            },
            new Wigwam()
            {
                WigwamTitle = "Вигвам 8, последний вариант",
                WigwamDescription = "Очень удобный, да и просто последний вариант с своими особенностями",
                Path = "./img/wigwams/8.jpg",
                Price = 250m
            },
        };

        public async Task InitializeDBAsync()
        {
            if (!await _context.Wigwams.AnyAsync())
            {
                await _context.AddRangeAsync(GetWigwams());
                await _context.SaveChangesAsync();
            }
        }
    }
}
