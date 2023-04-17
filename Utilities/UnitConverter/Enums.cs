using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    //Enum "general"
    public enum TypeEnum
    {
        Mass,
        Temperature,
        Time
    }

    //Enums "secundarios"
    public enum MassEnum
    {
        Miligram,
        Gram,
        Kilogram
    }

    public enum TemperatureEnum
    {
        Celcius,
        Farenheit,
        Kelvin
    }

    public enum TimeEnum
    {
        Miliseconds,
        Seconds,
        Minutes,
        Hours
    }
}
