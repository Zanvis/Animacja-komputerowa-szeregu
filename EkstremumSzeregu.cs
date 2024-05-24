using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNr1_Piwowarski62024
{
    internal class EkstremumSzeregu
    {// deklaracje dwóch metod: MinSx oraz MaxSx
        public static double MinSx(double[,] TWS)
        {
            double AktualneMin;
            // ustalenie stanu początkowego
            AktualneMin = TWS[0, 1];
            // sprawdzenie, czy jest jeszcze mniejsza wartość w tablicy TWS w wierszach od 1 do TWS.GetLength(0)
            for (int i = 0; i < TWS.GetLength(0); i++)
                if (AktualneMin > TWS[i, 1])
                    AktualneMin = TWS[i, 1];

            return AktualneMin;
        }
        public static double MaxSx(double[,] TWS)
        {
            double AktualneMax;
            // ustalenie stanu początkowego
            AktualneMax = TWS[0, 1];
            // sprawdzenie, czy jest jeszcze większa wartość w tablicy TWS w wierszach od 1 do TWS.GetLength(0)
            for (int i = 0; i < TWS.GetLength(0); i++)
                if (AktualneMax < TWS[i, 1])
                    AktualneMax = TWS[i, 1];

            return AktualneMax;
        }
    }
}
