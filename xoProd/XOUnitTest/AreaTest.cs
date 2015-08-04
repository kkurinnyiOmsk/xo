using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xoProd;

namespace XOUnitTest
{
    [TestClass]
    public class AreaTest
    {
        [TestMethod]
        public void UpdatePoleTest()
        {
            Area area = new Area();
            area.UpdatePole(1, 1, 1);

            int[,] expectedMatrix =
            {
                {1, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(area.pole[i,j], expectedMatrix[i,j]);
                }
            }

        }
    }
}
