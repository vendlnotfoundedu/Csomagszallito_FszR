using Csomagszallito_FszR;

List<Csomag> csomagok = new List<Csomag>();

if (!File.Exists("csomagok.txt"))
{
    Console.WriteLine("[HIBA] A csomagok.txt fájl nem található!");
    return;
}
foreach (string sor in File.ReadAllLines("csomagok.txt"))
{
  if (string.IsNullOrWhiteSpace(sor)) continue;
  string[] adatok = sor.Split(";");
  if (adatok.Count() ==3)
  {
    if (int.TryParse(adatok[2], out int suly))
    {
     csomagok.Add(new Csomag(adatok[0], adatok[1], suly));
    }
    else
    {
    Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú sor súly adata hibás, átugorva!");
    }
  }
  else if (adatok.Length == 4)
  {
    if (int.TryParse(adatok[2], out int suly) && int.TryParse(adatok[3], out int tavolsag))
    {
     csomagok.Add(new Csomag(adatok[0], adatok[1], suly, tavolsag));
    }
    else
    {
        Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú sor számkonverziója nem sikerült, átugorva!");
    }
  }
  else
  {
    Console.WriteLine($"[HIBA] A sor hiányos vagy érvénytelen adatokat tartalmaz, átugorva!");
  }

}
Console.WriteLine("-- BEOLVASOTT CSOMAGOK --");
foreach (Csomag csomag in csomagok) Console.WriteLine(csomag.ToString());
Console.WriteLine($"Összes regisztrált csomag: {Csomag.OsszesCsomagSzam}");
int teljestavolsag = 0;
foreach (Csomag cs in csomagok) teljestavolsag += cs.TavolsagKm;
Console.WriteLine($"A csomagok összesített szállítási távolsága: {teljestavolsag} km");
Console.WriteLine($"Az erre a távra becsült üzemanyagköltség: {UzemanyagKalkulator.BecsultUzemanyagKoltseg(teljestavolsag)}");
Console.WriteLine($"A legmagasabb szállítási díjú csomag: {csomagok.MaxBy(c => c.KiszallitasiDij())} Ft");


