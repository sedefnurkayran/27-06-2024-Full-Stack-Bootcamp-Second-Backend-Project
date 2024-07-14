using System.ComponentModel.DataAnnotations;
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
        public static List<Category> Categories
        {
            get
            {
                {
                    return _category;
                }

            }

        }

        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }

        //Profil-Detay sayfasini acma
        public static Product? GetById(int? id)
        {
            return _products.FirstOrDefault(x => x.ProductId == id);
        }
        public static void EditProduct(Product updatedProduct)

        {
            var entity = _products.FirstOrDefault(x => x.ProductId == updatedProduct.ProductId);

            if (entity != null)
            {
                entity.Name = updatedProduct.Name;
                entity.Clock = updatedProduct.Clock;
                entity.Description = updatedProduct.Description;
                entity.Image = updatedProduct.Image;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }

        }


        public static void DeleteProduct(Product deletedProduct)
        {
            var entities = _products.FirstOrDefault(x => x.ProductId == deletedProduct.ProductId);

            if (entities != null)
            {
                _products.Remove(entities);
            }
        }
    }
}