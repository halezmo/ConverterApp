using System.Collections.Generic;

namespace ConversionService
{
    public class ConversionFactorDefinition
    {
        private List<ConversionFactor> conversionFactors = new List<ConversionFactor>();

        public ConversionFactorDefinition()
        {
            InitializeConversionFactors();//next step would be to load this conversion factors from some config file
        }

        private void InitializeConversionFactors()
        {
            //length
            AddConversionFactor("meter", "feet", 3.28084);
            AddConversionFactor("meter", "inch", 39.3701);
            AddConversionFactor("feet", "inch", 12);

            //digital
            AddConversionFactor("bit", "byte", 0.125);

            //mass
            AddConversionFactor("gram", "pound", 0.00220462);

            //volume
            AddConversionFactor("pint", "liter", 0.5682612);//imperial pint
            AddConversionFactor("cubicfeet", "liter", 28.3168);
            AddConversionFactor("liter", "cubicinch", 61.0237);
        }

        private void AddConversionFactor(string fromUnit, string toUnit, double factor)
        {
            conversionFactors.Add(new ConversionFactor(fromUnit, toUnit, factor));
        }

        public List<ConversionFactor> ConversionFactors { get => conversionFactors; }
    }


    public class ConversionFactor
    {
        private string fromUnit;
        private string toUnit;
        private double factor;

        public ConversionFactor(string fromUnit, string toUnit, double factor)
        {
            this.fromUnit = fromUnit;
            this.toUnit = toUnit;
            this.factor = factor;
        }

        public string FromUnit { get => fromUnit; }
        public string ToUnit { get => toUnit; }
        public double Factor { get => factor; }
    }
}
