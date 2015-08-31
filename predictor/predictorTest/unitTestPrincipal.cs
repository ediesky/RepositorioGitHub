using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using predictor;

namespace predictorTest
{
    [TestClass]
    public class unitTestPrincipal
    {
        [TestMethod]
        public void testPredictor()
        {
            string plateNumber = "GHB-7891";
            string date = "08/31/2015";
            string time = "10:00";
            // Act
            bool actual = predictorLibrary.predictProcedure(plateNumber, date, time);
 
            // Assert
            const bool expected = false;
            Assert.AreEqual(expected, actual);
            
        }
        public void anotherTestPredictor()
        {
            string plateNumber = "GHB-7891";
            string date = "08/31/2015";
            string time = "09:00";
            // Act
            bool actual = predictorLibrary.predictProcedure(plateNumber, date, time);

            // Assert
            const bool expected = true;
            Assert.AreEqual(expected, actual);

        }
    }
}
