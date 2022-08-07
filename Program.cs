// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Linq;

/*var multiple = Enumerable.Range(1, 10);
void AfficheTable(int n)
{
    var multiple = Enumerable.Range(1, 10);
    var result = multiple.Select(m  => m * n);
    var zip = multiple.Zip(result, multiple.Zip(result, (m,r)=> $"{m} * {n} = {r}"));
    foreach (var r in zip) { Console.WriteLine(r.Third); }
}
AfficheTable(6);*/

/*var sw = new Stopwatch();
sw.Start();
var result = CribleEratostene(5000);
Console.WriteLine($"Crible d'Erathostène elapsedTime : {sw.ElapsedMilliseconds} ms");
sw.Restart();*/
/*var nombreTest = Int32.MaxValue - 4;
var isPrime = IsPrime(nombreTest, out IEnumerable<int> _);
Console.WriteLine(isPrime);
if (!isPrime)
{
    List<String> list = new List<String>();

    foreach (var kvp in GetPrimeDecomposition(nombreTest))
    {
        list.Add($"{kvp.Key}^{kvp.Value}");
    }
    Console.WriteLine($"{nombreTest} = " + String.Join(" x ", list.ToArray()));
}*/
List<String> list = new List<String>();
var number = (int)(Math.Pow(13,5)*Math.Pow(7,4));
foreach (var kvp in GetPrimeDecomposition(number))
{
    list.Add($"{kvp.Key}^{kvp.Value}");
}
Console.WriteLine($"{number} = " + String.Join(" x ", list.ToArray()));



static IEnumerable<int> CribleEratostene(int maxSearchNumber)
{
    var numbers = Enumerable.Range(2, maxSearchNumber - 1).ToList();
    var k = 0;
    while (numbers.Any())
    {
        k = numbers.First();
        numbers.RemoveAll(n => n % k == 0);
        yield return k;
    }
}
static bool IsPrime(int nbr, out IEnumerable<int> diviseursNonTriviaux)
{
    if (nbr == 2)
    {
        diviseursNonTriviaux = Enumerable.Empty<int>();
        return true;
    }
 
    var max = nbr / 2 ;
    var numbers = Enumerable.Range(2, max - 1);
    diviseursNonTriviaux = numbers.Where(n => nbr % n == 0);
    if (diviseursNonTriviaux.Any())
        return false;
    return true;
}
static IEnumerable<KeyValuePair<int, int>> GetPrimeDecomposition(int number)
{
    var test  = IsPrime(number, out IEnumerable<int> diviseurs);

    var primeDiviseurs = diviseurs.Where(d => d!=number && d!=1);
    if(!primeDiviseurs.Any())
        yield break;
    foreach (var primeDiviseur in primeDiviseurs)
    {
        if (!IsPrime(primeDiviseur, out IEnumerable<int> _))
            continue;
        var j = 0;
        while (number % Math.Pow(primeDiviseur, j + 1) == 0)
        {
            j += 1;
        }
        yield return new KeyValuePair<int, int>(primeDiviseur, j);
    }
}

