using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace InventoryManagement_Test
{
    [TestClass]
   public class ProductControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProductController controller = new ProductController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Edit()
        {
            ProductController controller = new ProductController();
            // Act
            ViewResult result = controller.Edit(3) as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Test_Delete()
        {
            ProductController controller = new ProductController();
            // Act
            ViewResult result = controller.Delete(3) as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Test_Create()
        {
            ProductController controller = new ProductController();
            // Act
            ViewResult result = controller.Create() as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
    }
}
