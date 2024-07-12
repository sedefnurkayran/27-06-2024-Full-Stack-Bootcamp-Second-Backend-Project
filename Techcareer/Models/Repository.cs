using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

namespace Techcareer.Models
{

    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _category = new();

        static Repository() //Constructor
        {
            _category.Add(new Category { CategoryId = 1, Name = "Web" });
            _category.Add(new Category { CategoryId = 2, Name = "Game" });

            _products.Add(new Product { ProductId = 1, Name = "Asp.Net Bootcamp", Description = "Güzel Bootcamp", IsActive = true, Image = "1.png", CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "Full-Stack Bootcamp", Description = "Güzel Bootcamp", IsActive = true, Image = "3.png", CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, Name = "Unity Game Bootcamp", Description = "Güzel Bootcamp", IsActive = true, Image = "2.png", CategoryId = 2 });
        }

        public static List<Product> Products
        {
            get
            {
                {
                    return _products;


                }

            }

        }
        public static List<Category> Category
        {
            get
            {
                {
                    return _category;
                }

            }

        }



    }
}