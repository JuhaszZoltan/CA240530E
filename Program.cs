using CA240530E;
using System.Text;

List<Pontszerzo> pontszerzok = [];

using StreamReader sr = new(@"..\..\..\src\helsinki.txt", Encoding.UTF8);
while (!sr.EndOfStream) pontszerzok.Add(new(sr.ReadLine()));

Console.WriteLine("3. feladat:");
Console.WriteLine($"Pontszerzo helyezesek szama: {pontszerzok.Count}");

int aranyErmek = pontszerzok.Count(p => p.Helyezes == 1);
int ezustErmek = pontszerzok.Count(p => p.Helyezes == 2);
int bronzErmek = pontszerzok.Count(p => p.Helyezes == 3);

Console.WriteLine("4. feladat:");
Console.WriteLine($"arany: {aranyErmek}");
Console.WriteLine($"ezust: {ezustErmek}");
Console.WriteLine($"bronz: {bronzErmek}");
Console.WriteLine($"osszesen: {aranyErmek + ezustErmek + bronzErmek}");

Console.WriteLine("5. feladat:");
int olimpiaiPontok = pontszerzok.Sum(p => p.OlimpiaiPont);
Console.WriteLine($"olimpiapi pontok szama: {olimpiaiPontok}");

int uszasErem = pontszerzok.Count(p => p.Sportag == "uszas");
int tornaErem = pontszerzok.Count(p => p.Sportag == "torna");

Console.WriteLine("6.feladat:");
if (uszasErem > tornaErem) Console.WriteLine("uszas sportagban szereztek tobb ermet");
else if (tornaErem > uszasErem) Console.WriteLine("torna sportagban szereztek tobb ermet");
else Console.WriteLine("egyenlo volt az ermek szama");

using StreamWriter sw = new(@"..\..\..\src\helsinki2.txt", false, Encoding.UTF8);
foreach (var p in pontszerzok)
{
    string sn = p.Sportag == "kajakkenu" ? "kajak-kenu" : p.Sportag;
    sw.WriteLine($"{p.Helyezes} {p.Sportolok} {p.OlimpiaiPont} {sn} {p.Versenyszam}");
}

Console.WriteLine("8. feladat:");
Pontszerzo maxSportolo = pontszerzok.MaxBy(p => p.Sportolok);
Console.WriteLine(maxSportolo);

//------------------------------------------
Console.WriteLine("----------------------------");
//atlag
//atlagosan hany sportolo volt egy helyezést szerzo csapatban
double avg = pontszerzok.Average(p => p.Sportolok);
Console.WriteLine($"avg: {avg}");


//sorozatszámítás (sum) -> atlag
//megszámlálás

//szélsőérték-meghatározás
//hany sportolo volt a legnagyobb letszamu pontszerzo csapatban
int max = pontszerzok.Max(p => p.Sportolok);
Console.WriteLine($"max: {max}");

//kiválasztás
//first, last, single

//elso olyan elem a listabol, ahol a sportolok szama meghaladja az 5ot
Pontszerzo first = pontszerzok.First(p => p.Sportolok > 5);
Console.WriteLine(first);

//first, last,
//ha van találat, akkor visszaadja az elsőt/utolsót
//ha nincs, akkor exception

//lineáris keresés
//firstordefault, lastordefault, singleordefault

Pontszerzo firstordef = pontszerzok.FirstOrDefault(p => p.Sportolok > 500);
Console.WriteLine(firstordef is null);

//firstordefault, lastordefault
//ha van találat, akkor visszaadja az elsőt/utolsót
//ha nincs találat, akkor null érték kerül az eredménybe

//-----------

//single
//ha van találat, és egyedi -> visszadja
//ha van talkálat, de több is -> exception
//ha nincs találat -> exception

//single or default
//ha van találat, és egyedi -> visszadja
//ha van talkálat, de több is -> exception
//ha nincs találat -> null (value type esetén default érték)

//eldontés
var any = pontszerzok.Any(p => p.Versenyszam == "ferfi_csapat");
Console.WriteLine($"any: {any}");

//kiválogatás
var where = pontszerzok.Where(p => p.Sportag == "uszas");
Console.WriteLine("minden uszas:");
foreach (var item in where)
{
    Console.WriteLine(item);
    Console.WriteLine("----");
}

Console.WriteLine("##########################");
//szétválogatás
var groupby = pontszerzok.GroupBy(p => p.Sportag);
foreach (var grp in groupby)
{
    Console.WriteLine($"{grp.Key}");
    foreach (var element in grp)
    {
        Console.WriteLine($"\t{element.Versenyszam}");
    }
}

//rendezés
var rendezett = pontszerzok.OrderBy(p => p.Sportolok);
foreach (var item in rendezett)
{
    Console.WriteLine($"{item.Sportolok}: {item.Versenyszam}");
}


//azok az atlétikai versenyszámok, amiből lett dobogós hely, helyezes szerint rendezve
var res = pontszerzok
    .Where(p => p.Sportag == "atletika" && p.Helyezes <= 3)
    .OrderBy(p => p.Helyezes);

Console.WriteLine("************");
foreach (var item in res)
{
    Console.WriteLine($"{item.Helyezes} {item.Versenyszam}");
}