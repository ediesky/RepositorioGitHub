using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using predictor;

namespace predictorTest
{
    [TestClass]
    public class unitTestPrincipal
    {
        [TestMethod]
        public void availableStreet_checkValidDate_ReturnMessageDateIncorrect()
        {
            string plateNumber = "GHB-7891";
            string date = "18/31/2015";
            string time = "10:00";
            // Act
            string actual = predictorLibrary.availableStreet(plateNumber, date, time);
            // Assert
            const string expected = "Incorrect date format";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void availableStreet_checkValidPlateNumber_ReturnMessagePlateNumberIncorrect()
        {
            string plateNumber = "GHBR-7891";
            string date = "08/31/2015";
            string time = "10:00";
            // Act
            string actual = predictorLibrary.availableStreet(plateNumber, date, time);
            // Assert
            const string expected = "Incorrect plate number format";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void availableStreet_checkValidTime_ReturnMessageTimeIncorrect()
        {
            string plateNumber = "GHB-7891";
            string date = "08/31/2015";
            string time = "s0:00";
            // Act
            string actual = predictorLibrary.availableStreet(plateNumber, date, time);
            // Assert
            const string expected = "Incorrect time format";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void availableStreet_checkValidResponse_ReturnAllStreets()
        {
            string plateNumber = "GHB-7891";
            string date = "08/31/2015";
            string time = "10:00";
            // Act
            string actual = predictorLibrary.availableStreet(plateNumber, date, time);
            // Assert
            const string expected = "It can circulate on all streets";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void availableStreet_checkValidResponse_ReturnRestrictionsStreets()
        {
            string plateNumber = "GHB-7891";
            string date = "08/31/2015";
            string time = "09:00";
            // Act
            string actual = predictorLibrary.availableStreet(plateNumber, date, time);
            // Assert
            const string expected = "It can't circulate on this street(s): av. Morán Valverde al sur , la Occidental al oeste , av. Diego de Vásquez , Galo Plaza al norte , av. Simón Bolívar ";
            Assert.AreEqual(expected, actual);
        }
    }
}
