using Laba1Gomb;
using static Laba1Gomb.TypeOfScreenResolution;

namespace Laba1GombTests
{
    [TestClass]
    public class TelevisionTests
    {
        private const TypeOfScreenResolution ValidScreenResolution = FHD;
        private const byte ValidScreenDiagonal = 43;


        //конструкторы
        [TestMethod]
        public void DefaultConsrtuctor_ShouldSetDefaultValues()
        {
            var tv = new Television();
            Assert.AreEqual(Constants.DefaultFirm, tv.Firm);
            Assert.AreEqual(Constants.DefaultPrice, tv.Price);
            Assert.AreEqual(Constants.DefaultScreenResolution, tv.ScreenResolution);
            Assert.AreEqual(Constants.DefaultScreenDiagonal, tv.ScreenDiagonal);
        }

        [TestMethod]
        public void ParamConstructor_ValidArguments_ShouldSetProperties()
        {
            var tv = new Television(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, ValidScreenResolution, ValidScreenDiagonal);
            
            Assert.AreEqual(AVDeviceTests.ValidFirm, tv.Firm);
            Assert.AreEqual(AVDeviceTests.ValidPrice, tv.Price);
            Assert.AreEqual(ValidScreenResolution, tv.ScreenResolution);
            Assert.AreEqual(ValidScreenDiagonal, tv.ScreenDiagonal);
        }

        // сеттер ScreenResolution
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ScreenResolutionSetter_InvalidScreenResolution_ShouldThrowArgumentOutOfRangeException()
        {
            TypeOfScreenResolution InvalidScreenResolution = (TypeOfScreenResolution)100;
            var tv = new Television(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, InvalidScreenResolution, ValidScreenDiagonal);
        }

        // сеттер ScreenDiagonal
        [TestMethod, ExpectedException (typeof(ArgumentOutOfRangeException))]
        public void ScreenDiagonalSetter_ZeroScreenDiagonal_ShouldThrowArgumentOutOfRangeException()
        {
            var tv = new Television(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, ValidScreenResolution, 0);
        }

        [TestMethod]
        public void ScreenDiagonalSetter_MaxScreenDiagonal_Success()
        {
            var tv = new Television(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, ValidScreenResolution, Constants.Max_ScreenDiagonal);
            Assert.AreEqual(Constants.Max_ScreenDiagonal, tv.ScreenDiagonal);
        }

        // строка для вывода
        [TestMethod]
        public void Print_ReturnsCorrectString()
        {
            var tv = new Television(AVDeviceTests.ValidFirm, AVDeviceTests.ValidPrice, ValidScreenResolution, ValidScreenDiagonal);
            string expected = $"Фирма: {AVDeviceTests.ValidFirm}\nЦена: {AVDeviceTests.ValidPrice} \nРазрешение телевизора: {ValidScreenResolution}\nДиагональ экрана: {ValidScreenDiagonal} inch\n";

            string result = tv.Print();

            Assert.AreEqual(expected, result);
        }
    }
}
