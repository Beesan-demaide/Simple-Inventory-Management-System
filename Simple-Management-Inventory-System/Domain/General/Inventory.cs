using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Management_Inventory_System.Domain.General
{
    public class Inventory
    {
        private static List<Product> products = new();

        internal static void ShowMainMenu()
        {
            string? userSelection;
            do
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Welcome to Our Simple Inventory Management System");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("What you want to do, select your choice:");
                Console.WriteLine("1- Add a product");
                Console.WriteLine("2- View all products");
                Console.WriteLine("3- Edit a product");
                Console.WriteLine("4- Delete a product");
                Console.WriteLine("5- Search for a product");
                Console.WriteLine("6- Exit");
                Console.WriteLine();
                Console.WriteLine("Your Selection:  ");
                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        AddNewProduct();
                        break;

                    case "2":
                        ViewAllProducts();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                   case "5":
                        SearchProduct();
                        break;
                  
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Invalid selection,please try again");
                        break;
                }
            }
            while (userSelection != "6");
        }

        private static void SearchProduct()
        {
            Console.WriteLine("Write product Name: ");
            string ProductName = Console.ReadLine();
            bool found=false;
            if (products.Count == 0)
            {
                Console.WriteLine("The Inventory not have any Products");
                return;
            }
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.Equals(ProductName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Name: {products[i].Name}");
                    Console.WriteLine($"Price: {products[i].Price}");
                    Console.WriteLine($"Quantity: {products[i].Quantity}");
                    found=true;
                    break;
                }
            }
            if(!found)
            {
                Console.WriteLine("Product Not Found");
            }

        }


        private static void DeleteProduct()
        {
            Console.WriteLine("Write product Name to delete: ");
            string ProductName = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.Equals(ProductName, StringComparison.OrdinalIgnoreCase))
                {
                    products.RemoveAt(i);
                    Console.WriteLine("Product Deleted Successfully!");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Sorry Product Not found");
            }

}

        private static void EditProduct()
        {
            Console.WriteLine("Please Enter a name of product to edit it: ");
            string ProductNameToEdit=Console.ReadLine();
            bool found = false;
            foreach (Product product in products)
            {
                if (product.Name.Equals(ProductNameToEdit, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Please Edit Product Name: ");
                    string NewProductName = Console.ReadLine();
                    product.Name = NewProductName;

                    Console.WriteLine("Please Edit Price product: ");
                    string NewProductPrice = Console.ReadLine();
                    product.Price = int.Parse(NewProductPrice);

                    Console.WriteLine("Please Edit Quntity product: ");
                    string NewProductQuntity = Console.ReadLine();
                    product.Quantity = int.Parse(NewProductQuntity);

                    Console.WriteLine("Product updated successfully!");
                    found = true;
                    break;

                }
            }
                if(!found)
                {
                    Console.WriteLine("Sorry Product not found.");

                }
            }
               

        private static void ViewAllProducts()
        {
            if(products.Count == 0)
            {
                Console.WriteLine("The Inventory not have any Products");
                return;
            }

            for (int i = 0; i < products.Count; i++)
            {
                Product myproduct = products[i];
                Console.WriteLine($"Product # {i + 1}");
                Console.WriteLine($"Name: {myproduct.Name}");
                Console.WriteLine($"Price: {myproduct.Price}");
                Console.WriteLine($"Quantity: {myproduct.Quantity}");
                Console.WriteLine("-----------------");

            }
            
        }

        private static void AddNewProduct()
            {
            Console.WriteLine("Please Enter Product Name: ");
           string ProductName= Console.ReadLine();

            Console.WriteLine("Please Enter Product Price : ");
            int ProductPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter Product Quantity : ");
            int ProductQuantity =int.Parse(Console.ReadLine());  

            Product NewProduct = new Product(ProductName, ProductPrice , ProductQuantity);
            products.Add(NewProduct);
            Console.WriteLine("Product added successfully!");


        }

    }
       
    }
