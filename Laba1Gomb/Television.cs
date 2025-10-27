using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1Gomb
{
    public enum TypeOfScreenResolution
    {
        HD, FHD, FourK_UHD, EightK_UHD
    }
    public class Television : AVDevice
    {
        protected TypeOfScreenResolution screenResolution;
        protected byte screenDiagonal;

        public Television() : base()
        {
            ScreenResolution = Constants.DefaultScreenResolution;
            ScreenDiagonal = Constants.DefaultScreenDiagonal;
        }
        public Television(string firm, decimal price, TypeOfScreenResolution screenResolution, byte screenDiagonal) :
            base(firm, price)
        {
            ScreenResolution = screenResolution;
            ScreenDiagonal = screenDiagonal;
        }
        public TypeOfScreenResolution ScreenResolution
        {
            get => screenResolution;
            protected set
            {
                if (!Enum.IsDefined(typeof(TypeOfScreenResolution), value))
                    throw new ArgumentOutOfRangeException("Недопустимое разрешение экрана");
                screenResolution = value;
            }
        }
        public byte ScreenDiagonal
        {
            get => screenDiagonal;
            protected set
            {
                if (value == 0)
                    throw new ArgumentOutOfRangeException("Диагональ телевизора не может равна нулю");
                screenDiagonal = value;
            }
        }


        public override string Print()
        {
            return base.Print() + $"Разрешение телевизора: {screenResolution}\nДиагональ экрана: {screenDiagonal} inch\n";
        }
    }
}
