using Disabled.Migrations;
using Disabled.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Disabled.DAL
{
    public class ShopInitializer : MigrateDatabaseToLatestVersion<ShopContext, Configuration>
    {
        //protected override void Seed(ShopContext context)
        //{
        //    SeedShopData(context);
        //    base.Seed(context);
        //}

        public static void SeedShopData(ShopContext context)
        {
            // throw new NotImplementedException();
            var categories = new List<Category>
             {
                 new Category() { CategoryId = 1, CategoryName = "Produkty dla niewidomych", CategoryImageFileName = "1.jpeg" },
                 new Category() { CategoryId = 2, CategoryName = "Produkty dla słabowidzących", CategoryImageFileName = "2.jpeg" },
                 new Category() { CategoryId = 3, CategoryName = "Produkty dla niedosłyszących", CategoryImageFileName = "3.jpeg" },
                 new Category() { CategoryId = 4, CategoryName = "Produkty dla niepełnosprawnych ruchowo", CategoryImageFileName = "4.jpeg" },
                 new Category() { CategoryId = 5, CategoryName = "Tyflografika", CategoryImageFileName = "5.jpeg" },
                 new Category() { CategoryId = 6, CategoryName = "Inne", CategoryImageFileName = "6.jpeg" }

             };

            var products = new List<Product>
            {
                new Product() { ProductId = 1, CategoryId = 1, ProductName = "Monitor Braille'owski", ProductImageFileName = "1-1.jpeg", Description = "opis", Price = 12000.50M, IsHidden = false},
                new Product() { ProductId = 2, CategoryId = 1, ProductName = "Program udźwiękawiający", ProductImageFileName = "1-2.jpeg", Description = "opis", Price = 4000M, IsHidden = false},
                new Product() { ProductId = 3, CategoryId = 1, ProductName = "Biała laska", ProductImageFileName = "1-3.jpeg", Description = "opis", Price = 120M, IsHidden = false},
                new Product() { ProductId = 4, CategoryId = 1, ProductName = "Drukarka Braille'owska", ProductImageFileName = "1-4.jpeg", Description = "opis", Price = 15600M, IsHidden = false},
                new Product() { ProductId = 5, CategoryId = 1, ProductName = "Urządzenie lektorskie", ProductImageFileName = "1-5.jpeg", Description = "opis", Price = 8900M, IsHidden = false},
                new Product() { ProductId = 6, CategoryId = 1, ProductName = "Mówiący zegarek", ProductImageFileName = "1-6.jpeg", Description = "opis", Price = 140M, IsHidden = false},

                new Product() { ProductId = 7, CategoryId = 2, ProductName = "Lupa elektroniczna", ProductImageFileName = "2-1.jpeg", Description = "opis", Price = 2500M, IsHidden = false},
                new Product() { ProductId = 8, CategoryId = 2, ProductName = "Program powiększający", ProductImageFileName = "2-2.jpeg", Description = "opis", Price = 2450M, IsHidden = false},
                new Product() { ProductId = 9, CategoryId = 2, ProductName = "Powiększalnik stacjonarny", ProductImageFileName = "2-3.jpeg", Description = "opis", Price = 13750M, IsHidden = false},
                new Product() { ProductId = 10, CategoryId = 2, ProductName = "Lupa optyczna", ProductImageFileName = "2-4.jpeg", Description = "opis", Price = 140M, IsHidden = false},
                new Product() { ProductId = 11, CategoryId =2, ProductName = "Klawiatura powiększona", ProductImageFileName = "2-5.png", Description = "opis", Price = 320M, IsHidden = false},
                new Product() { ProductId = 12, CategoryId =2, ProductName = "Powiększalnik przenośny", ProductImageFileName = "2-6.jpeg", Description = "opis", Price = 7400M, IsHidden = false},

                new Product() { ProductId = 13, CategoryId = 3, ProductName = "Pętla indukcyjna pojedyczna", ProductImageFileName = "3-1.png", Description = "opis", Price = 600M, IsHidden = false},
                new Product() { ProductId = 14, CategoryId = 3, ProductName = "Pętla indukcyjna przenośna", ProductImageFileName = "3-2.jpeg", Description = "opis", Price = 745M, IsHidden = false},
                new Product() { ProductId = 15, CategoryId = 3, ProductName = "Pętla indukcyjna przenośnona - zestaw", ProductImageFileName = "3-3.jpeg", Description = "opis", Price = 2600M, IsHidden = false},

                new Product() { ProductId = 16, CategoryId = 4, ProductName = "Klawiatura specjalistyczna z nakładką", ProductImageFileName = "4-1.jpeg", Description = "opis", Price = 320.50M, IsHidden = false},
                new Product() { ProductId = 17, CategoryId = 4, ProductName = "Klawiatura jednoręczna, prawa ręka", ProductImageFileName = "4-2.jpeg", Description = "opis", Price = 3700.20M, IsHidden = false},
                new Product() { ProductId = 18, CategoryId = 4, ProductName = "Specjalistyczna mysz obsługiwana ustami", ProductImageFileName = "4-3.jpeg", Description = "opis", Price = 9280M, IsHidden = false},
                new Product() { ProductId = 19, CategoryId = 4, ProductName = "Powiększona mysz komputerowa, trackball", ProductImageFileName = "4-4.jpeg", Description = "opis", Price = 320.70M, IsHidden = false},
                new Product() { ProductId = 20, CategoryId = 4, ProductName = "Wózek inwalidzki", ProductImageFileName = "4-5.jpeg", Description = "opis", Price = 13560M, IsHidden = false},
                new Product() { ProductId = 21, CategoryId = 4, ProductName = "Interfejs do przycisków funkcyjnych", ProductImageFileName = "4-6.png", Description = "opis", Price = 1400.99M, IsHidden = false},

                new Product() { ProductId = 22, CategoryId = 5, ProductName = "Termoforma", ProductImageFileName = "5-1.jpeg", Description = "opis", Price = 210M, IsHidden = false},
                new Product() { ProductId = 23, CategoryId = 5, ProductName = "Tabliczka Braille'owska", ProductImageFileName = "5-2.jpeg", Description = "opis", Price = 87M, IsHidden = false},
                new Product() { ProductId = 24, CategoryId = 5, ProductName = "Pole uwagi", ProductImageFileName = "5-3.jpeg", Description = "opis", Price = 145.44M, IsHidden = false},
                new Product() { ProductId = 25, CategoryId = 5, ProductName = "Mapa tyflograficzna", ProductImageFileName = "5-4.jpeg", Description = "opis", Price = 1400M, IsHidden = false},
                new Product() { ProductId = 26, CategoryId = 5, ProductName = "Terminal informacyjny", ProductImageFileName = "5-5.jpeg", Description = "opis", Price = 15700M, IsHidden = false},

                new Product() { ProductId = 27, CategoryId = 6, ProductName = "Kości do gry Braille'owskie", ProductImageFileName = "6-1.jpeg", Description = "opis", Price = 24M, IsHidden = false},
                new Product() { ProductId = 28, CategoryId = 6, ProductName = "Kostka Rubika", ProductImageFileName = "6-2.jpeg", Description = "opis", Price = 89M, IsHidden = false},
                new Product() { ProductId = 29, CategoryId = 6, ProductName = "Podkładka pod kubek drewniana", ProductImageFileName = "6-3.jpeg", Description = "opis", Price = 4M, IsHidden = false},
                new Product() { ProductId = 30, CategoryId = 6, ProductName = "Układanka drewniana", ProductImageFileName = "6-4.jpeg", Description = "opis", Price = 79M, IsHidden = false},
                new Product() { ProductId = 31, CategoryId = 6, ProductName = "Karty do gry z powiększonym drukiem", ProductImageFileName = "6-5.jpeg", Description = "opis", Price = 47M, IsHidden = false}
            };

            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            products.ForEach(c => context.Products.AddOrUpdate(c));

            context.SaveChanges();
        }

        public static void InitializeIdentityForEF(ShopContext db)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@disabled.pl";
            const string password = "P@ssw0rd";
            const string roleName = "Admin";


            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UserData = new UserData() };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}