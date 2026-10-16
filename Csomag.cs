using System;
using System.Collections.Generic;
using System.Text;

namespace Csomagszallito_FszR
{
    public class Csomag
    {
        private int sulyKg;
        private int tavolsagKm;
        private static int osszesCsomagSzam = 0;
        public string CsomagKod { get; private set; }
        public string Cimzett { get; private set; }
        public int SulyKg
        {
            get => sulyKg;
            set => sulyKg = value < 1 ? 1 : value;
        }
        public int TavolsagKm
        {
            get => tavolsagKm;
            set => tavolsagKm = value < 1 ? 1 : value;
        }
        public static int OsszesCsomagSzam 
        {
            get => osszesCsomagSzam;
        }
        public Csomag(string csomagKod, string cimzett, int sulyKg):this(csomagKod, cimzett, sulyKg, 10) 
        {
        }
        public Csomag(string csomagKod, string cimzett, int sulyKg, int tavolsagKm) 
        {
            CsomagKod = csomagKod;
            Cimzett = cimzett;
            SulyKg = sulyKg;
            TavolsagKm = tavolsagKm;
            osszesCsomagSzam++;
        }
        
        public int KiszallitasiDij()
        {
            return 500 + (tavolsagKm * 100) + (sulyKg * 200);
        }
        public override string ToString()
        {
            return $"[{CsomagKod}] Címzett: {Cimzett} | Súly: {SulyKg} kg | Távolság: {TavolsagKm} km | Díj: {KiszallitasiDij()} Ft";
        }

        
    }
}
