using System;
using System.Collections.Generic;
using System.Text;

namespace Csomagszallito_FszR
{
    public static class UzemanyagKalkulator
    {
        public static double BecsultUzemanyagKoltseg(int osszKm)
        {
            return osszKm * 0.08 * 600;
        }
    }
}
