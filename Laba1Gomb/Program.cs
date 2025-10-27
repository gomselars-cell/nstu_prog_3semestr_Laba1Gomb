using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1Gomb
{
    internal class Program
    {
        public static void Main()
        {
            float m = float.MaxValue;
            Console.WriteLine(m);
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
