using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Test
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Arrenge
            var p = new Product { Name = "Test", Price = 100M };

            // Act
            p.Name = "New Name";

            // Assert
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void canChangeProductPrice()
        {
            // Arrenge
            var p = new Product { Name = "Test", Price = 100M };

            // Act
            p.Price = 200M;

            // Assert
            Assert.Equal(200M, p.Price);
        }

    }
}
