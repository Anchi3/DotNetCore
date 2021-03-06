using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DbModel.northwindContext();

            var customersList = context.Customers.ToList();
            var productsList = context.Products.ToList();

            //ToXml(customersList, "customers.xml");
            //ToBinary(customersList, "customers.dat");
            //ToJson(customersList, "customers.json");

            //ToXml(productsList, "products.xml");
            //ToBinary(productsList, "products.dat");
            //ToJson(productsList, "products.json");

            //FileInfo
            List<SerializedFile> fileListCustomers = new List<SerializedFile>
            {
                new SerializedFile
                {
                    Name = "customers.json",
                    Size = new FileInfo("customers.json").Length
                },

                new SerializedFile
                {
                    Name = "customers.xml",
                    Size = new FileInfo("customers.xml").Length
                },

                new SerializedFile
                {   Name = "customers.dat",
                    Size = new FileInfo("customers.dat").Length
                }

            };

            List<SerializedFile> fileListProducts = new List<SerializedFile>
            {
                new SerializedFile
                {
                    Name = "products.json",
                    Size = new FileInfo("products.json").Length
                },

                new SerializedFile
                {
                    Name = "products.xml",
                    Size = new FileInfo("products.xml").Length
                },

                new SerializedFile
                {   Name = "products.dat",
                    Size = new FileInfo("products.dat").Length
                }

            };

            fileListCustomers.Sort();
            fileListProducts.Sort();

            Console.WriteLine("==================================================");

            foreach (var item in fileListCustomers)
            {
                Console.WriteLine($"{item.Name} has {item.Size} bytes.");
            }

            Console.WriteLine("==================================================");

            foreach (var item in fileListProducts)
            {
                Console.WriteLine($"{item.Name} has {item.Size} bytes.");
            }

            Console.WriteLine("==================================================");
            Console.WriteLine("==================================================");

            // list cities
            var cities = customersList.Select(c => c.City).Distinct().ToList();                            
            
            List<string> citiesList = cities.ToList();
            cities.Sort();

            string joined = string.Join(", ", cities.ToArray());

            Console.WriteLine("Here is the city list: \n\n" + joined +
                                "\n\nPlease enter a city: ");

            var cityEntry = Console.ReadLine();

            var customerCityList = customersList.Where(c => c.City.Equals(cityEntry));

            if(customerCityList.Count() != 1)
                Console.WriteLine($"\nThere are {customerCityList.Count()} customers in {cityEntry}: \n");
            else
                Console.WriteLine($"There is {customerCityList.Count()} customer in {cityEntry}: \n");

            foreach (var item in customerCityList)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }


            Console.WriteLine("\nThank you and have a great day!");
            Console.WriteLine("==================================================");

        }
        public class SerializedFile : IComparable<SerializedFile>
        {
            public string Name { get; set; }
            public long Size { get; set; }

            public int CompareTo([AllowNull] SerializedFile other)
            {
                return Size.CompareTo(other.Size);
            }
        }

        public static void ToXml<T>(T obj, string path)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sw, obj);
                File.WriteAllText(path, sw.ToString());
            }
        }

        public static void ToBinary<T>(T obj, string path)
        {
            using (Stream st = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, obj);
            }
        }

        public static void ToJson<T>(T obj, string path)
        {
            String json = JsonSerializer.Serialize(obj);
            File.WriteAllText(path, json);
        }
    }
}


// on tools => package manager console
// Scaffold-DbContext "server=localhost;user=root;password=Anchie0904!;database=northwind" Pomelo.EntityFrameworkcore.MySql -outputdir DbModel