using Laba1Gomb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Laba1Gomb.TypeOfOperatingRanges;

namespace Laba1GombTests
{
    [TestClass]
    public class RadioReceiverTests
    {
        private const string ValidModel = "RF-2400DEE-K";
        private const TypeOfOperatingRanges ValidOperatingRanges = DAB;

        // конструкторы
        [TestMethod]
        public void DefaultConsrtuctor_ShouldSetDefaultValues()
        {
            var radio = new RadioReceiver();
            Assert.AreEqual(Constants.DefaultFirm, radio.Firm);
            Assert.AreEqual(Constants.DefaultPrice, radio.Price);
            Assert.AreEqual(Constants.DefaultModel, radio.Model);
            Assert.AreEqual(Constants.DefaultOperatingRanges, radio.OperatingRanges);
        }

        [TestMethod]
        public void ParamConstructor_ValidArguments_ShouldSetProperties()
        {
            var radio = new RadioReceiver(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, ValidModel, ValidOperatingRanges);

            Assert.AreEqual(AVDeviceTests.ValidFirm, radio.Firm);
            Assert.AreEqual(AVDeviceTests.ValidPrice, radio.Price);
            Assert.AreEqual(ValidModel, radio.Model);
            Assert.AreEqual(ValidOperatingRanges, radio.OperatingRanges);
        }

        // сеттер модели
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ModelSetter_EmptyString_ShouldThrowArgumentNullException()
        {
            var radio = new RadioReceiver(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, "", ValidOperatingRanges);

        }

        [TestMethod]
        public void ModelSetter_MinLengthString_Success()
        {
            string MinLengthModel = "A";
            var radio = new RadioReceiver(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, MinLengthModel, ValidOperatingRanges);
            Assert.AreEqual(MinLengthModel, radio.Model);
        }

        [TestMethod]
        public void ModelSetter_MaxLengthString_Success()
        {
            string MaxLengthModel = new string('A', Constants.MAX_LEN);
            var radio = new RadioReceiver(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, MaxLengthModel, ValidOperatingRanges);
            Assert.AreEqual(MaxLengthModel, radio.Model);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ModelSetter_LongString_ShouldThrowArgumentOutOfRangeException()
        {
            string LongLengthModel = new string('A', Constants.MAX_LEN + 1);
            var radio = new RadioReceiver(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, LongLengthModel, ValidOperatingRanges);
        }

        // сеттер OperatingRanges
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OperatingRangesSetter_InvalidScreenResolution_ShouldThrowArgumentOutOfRangeException()
        {
            TypeOfOperatingRanges InvalidOperatingRanges = (TypeOfOperatingRanges)100;
            var radio = new RadioReceiver(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, ValidModel, InvalidOperatingRanges);
        }

        // строка для вывода
        [TestMethod]
        public void Print_ReturnsCorrectString()
        {
            var radio = new RadioReceiver(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, ValidModel, ValidOperatingRanges);
            string expected = $"Фирма: {AVDeviceTests.ValidFirm}\nЦена: {AVDeviceTests.ValidPrice} \nМодель радиоприемника: {ValidModel}\nДиапазон работы: {ValidOperatingRanges}\n";

            string result = radio.Print();

            Assert.AreEqual(expected, result);
        }
    }
}
