using System;
using Xunit;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void TestProductChangeName()
        {
            Product product = new Product { Name = "Test", Price = 100M };

            product.Name = "New Name";

            Assert.Equal("New Name", product.Name);
        }

        [Fact]
        public void TestProductChangePrice()
        {
            Product product = new Product { Name = "Test", Price = 100M };

            product.Price = 200M;

            Assert.Equal(200M, product.Price);
        }
    }
}
