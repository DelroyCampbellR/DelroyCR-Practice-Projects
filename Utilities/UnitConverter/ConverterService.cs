using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    internal class ConverterService
    {
        //Los métodos están contraídos, como se ve a la izquierda.
        public double ConvertMassUnit(MassEnum from, MassEnum to, double amount)
        {
            double result = 0;
            switch (from)
            {
                case MassEnum.Kilogram: //En caso de que from sea Kilogram, entonces:
                    switch (to)
                    {
                        case MassEnum.Gram:
                            result = amount * 1000;
                            return result;
                        case MassEnum.Miligram:
                            result = amount * 1000000;
                            return result;
                        case MassEnum.Kilogram:
                            result = amount;
                            return result;
                    }
                    break;

                case MassEnum.Gram:  //En caso de que from sea gram, entonces:
                    switch (to)
                    {
                        case MassEnum.Kilogram:
                            result = (amount / 1000);
                            return result;
                        case MassEnum.Miligram:
                            result = amount * 1000;
                            return result;
                        case MassEnum.Gram:
                            result = amount;
                            return result;

                    }
                    break;

                case MassEnum.Miligram:  //En caso de que from sea miligram, entonces:
                    switch (to)
                    {
                        case MassEnum.Kilogram:
                            result = (amount / 1000000);
                            return result;
                        case MassEnum.Gram:
                            result = (amount / 100);
                            return result;
                        case MassEnum.Miligram:
                            result = amount;
                            return result;
                    }
                    break;
            }
            return 0;
        }

        public double ConvertTemperatureUnit(TemperatureEnum from, TemperatureEnum to, double amount)
        {
            double result = 0;
            switch (from)
            {
                case TemperatureEnum.Celcius: //En caso de que from sea Celcius, entonces:
                    switch (to)
                    {
                        case TemperatureEnum.Kelvin:
                            result = (amount + 273.15);
                            return result;
                        case TemperatureEnum.Farenheit:
                            result = ((amount * 1.8) + 32);
                            return result;
                        case TemperatureEnum.Celcius:
                            result = amount;
                            return result;
                    }
                    break;

                case TemperatureEnum.Farenheit:  //En caso de que from sea Farenheit, entonces:
                    switch (to)
                    {
                        case TemperatureEnum.Kelvin:
                            result = (amount - 32) * 0.55556 + 273.15;
                            return result;
                        case TemperatureEnum.Celcius:
                            result = (amount - 32) * 0.55556;
                            return result;
                        case TemperatureEnum.Farenheit:
                            result = amount;
                            return result;
                    }
                    break;

                case TemperatureEnum.Kelvin:  //En caso de que from sea Kelvin, entonces:
                    switch (to)
                    {
                        case TemperatureEnum.Farenheit:
                            result = (amount - 273.15) * 1.8 + 32;
                            return result;
                        case TemperatureEnum.Celcius:
                            result = (amount - 273.15);
                            return result;
                        case TemperatureEnum.Kelvin:
                            result = amount;
                            return result;
                    }
                    break;
            }
            return 0;
        }

        public double ConvertTimeUnit(TimeEnum from, TimeEnum to, double amount)
        {
            double result = 0;
            switch (from)
            {
                case TimeEnum.Miliseconds: //En caso de que from sea Miliseconds, entonces:
                    switch (to)
                    {
                        case TimeEnum.Minutes:
                            result = (amount / 60000);
                            return result;
                        case TimeEnum.Seconds:
                            result = (amount / 1000);
                            return result;
                        case TimeEnum.Hours:
                            result = (amount / 3600000);
                            return result;
                        case TimeEnum.Miliseconds:
                            result = amount;
                            return result;
                    }
                    break;

                case TimeEnum.Seconds:  //En caso de que from sea Seconds, entonces:
                    switch (to)
                    {
                        case TimeEnum.Minutes:
                            result = (amount / 60);
                            return result;
                        case TimeEnum.Miliseconds:
                            result = (amount * 100);
                            return result;
                        case TimeEnum.Hours:
                            result = (amount / 3600);
                            return result;
                        case TimeEnum.Seconds:
                            result = amount;
                            return result;
                    }
                    break;

                case TimeEnum.Minutes:  //En caso de que from sea Minutes, entonces:
                    switch (to)
                    {
                        case TimeEnum.Miliseconds:
                            result = (amount * 60000);
                            return result;
                        case TimeEnum.Seconds:
                            result = (amount * 60);
                            return result;
                        case TimeEnum.Hours:
                            result = (amount / 60);
                            return result;
                        case TimeEnum.Minutes:
                            result = amount;
                            return result;
                    }
                    break;

                case TimeEnum.Hours:  //En caso de que from sea Hours, entonces:
                    switch (to)
                    {
                        case TimeEnum.Miliseconds:
                            result = (amount * 3600000);
                            return result;
                        case TimeEnum.Seconds:
                            result = (amount * 3600);
                            return result;
                        case TimeEnum.Minutes:
                            result = (amount * 60);
                            return result;
                        case TimeEnum.Hours:
                            result = amount;
                            return result;
                    }
                    break;
            }
            return 0;
        }
    }
}
