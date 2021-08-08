namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using ProductShop.Data;
    using ProductShop.Dtos;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
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
            var usersXml = File.ReadAllText(InputDirectoryPath + "/users.xml");
            var importUsersResult = ImportUsers(context, usersXml);
            Console.WriteLine(importUsersResult);

            //Query 2. Import Products
            var productsXml = File.ReadAllText(InputDirectoryPath + "/products.xml");
            var importProductsResult = ImportProducts(context, productsXml);
            Console.WriteLine(importProductsResult);

            //Query 3. Import Categories
            var categoriesXml = File.ReadAllText(InputDirectoryPath + "/categories.xml");
            var importCategoriesResult = ImportCategories(context, categoriesXml);
            Console.WriteLine(importCategoriesResult);

            //Query 4. Import Categories and Products
            var categoriesProductsXml = File.ReadAllText(InputDirectoryPath + "/categories-products.xml");
            var importCategoryProductsResult = ImportCategoryProducts(context, categoriesProductsXml);
            Console.WriteLine(importCategoryProductsResult);

            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }

            //Query 5. Products In Range
            var productsInRange = GetProductsInRange(context);
            File.WriteAllText(ResultDirectoryPath + "/products-in-range.xml", productsInRange);

            //Query 6. Sold Products
            var soldProducts = GetSoldProducts(context);
            File.WriteAllText(ResultDirectoryPath + "/users-sold-products.xml", soldProducts);

            //Query 7. Categories By Products Count
            var CategoriesByProductsCount = GetCategoriesByProductsCount(context);
            File.WriteAllText(ResultDirectoryPath + "/categories-by-products.xml", CategoriesByProductsCount);

            //Query 8. Users and Products
            var usersWithProducts = GetUsersWithProducts(context);
            File.WriteAllText(ResultDirectoryPath + "/users-and-products.xml", usersWithProducts);
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var rootAttributeName = "Users";

            var serializer = new XmlSerializer(typeof(ImportUserDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var userDTOs = (ImportUserDTO[])serializer.Deserialize(reader);

            var users = userDTOs
                .Select(ud => new User
                {
                    FirstName = ud.FirstName,
                    LastName = ud.LastName,
                    Age = ud.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var rootAttributeName = "Products";

            var serializer = new XmlSerializer(typeof(ImportProductDTO[]), 
                new XmlRootAttribute(rootAttributeName));
            var productDTOs = (ImportProductDTO[])serializer.Deserialize(reader);

            var products = productDTOs
                .Select(pd => new Product
                {
                    Name = pd.Name,
                    Price = pd.Price,
                    SellerId = pd.SellerId,
                    BuyerId = pd.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            string rootAttributeName = "Categories";

            var serializer = new XmlSerializer(typeof(ImportCategoryDTO[]),
                new XmlRootAttribute(rootAttributeName));

            var categoryDTOs = (ImportCategoryDTO[])serializer.Deserialize(reader);

            var categories = categoryDTOs
                .Where(cd => cd.Name != null)
                .Select(cd => new Category
                {
                    Name = cd.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var  rootAttributeName = "CategoryProducts";

            var serializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var categoryProductDTOs = (ImportCategoryProductDTO[])serializer.Deserialize(reader);

            var categoryProducts = categoryProductDTOs
                .Where(cpd => context.Products.Any(p => p.Id == cpd.ProductId) &&
                            context.Categories.Any(c => c.Id == cpd.CategoryId))
                .Select(cpd => new CategoryProduct
                {
                    CategoryId = cpd.CategoryId,
                    ProductId = cpd.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Query 5. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsByPriceRangeDTO
                {
                    ProductName = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            var rootAttributeName = "Products";

            var serializer = new XmlSerializer(typeof(ExportProductsByPriceRangeDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, productsInRange, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 6. Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps => new ExportProductDTO
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var rootAttributeName = "Users";

            var serializer = new XmlSerializer(typeof(ExportUserDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, users, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 7. Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoriesDTO
                {
                    Name = c.Name,
                    ProductCount = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(c => c.ProductCount)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var rootAttributeName = "Categories";

            using var writer = new StringWriter();

            var serializer = new XmlSerializer(typeof(ExportCategoriesDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, categories, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 8. Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var topSellingUsers = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count())
                .Select(u => new ExportUserWithCountDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDTO
                        {
                            Count = u.ProductsSold.Count(),
                            SoldProducts = u.ProductsSold
                                .Select(ps => new ExportProductDTO
                                {
                                    Name = ps.Name,
                                    Price = ps.Price
                                })
                                .OrderByDescending(ps => ps.Price)
                                .ToArray()
                        }
                })
                .Take(10)
                .ToArray();

            var usersAndProducts = new ExportUsersAndProductsDTO
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = topSellingUsers
            };

            var rootAttributeName = "Users";

            using var writer = new StringWriter();

            var serializer = new XmlSerializer(typeof(ExportUsersAndProductsDTO),
                new XmlRootAttribute(rootAttributeName));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, usersAndProducts, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
    }
}