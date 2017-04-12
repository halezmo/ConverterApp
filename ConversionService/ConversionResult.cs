using System.Text;

namespace ConversionService
{
    public enum ConversionStatus { Success, NotSupported, Error }

    public class ConversionResult
    {
        private string message;
        private string from;
        private string unit;
        private double? unitValue;
        private ConversionStatus conversionStatus;

        public string From { get => from; }
        public string Unit { get => unit; }
        public double? UnitValue { get => unitValue; }
        public ConversionStatus ConversionStatus { get => conversionStatus; }

        public ConversionResult(string from, string unit, double? unitValue, string message)
        {
            this.from = from;
            this.unit = unit;
            this.unitValue = unitValue;
            if (unitValue.HasValue)
            {
                this.conversionStatus = ConversionStatus.Success;
            }
            else
            {
                this.conversionStatus = ConversionStatus.NotSupported;
                this.message = message;
            }
        }

        public ConversionResult(string message, ConversionStatus conversionStatus)
        {
            this.message = message;
            this.conversionStatus = conversionStatus;
        }

        public override string ToString()
        {
            StringBuilder outputValue = new StringBuilder();

            switch (this.conversionStatus)
            {
                case ConversionStatus.Success:
                    outputValue.AppendFormat("{0} to {1} -> {2} {1}", from, unit, unitValue.Value.ToString("0.##"));
                    if (unitValue > 1)
                    {
                        outputValue.Append("s");//for plurar but does not cover all proper grammar cases
                    }
                    break;
                case ConversionStatus.NotSupported:
                    outputValue.AppendFormat("{0} to {1} -> {2}", from, unit, message);
                    break;
                case ConversionStatus.Error:
                    if (!string.IsNullOrEmpty(message))
                    {
                        outputValue.Append(message);
                    }
                    break;
                default:
                    break;
            }
            return outputValue.ToString();
        }
    }
}
