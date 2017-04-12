using System.Collections.Generic;

namespace ConversionService
{
    class PrefixDefinition
    {
        private Dictionary<string, double> prefixList = new Dictionary<string, double>();

        public PrefixDefinition()
        {
            //these are standard values and its file to be defined here
            addPreffix("tera", 1000000000000);
            addPreffix("giga", 1000000000);
            addPreffix("mega", 1000000);
            addPreffix("kilo", 1000);
            addPreffix("hecto", 100);
            addPreffix("deca", 10);
            addPreffix("deci", 0.1);
            addPreffix("centi", 0.01);
            addPreffix("milli", 0.001);
            addPreffix("micro", 0.000001);
            addPreffix("nano", 0.000000001);
            addPreffix("pico", 0.000000000001);
        }

        public Dictionary<string, double> PrefixList { get => prefixList; }

        private void addPreffix(string name, double factor)
        {
            PrefixList.Add(name, factor);
        }
    }
}
