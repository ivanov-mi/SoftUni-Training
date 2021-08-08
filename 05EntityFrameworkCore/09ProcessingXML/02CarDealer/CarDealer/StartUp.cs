namespace CarDealer
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.Dtos.Import;
    using CarDealer.Dtos.Export;
    using System.Xml;

    public class StartUp
    {
        private static readonly string InputDirectoryPath = @"../../../Datasets";
        private static readonly string ResultDirectoryPath = @"../../../Datasets/Results";

        public static void Main()
        {
            using var context = new CarDealerContext();

            ResetDatabase(context);

            //Query 9. Import Suppliers
            var importSuppliersXml = File.ReadAllText(InputDirectoryPath + "/suppliers.xml");
            var importSuppliersResult = ImportSuppliers(context, importSuppliersXml);
            Console.WriteLine(importSuppliersResult);

            //Query 10. Import Parts
            var importPartsXml = File.ReadAllText(InputDirectoryPath + "/parts.xml");
            var importPartsResult = ImportParts(context, importPartsXml);
            Console.WriteLine(importPartsResult);

            //Query 11. Import Cars
            var importCarsXml = File.ReadAllText(InputDirectoryPath + "/cars.xml");
            var importCarsResult = ImportCars(context, importCarsXml);
            Console.WriteLine(importCarsResult);

            //Query 12. Import Customers
            var importCustomersXml = File.ReadAllText(InputDirectoryPath + "/customers.xml");
            var importCustomersResult = ImportCustomers(context, importCustomersXml);
            Console.WriteLine(importCustomersResult);

            //Query 13.Import Sales
            var importSalesXml = File.ReadAllText(InputDirectoryPath + "/sales.xml");
            var importSalesResult = ImportSales(context, importSalesXml);
            Console.WriteLine(importSalesResult);
    
            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }

            //Query 14. Cars With Distance
            var carsWithDistance = GetCarsWithDistance(context);
            File.WriteAllText(ResultDirectoryPath + "/cars.xml", carsWithDistance);

            //Query 15. Cars from make BMW
            var carsFromMakeBmw = GetCarsFromMakeBmw(context);
            File.WriteAllText(ResultDirectoryPath + "/bmw-cars.xml", carsFromMakeBmw);

            //Query 16. Local Suppliers
            var localSuppliers = GetLocalSuppliers(context);
            File.WriteAllText(ResultDirectoryPath + "/local-suppliers.xml", localSuppliers);

            //Query 17. Cars with Their List of Parts
            var carsWithTheirListOfParts = GetCarsWithTheirListOfParts(context);
            File.WriteAllText(ResultDirectoryPath + "/cars-and-parts.xml", carsWithTheirListOfParts);

            //Query 18. Total Sales by Customer
            var totalSalesByCustomer = GetTotalSalesByCustomer(context);
            File.WriteAllText(ResultDirectoryPath + "/customers-total-sales.xml", totalSalesByCustomer);

            //Query 19. Sales with Applied Discount
            var salesWithAppliedDiscount = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(ResultDirectoryPath + "/sales-discounts.xml", salesWithAppliedDiscount);
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var rootAttributeName = "Suppliers";

            var serializer = new XmlSerializer(typeof(ImportSupplierDTO[]), 
                new XmlRootAttribute(rootAttributeName));
            var supplierDTOs = (ImportSupplierDTO[])serializer.Deserialize(reader);

            var suppliers = supplierDTOs
                .Select(sd => new Supplier
                {
                    Name = sd.Name,
                    IsImporter = sd.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var rootAttributeName = "Parts";

            var serializer = new XmlSerializer(typeof(ImportPartDTO[]),
                new XmlRootAttribute(rootAttributeName));

            var importPartDTOs = (ImportPartDTO[])serializer.Deserialize(reader);

            var parts = importPartDTOs
                .Where(ipd => context.Suppliers.Any(s => s.Id == ipd.SupplierId))
                .Select(ipd => new Part 
                {
                    Name = ipd.Name,
                    Price = ipd.Price,
                    Quantity = ipd.Quantity,
                    SupplierId = ipd.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var rootAttributeName = "Cars";

            var serializer = new XmlSerializer(typeof(ImportCarDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var importCarDTOs = (ImportCarDTO[])serializer.Deserialize(reader);

            foreach (var carDTO in importCarDTOs)
            {
                var existingPartIds = carDTO.Parts
                    .Select(ep => ep.Id)
                    .Where(id => context.Parts.Any(p => p.Id == id))
                    .Distinct()
                    .ToArray();

                var car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance,
                    PartCars = existingPartIds.Select(id => new PartCar 
                    {
                        PartId = id
                    })
                    .ToArray()
                };

                context.Cars.Add(car);
            }

            context.SaveChanges();

            return $"Successfully imported {importCarDTOs.Length}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var rootAttributeName = "Customers";

            var serializer = new XmlSerializer(typeof(ImportCustomerDTO[]),
                new XmlRootAttribute(rootAttributeName));

            var importCutomerDTOs = (ImportCustomerDTO[])serializer.Deserialize(reader);

            var customers = importCutomerDTOs
                .Select(icd => new Customer
                {
                    Name = icd.Name,
                    BirthDate = icd.BirthDate,
                    IsYoungDriver = icd.IsYoungDriver

                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //Query 13.Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var rootAttributeName = "Sales";

            var serializer = new XmlSerializer(typeof(ImportSaleDTO[]),
                new XmlRootAttribute(rootAttributeName));

            var importSaleDTOs = (ImportSaleDTO[])serializer.Deserialize(reader);

            var sales = importSaleDTOs
                .Where(isd => context.Cars.Any(c => c.Id == isd.CarId))
                .Select(isd => new Sale
                {
                    CarId = isd.CarId,
                    CustomerId = isd.CustomerId,
                    Discount = isd.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        //Query 14. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new ExportCarDistanceDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            using var writer = new StringWriter();

            var rootAttributeName = "cars";

            var serializer = new XmlSerializer(typeof(ExportCarDistanceDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, cars, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 15. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportCarMakeDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            using var writer = new StringWriter();

            var rootAttributeName = "cars";

            var serializer = new XmlSerializer(typeof(ExportCarMakeDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, cars, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 16. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            using var writer = new StringWriter();

            var rootAttributeName = "suppliers";

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportLocalSupplierDTO[]),
                new XmlRootAttribute(rootAttributeName));

            serializer.Serialize(writer, localSuppliers, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 17. Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Select(c => new ExportCarWithPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new ExportPartDTO 
                    { 
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            using var writer = new StringWriter();

            var rootAttributeName = "cars";

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportCarWithPartsDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            serializer.Serialize(writer, carsAndParts, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 18. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var salesByCustomer = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportSalesByCustomerDTO
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .SelectMany(pc => pc.Car.PartCars)
                        .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            using var writer = new StringWriter();

            var rootAttributeName = "customers";

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportSalesByCustomerDTO[]),
                new XmlRootAttribute(rootAttributeName));

            serializer.Serialize(writer, salesByCustomer, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
        }

        //Query 19. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Select(s => new ExportSaleWithDiscountDTO
                {
                    CarInfo = new ExportCarDTO
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    Name = s.Customer.Name,
                    Price = s.Car.PartCars
                        .Sum(x => x.Part.Price),
                    PriceWithDiscount = s.Car.PartCars
                        .Sum(x => x.Part.Price) * (1 - s.Discount / 100)
                })
                .ToArray();

            using var writer = new StringWriter();

            var rootAttributeName = "sales";

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportSaleWithDiscountDTO[]),
                new XmlRootAttribute(rootAttributeName));

            serializer.Serialize(writer, salesWithDiscount, ns);

            var result = writer.GetStringBuilder();

            return result.ToString().TrimEnd();
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