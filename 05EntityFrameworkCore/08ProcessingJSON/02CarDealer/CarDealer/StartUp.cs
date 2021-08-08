namespace CarDealer
{
    using System;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.DTO.Import;
    using CarDealer.DTO.Export;
    using System.Globalization;

    public class StartUp
    {
        private static readonly string InputDirectoryPath = @"../../../Datasets";
        private static readonly string ResultDirectoryPath = @"../../../Datasets/Results/";

        public static void Main()
        {
            using var context = new CarDealerContext();
            
            ResetDatabase(context);
            
            //Query 9. Import Suppliers
            var inputSuppliers = File.ReadAllText(InputDirectoryPath + "/suppliers.json");
            var inputSuppliersResult = ImportSuppliers(context, inputSuppliers);
            Console.WriteLine(inputSuppliersResult);
            
            //Query 10. Import Parts
            var inputParts = File.ReadAllText(InputDirectoryPath + "/parts.json");
            var inputPartsResult = ImportParts(context, inputParts);
            Console.WriteLine(inputPartsResult);
            
            //Query 11. Import Cars
            var inputCars = File.ReadAllText(InputDirectoryPath + "/cars.json");
            var inputCarsResult = ImportCars(context, inputCars);
            Console.WriteLine(inputCarsResult);
            
            //Query 12. Import Customers
            var inputCustomers = File.ReadAllText(InputDirectoryPath + "/customers.json");
            var inputCustomersResult = ImportCustomers(context, inputCustomers);
            Console.WriteLine(inputCustomersResult);
            
            //Query 13. Import Sales
            var inputSales = File.ReadAllText(InputDirectoryPath + "/sales.json");
            var inputSalersResult = ImportSales(context, inputSales);
            Console.WriteLine(inputSalersResult);
                     
            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }
               
            //Query 14. Export Ordered Customers
            var orderedCustomersJson = GetOrderedCustomers(context);
            File.WriteAllText(ResultDirectoryPath + "ordered-customers.json", orderedCustomersJson);
            
            //Query 15. Export Cars from Make Toyota
            var carsFromMakeToyotaJson = GetCarsFromMakeToyota(context);
            File.WriteAllText(ResultDirectoryPath + "toyota-cars.json", carsFromMakeToyotaJson);
            
            //Query 16. Export Local Suppliers
            var localSuppliersJson = GetLocalSuppliers(context);
            File.WriteAllText(ResultDirectoryPath + "local-suppliers.json", localSuppliersJson);
            
            //Query 17. Export Cars with Their List of Parts
            var carsWithTheirListOfPartsJson = GetCarsWithTheirListOfParts(context);
            File.WriteAllText(ResultDirectoryPath + "cars-and-parts.json", carsWithTheirListOfPartsJson);
            
            //Query 18. Export Total Sales by Customer
            var totalSalesByCustomerJson = GetTotalSalesByCustomer(context);
            File.WriteAllText(ResultDirectoryPath + "customers-total-sales.json", totalSalesByCustomerJson);
            
            //Query 19. Export Sales with Applied Discount
            var salesWithAppliedDiscountJson = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(ResultDirectoryPath + "sales-discounts.json", salesWithAppliedDiscountJson);            
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson)
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDTOs = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);

            foreach (var carDTO in carDTOs)
            {
                var car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance,
                };

                context.Cars.Add(car);

                foreach (var partId in carDTO.PartsId)
                {               
                    if (!car.PartCars.Any(pc => pc.PartId == partId))
                    {
                        var partCar = new PartCar 
                        { 
                            CarId = car.Id, 
                            PartId = partId
                        };

                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carDTOs.Length}.";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson)
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson)
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        //Query 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new CustomerExportDTO
                {
                    Name = c.Name,
                    Birthdate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var customerJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customerJson;
        }

        //Query 15. Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarsMadeByToyotaDTO 
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .ToArray();

            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsJson;
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocaslSupplierDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var supplierJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return supplierJson;
        }

        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context
                .Cars
                .Select(c => new CarAndPartsDTO
                {
                    Car = new CarDTO
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    Parts = c.PartCars
                        .Select(pc => new PartsDTO
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("F2"),
                        })
                        .ToArray()                       
                })
                .ToArray();

            var carAndPartsJson = JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);

            return carAndPartsJson;
        }

        //Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerSales = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new CustomerSalesDTO
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .SelectMany(s => s.Car.PartCars)
                        .Sum(pc => pc.Part.Price)
                })
                .ToArray();

            var customerSalesJson = JsonConvert.SerializeObject(customerSales, Formatting.Indented);

            return customerSalesJson;
        }

        //Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new SaleWithDiscountDTO 
                {
                    CarInfo = new CarDTO 
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance,
                    },
                    Name = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    Price = s.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                    PriceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100)).ToString("F2")
                })
                .Take(10)
                .ToArray();

            var salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesJson;
        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
    }
}