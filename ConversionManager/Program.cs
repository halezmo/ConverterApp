using ConversionService;
using System;

namespace ConversionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Conversion conversion = new Conversion();

            Console.WriteLine(conversion.ConvertUnits("", "bit"));
            Console.WriteLine(conversion.ConvertUnits("4 megabyte", "bit"));
            Console.WriteLine(conversion.ConvertUnits("8 bit", "byte"));

            //(“1 meter”, “feet”) -> “3.28 feet”
            Console.WriteLine(conversion.ConvertUnits("1 meter", "feet"));
     
            Console.WriteLine(conversion.ConvertUnits("3 kilometer", "meter"));

            //(“3 kiloinches”, “meter”) -> “76.19 meter”
            Console.WriteLine(conversion.ConvertUnits("3 kiloinch", "meter"));

            //Console.WriteLine(conversion.ConvertUnits("2 pint", "liter"));

            //Console.WriteLine(conversion.ConvertUnits("1 liter", "pint"));

            Console.WriteLine(conversion.ConvertUnits("1 liter", "pint"));

            Console.WriteLine(conversion.ConvertUnits("1 kiloliter", "liter"));

            Console.WriteLine(conversion.ConvertUnits("1 liter", "meter"));//not supported

            Console.WriteLine(conversion.ConvertUnits("1 liter", "cubicinch"));

            Console.WriteLine(conversion.ConvertUnits("61 cubicinch", "liter"));

            Console.ReadLine();
        }
    }
}
