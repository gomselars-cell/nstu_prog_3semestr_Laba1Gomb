using Laba1Gomb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Laba1GombTests
{
    [TestClass]
    public class AVDeviceTests
    {
        public const string ValidFirm = "Sony";
        public const decimal ValidPrice = 499.99m;

        // конструкторы
        [TestMethod]
        public void DefaultConstructor_ShouldSetDefaultValues()
        {
            var device = new AVDevice();

            Assert.AreEqual(Constants.DefaultFirm, device.Firm);
            Assert.AreEqual(Constants.DefaultPrice, device.Price);
        }

        [TestMethod]
        public void ParamConstructor_ValidArguments_ShouldSetProperties()
        {
            var device = new AVDevice(ValidFirm, ValidPrice);

            Assert.AreEqual(ValidFirm, device.Firm);
            Assert.AreEqual(ValidPrice, device.Price);
        }


        // сеттер фирмы
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FirmSetter_EmptyString_ShouldThrowArgumentNullException()
        {
            var device = new AVDevice("", ValidPrice);
        }

        [TestMethod]
        public void FirmSetter_MinLengthString_Success()
        {
            string MinLengthFirm = "A";
            var device = new AVDevice(MinLengthFirm, ValidPrice);
            Assert.AreEqual(MinLengthFirm, device.Firm);
        }

        [TestMethod]
        public void FirmSetter_MaxLengthString_Success()
        {
            string MaxLengthFirm = new string('A', Constants.MAX_LEN);
            var device = new AVDevice(MaxLengthFirm, ValidPrice);
            Assert.AreEqual(MaxLengthFirm, device.Firm);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FirmSetter_LongString_ShouldThrowArgumentOutOfRangeException()
        {
            string LongFirm = new string('A', Constants.MAX_LEN + 1);
            var device = new AVDevice(LongFirm, ValidPrice);
        }


        //сеттер цены
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PriceSetter_ZeroPrice_ShouldThrowArgumentOutOfRangeException()
        {
            var device = new AVDevice(ValidFirm, 0.0m);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PriceSetter_NegativePrice_ShouldThrowArgumentOutOfRangeException()
        {
            var device = new AVDevice(ValidFirm, -1.0m);
        }

        public void PriceSetter_BigPrice_ShouldThrowArgumentOutOfRangeException()
        {
            var device = new AVDevice(ValidFirm, Constants.MAX_PRICE + 1);
        }

        [TestMethod]
        public void PriceSetter_MaxPrice_Success()
        {
            decimal MaxPrice = Constants.MAX_PRICE;
            var device = new AVDevice(ValidFirm, MaxPrice);
            Assert.AreEqual(MaxPrice, device.Price);
        }

        // строка для вывода
        [TestMethod]
        public void Print_ReturnsCorrectString()
        {
            var device = new AVDevice(ValidFirm, ValidPrice);
            string expected = $"Фирма: {ValidFirm}\nЦена: {ValidPrice} \n";

            string result = device.Print();

            Assert.AreEqual(expected, result);
        }
    }
}
