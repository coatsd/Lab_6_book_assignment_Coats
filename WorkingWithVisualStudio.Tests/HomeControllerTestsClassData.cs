using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTestsClassData
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {

            }
        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            var controller = new HomeController();
            controller.repository = new ModelCompleteFakeRepository
            {
                Products = products
            };

            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            Assert.Equal(controller.repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name &&
                    p1.Price == p2.Price));
        }
    }
}
