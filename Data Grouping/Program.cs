using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Products
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }

    public Products(string name, string category, int price)
    {
        Name = name;
        Category = category;
        Price = price;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\Omen\Documents\products.txt";
        List<Products> products = ReadProductsFromFile(filePath);

        var groupedByCategory = products.GroupBy(e => e.Category);

        foreach (var group in groupedByCategory)
        {
            Console.WriteLine("Категорiя: " + group.Key);

            foreach (var product in group)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine();
        }

        var groupedByPrice = products.GroupBy(e => e.Price);

        foreach (var group in groupedByPrice)
        {
            Console.WriteLine("Цiна: " + group.Key);

            foreach (var product in group)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine();
        }
    }

    static List<Products> ReadProductsFromFile(string filePath)
    {
        List<Products> products = new List<Products>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(' ');
                Products product = new Products(fields[0], fields[1], Convert.ToInt32(fields[2]));
                products.Add(product);
            }
        }

        return products;
    }
}


