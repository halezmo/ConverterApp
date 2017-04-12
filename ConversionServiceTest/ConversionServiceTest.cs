using ConversionService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConversionServiceTest
{
    [TestClass]
    public class ConversionServiceTest
    {
        [TestMethod]
        public void TestLengthConversion()
        {
            Conversion conversion = new Conversion();

            ConversionResult conversion1 = conversion.ConvertUnits("1 meter", "feet");

            Assert.AreEqual(conversion1.From, "1 meter");
            Assert.AreEqual(conversion1.Unit, "feet");
            Assert.AreEqual(conversion1.UnitValue, 3.28084);
            Assert.AreEqual(conversion1.ConversionStatus, ConversionStatus.Success);


            ConversionResult conversion2 = conversion.ConvertUnits("1 feet", "meter");

            Assert.AreEqual(conversion2.From, "1 feet");
            Assert.AreEqual(conversion2.Unit, "meter");
            Assert.AreEqual(conversion2.UnitValue, 1/3.28084);
            Assert.AreEqual(conversion2.ConversionStatus, ConversionStatus.Success);
        }

        [TestMethod]
        public void TestFailedConversion()
        {
            Conversion conversion = new Conversion();

            ConversionResult conversion1 = conversion.ConvertUnits("", "");

            Assert.AreEqual(conversion1.ToString(), Conversion.cNotAllParametersDefined);
            Assert.AreEqual(conversion1.ConversionStatus, ConversionStatus.Error);

            ConversionResult conversion2 = conversion.ConvertUnits("", "meter");

            Assert.AreEqual(conversion2.ToString(), Conversion.cNotAllParametersDefined);
            Assert.AreEqual(conversion2.ConversionStatus, ConversionStatus.Error);

            ConversionResult conversion3 = conversion.ConvertUnits("feet", "meter");

            Assert.AreEqual(conversion3.ToString(), Conversion.cNotAllParametersDefined);
            Assert.AreEqual(conversion3.ConversionStatus, ConversionStatus.Error);
        }

        [TestMethod]
        public void TestNotSupportedConversion()
        {
            Conversion conversion = new Conversion();

            ConversionResult conversion1 = conversion.ConvertUnits("1 liter", "meter");

            Assert.IsTrue(conversion1.ToString().Contains(Conversion.cUnsupportedConversion));
            Assert.AreEqual(conversion1.ConversionStatus, ConversionStatus.NotSupported);
        }

        [TestMethod]
        public void TestDataConversion()
        {
            Conversion conversion = new Conversion();

            ConversionResult conversion1 = conversion.ConvertUnits("1 byte", "bit");

            Assert.AreEqual(conversion1.ConversionStatus, ConversionStatus.Success);
            Assert.AreEqual(conversion1.UnitValue, 8);

            ConversionResult conversion2 = conversion.ConvertUnits("16 bit", "byte");

            Assert.AreEqual(conversion2.ConversionStatus, ConversionStatus.Success);
            Assert.AreEqual(conversion2.UnitValue, 2);
        }

        [TestMethod]
        public void TestVolumeConversion()
        {
            Conversion conversion = new Conversion();

            ConversionResult conversion1 = conversion.ConvertUnits("1 liter", "pint");

            Assert.AreEqual(conversion1.ConversionStatus, ConversionStatus.Success);
            Assert.AreEqual(conversion1.UnitValue, 1.7597541412294204);

            ConversionResult conversion2 = conversion.ConvertUnits("1 liter", "cubicinch");

            Assert.AreEqual(conversion2.ConversionStatus, ConversionStatus.Success);
            Assert.AreEqual(conversion2.UnitValue, 61.0237);

            ConversionResult conversion3 = conversion.ConvertUnits("61 cubicinch", "liter");

            Assert.AreEqual(conversion3.ConversionStatus, ConversionStatus.Success);
            Assert.AreEqual(conversion3.UnitValue, 0.99961162630256784);
        }
    }
}
