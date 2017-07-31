using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtestMatrixData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtestMatrixData.Tests
{
    [TestClass()]
    public class AmatrixTests
    {
        [TestMethod()]
        public void ReadMatrixTest()
        {
            Amatrix amatrix = new Amatrix();
            string[] textLines = new string[] { "1;2;3", "4;5;6", "7;8;9" };
            amatrix.ReadMatrix(textLines);
            Assert.IsNotNull(amatrix.Matrix);
        }

        [TestMethod()]
        public void GenerateMatrixTest()
        {
            Amatrix amatrix = new Amatrix();
            amatrix.GenerateMatrix(5);
            Assert.IsNotNull(amatrix.Matrix);
        }

        [TestMethod()]
        public void RotateMatrixTest()
        {
            Amatrix amatrix = new Amatrix();
            amatrix.GenerateMatrix(5);
            amatrix.RotateMatrix();
            Assert.IsNotNull(amatrix.Matrix);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Amatrix amatrix = new Amatrix();
            amatrix.Dispose();
            amatrix = null;
            Assert.IsNull(amatrix);
        }
    }
}