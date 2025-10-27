using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1Gomb
{
    public class Constants
    {
        //предельные значения
        static public int MAX_LEN = 20;
        static public decimal MAX_PRICE = 100000000;
        static public byte Max_ScreenDiagonal = byte.MaxValue;

        //значения по умолчанию для конструкторов
        static public string DefaultFirm = "Undefined";
        static public decimal DefaultPrice = 1.0m;

        static public TypeOfScreenResolution DefaultScreenResolution = TypeOfScreenResolution.HD;
        static public byte DefaultScreenDiagonal = 1;

        static public string DefaultModel = "Undefined";
        static public TypeOfOperatingRanges DefaultOperatingRanges = TypeOfOperatingRanges.FM;
    }
}
