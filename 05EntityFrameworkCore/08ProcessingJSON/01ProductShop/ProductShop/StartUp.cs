namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using ProductShop.Data;
    using ProductShop.Models;

    public class StartUp
    {
        private static readonly string InputDirectoryPath = @"../../../Datasets";
        private static readonly string ResultDirectoryPath = @"../../../Datasets/Results";

        public static void Main()
        {
            using var context = new ProductShopContext();

            ResetDatabase(context);

            //Query 1. Import Users
            var importUsers = File.ReadAllText(InputDirectoryPath + "/users.json");
            var importUsersResult = ImportUsers(context, importUsers);
            Console.WriteLine(importUsersResult);

            //Query 2. Import Products
            var importProducts = File.ReadAllText(InputDirectoryPath + "/products.json");
            var importProductsResult = ImportProducts(context, importProducts);
            Console.WriteLine(importProductsResult);

            //Query 3. Import Categories
            var importCategories = File.ReadAllText(InputDirectoryPath + "/categories.json");
            var importCategoriesResult = ImportCategories(context, importCategories);
            Console.WriteLine(importCategoriesResult);

            //Query 4. Import Categories and Products
            var importCategoryProducts = File.ReadAllText(InputDirectoryPath + "/categories-products.json");
            var importCategoryResult = ImportCategoryProducts(context, importCategoryProducts);
            Console.WriteLine(importCategoryResult);

            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }

            //Query 5. Export Successfully Sold Products
            var productsInRangeJson = GetProductsInRange(context);
            File.WriteAllText(ResultDirectoryPath + "/products-in-range.json", productsInRangeJson);

            //Query 6. Export Users and Products
            var soldProductsJson = GetSoldProducts(context);
            File.WriteAllText(ResultDirectoryPath + "/users-sold-products.json", soldProductsJson);

            //Query 7. Export Categories by Products Count
            var categoriesByProductsCountJson = GetCategoriesByProductsCount(context);
            File.WriteAllText(ResultDirectoryPath + "/categories-by-products.json", categoriesByProductsCountJson);

            //Query 8. Export Users and Products
            var usersWithProductsJson = GetUsersWithProducts(context);
            File.WriteAllText(ResultDirectoryPath + "/users-and-products.json", usersWithProductsJson);
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert
                .DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert
                .DeserializeObject<List<Product>>(inputJson);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert
                .DeserializeObject<List<CategoryProduct>>(inputJson)
                .ToList();

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Query 5. Export Successfully Sold Products
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => (p.Price >= 500 && p.Price <= 1000))
                .OrderBy(p => p.Price)
                .Select(p => new 
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .ToList();

            string productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsJson;
        }

        //Query 6. Export Users and Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new 
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Select( ps => new 
                        {
                            name = ps.Name,
                            price = ps.Price,
                            buyerFirstName = ps.Buyer.FirstName,
                            buyerLastName = ps.Buyer.LastName
                        })
                        .ToList()
                })
                .ToList();

            var usersWithSoldProductsJson = JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented);

            return usersWithSoldProductsJson;
        }

        //Query 7. Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts
                        .Average(cp => cp.Product.Price)
                        .ToString("F2"),
                    totalRevenue = c.CategoryProducts
                        .Sum(cp => cp.Product.Price)
                        .ToString("F2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return categoriesJson;
        }

        //Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(ps => ps.Buyer != null),
                        products = u.ProductsSold
                            .Where( p => p.Buyer != null)
                            .Select(s => new
                            {
                                name = s.Name,
                                price = s.Price
                            })
                            .ToList()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();

            var usersResult = new
            {
                userCount = users.Count,
                users = users
            };

            var settings = new JsonSerializerSettings 
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var usersResultJson = JsonConvert.SerializeObject(usersResult, settings);

            return usersResultJson;
        }

        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted ();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
    }
}