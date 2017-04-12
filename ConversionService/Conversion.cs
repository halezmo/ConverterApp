using System;
using System.Text;

namespace ConversionService
{
    public class Conversion
    {
        public const string cNotAllParametersDefined = "Not all parameters defined";
        public const string cUnsupportedConversion = "Unsupported conversion";

        //has info about prefixes
        private PrefixDefinition prefixDefinition = new PrefixDefinition();

        //conversion factors are defined here
        private ConversionFactorDefinition conversionFactorDefinition = new ConversionFactorDefinition();

        public ConversionResult ConvertUnits(string from, string to)
        {
            //if parameters not defined, cant proceed with conversion
            if(string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                return new ConversionResult(cNotAllParametersDefined, ConversionStatus.Error);
            }

            //spliting input in order to parse entry properly
            string[] fromSegments = from.Split(' ');

            //if first segment not fully defined, stop conversion
            if (fromSegments.Length < 2)
            {
                return new ConversionResult(cNotAllParametersDefined, ConversionStatus.Error);
            }

            //first value is value we want to convert
            string fromValue = fromSegments[0];

            //I am extracting prefix factor if its provided
            Tuple<string, double> fromUnitDefinition = extractPrefixFactor(fromSegments[1]);

            //I use extracted prefix factor to put value to proper scale
            double factoredValue = Convert.ToDouble(fromValue) * fromUnitDefinition.Item2;

            //first paremet is unit from, 2nd is unit to and, 3rs is value of unit that we want to convert
            double? convertedValue = ConvertToUnit(fromUnitDefinition.Item1, to, factoredValue);

            //creating string result
            return new ConversionResult(from, to, convertedValue, cUnsupportedConversion);
        }

        //checks the list of defined prefixes and checks if those are used in input parameter, also removes that prefix from initial value
        private Tuple<string, double> extractPrefixFactor(string unitValue)
        {
            double prefixFactor = 1;
            string unitName = unitValue;

            foreach (var prefix in prefixDefinition.PrefixList)
            {
                if (unitValue.Contains(prefix.Key))
                {
                    prefixFactor = prefix.Value;
                    unitName = unitValue.Replace(prefix.Key, string.Empty);
                    break;
                }
            }
            return new Tuple<string, double>(unitName, prefixFactor);
        }

        //some conversion definition has to be defined in order to detect proper conversion factor
        private double? ConvertToUnit(string fromUnit, string toUnit, double fromValue)
        {
            double? detectedConvertionFactor = fromUnit.Equals(toUnit) ? 1 : (double?)null;//set to 1 if same unit is used

            foreach (var conversionFactor in conversionFactorDefinition.ConversionFactors)
            {
                //look for exact match from->to
                if (conversionFactor.FromUnit.Equals(fromUnit) && conversionFactor.ToUnit.Equals(toUnit))
                {
                    detectedConvertionFactor = conversionFactor.Factor;
                    break;

                }
                //look for inverted match, 1/factor
                else if (conversionFactor.FromUnit.Equals(toUnit) && conversionFactor.ToUnit.Equals(fromUnit))
                {
                    detectedConvertionFactor = 1 / conversionFactor.Factor;
                    break;
                }
            }
            if (detectedConvertionFactor.HasValue)
            {
                return fromValue * detectedConvertionFactor.Value;
            }
            return null;
        }
    }
}
