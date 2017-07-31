using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtestMatrix;
using AtestMatrix.Controllers;
using System.Web;
using AtestMatrixData;

namespace AtestMatrix.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            IAmatrix m = new Amatrix();
            HomeController controller = new HomeController(m);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        public void UploadMatrix()
        {
            // Arrange
            IAmatrix m = new Amatrix();
            HomeController controller = new HomeController(m);

            // Act
            ViewResult result = controller.UploadMatrix(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GenerateMatrix()
        {
            // Arrange
            IAmatrix m = new Amatrix();
            HomeController controller = new HomeController(m);

            // Act
            ViewResult result = controller.GenerateMatrix(5) as ViewResult;
            var r = (result.Model as Tuple<int[][], int>).Item2;

            // Assert
            Assert.AreEqual(5, r);
        }

        [TestMethod]
        public void RotateMatrix()
        {
            // Arrange
            IAmatrix m = new Amatrix();
            HomeController controller = new HomeController(m);

            // Act
            controller.GenerateMatrix(5);
            ViewResult result = controller.RotateMatrix() as ViewResult;
            var r = (result.Model as Tuple<int[][], int>).Item2;

            // Assert
            Assert.AreEqual(5, r);
        }

        [TestMethod]
        public void DownloadCSV()
        {
            // Arrange
            IAmatrix m = new Amatrix();
            HomeController controller = new HomeController(m);

            // Act
            controller.GenerateMatrix(5);
            FileContentResult result = controller.DownloadCSV("test") as FileContentResult;

            // Assert
            Assert.IsNotNull(result.FileContents);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            IAmatrix m = new Amatrix();
            HomeController controller = new HomeController(m);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            IAmatrix m = new Amatrix();
            HomeController controller = new HomeController(m);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
