using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLinge.Data;
using System;
using System.Linq;

namespace MvcLinge.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcLingeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcLingeContext>>()))
            {
                // Look for any movies.
                if (context.Linge.Any())
                {
                    return;   // DB has been seeded
                }

                context.Linge.AddRange(
                    new Linge
                    {
                        Title = "Chandail",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Haut",
                        Price = 7.99M
                    },

                    new Linge
                    {
                        Title = "Polo ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Haut",
                        Price = 8.99M
                    },

                    new Linge
                    {
                        Title = "Jeans",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Bas",
                        Price = 9.99M
                    },

                    new Linge
                    {
                        Title = "Casquettes",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Tete",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}