using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTestsInline
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {

            }
        }

        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]
        public void IndexActionModelIsComplete(decimal price1, decimal price2,
                decimal price3, decimal price4)
        {
            var controller = new HomeController();
            controller.repository = new ModelCompleteFakeRepository
            {
                Products = new Product[]
                {
                    new Product {Name = "P1", Price = price1},
                    new Product {Name = "P2", Price = price2},
                    new Product {Name = "P3", Price = price3},
                    new Product {Name = "P4", Price = price4}
                }
            };

            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            Assert.Equal(controller.repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name &&
                    p1.Price == p2.Price));
        }
    }
}
