using System;
using Diagrammer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class DataTableTests {
        // I know, it's so stupid to check corectness of methods 
        // by comparing ToString result of an object
        // It's my first unit test, forgive me please

        [TestMethod]
        public void FromRecctangularArray() {
            double[,] dArr = new double[3, 4] {
                {1.0, 2.0, 3.0, 4.0},
                {5.0, 6.0, 7.0, 8.0},
                {9.0, 10.0, 11.0, 12.0},
            };

            DataTable dt = new DataTable(3, 4, dArr);
            String strVal = dt.ToString();

            Assert.AreEqual(strVal, "Rows: 3, Cols: 4\r\n1\t2\t3\t4\t\r\n5\t6\t7\t8\t\r\n9\t10\t11\t12\t\r\n");
        }

        [TestMethod]
        public void FromJaggedArray() {
            double[][] jArr = new double[3][] {
                new double[] {1.0, 2.0, 3.0, 4.0},
                new double[] {5.0, 6.0, 7.0, 8.0},
                new double[] {9.0, 10.0, 11.0, 12.0},
            };

            double[,] dArr = new double[3, 4] {
                {1.0, 2.0, 3.0, 4.0},
                {5.0, 6.0, 7.0, 8.0},
                {9.0, 10.0, 11.0, 12.0},
            };

            DataTable dtJagged = new DataTable(jArr);
            DataTable dtRect = new DataTable(3, 4, dArr);

            Assert.AreEqual(dtRect, dtJagged);
        }

        [TestMethod]
        public void Slices() {
            double[][] jArr = new double[3][] {
                new double[] {1.0, 2.0, 3.0, 4.0},
                new double[] {5.0, 6.0, 7.0, 8.0},
                new double[] {9.0, 10.0, 11.0, 12.0},
            };

            DataTable dtJagged = new DataTable(jArr);

            var slice = dtJagged[false, 0, 2];

            DataTable slicedDT = new DataTable(slice);
            String sliceToStr = slicedDT.ToString();

            Assert.Equals(sliceToStr, "Rows: 2, Cols: 3\r\n1\t5\t9\t\r\n3\t7\t11\t\r\n");
        }
    }
}
