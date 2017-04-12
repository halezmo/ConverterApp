# ConverterApp
converting quantities between different units

used as reference: https://www.isa.org/uploadedFiles/Content/Training_and_Certifications/ISA_Certification/CCST-Conversions-document.pdf

Class ConversionFactorDefinition has all defined conversion factors, like

AddConversionFactor("meter", "feet", 3.28084);
AddConversionFactor("meter", "inch", 39.3701);
AddConversionFactor("feet", "inch", 12);
...

Any additional unit conversion definition should be added there. Ideally this set of conversion factors should be defined
in some config file.
            
