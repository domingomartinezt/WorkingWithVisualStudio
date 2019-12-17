﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio.Test
{
    public class HomeControllerTests
    {

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrenge
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryPropertyCalled()
        {
            // Arrenge
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] { new Product { Name = "p1", Price = 100 } });
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var result = controller.Index();

            // Assert
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}