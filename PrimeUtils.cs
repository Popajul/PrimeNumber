using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    public static class PrimeUtils
    {
        /// <summary>
        /// Return Enumerable of prime numbers lower or equal than maxSearchNumber
        /// </summary>
        /// <param name="maxSearchNumber"></param>
        /// <returns></returns>
        public static IEnumerable<int> CribleEratostene(int maxSearchNumber)
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

        public static List<int> GetPrimeNumberBelow(int maxSearchNumber)
        {
            var test = CribleEratostene(maxSearchNumber).ToList();
            return test;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbr"></param>
        /// <param name="diviseursNonTriviaux"></param>
        /// <returns>Set List of numbers except 1 and 2 who divises input number and return false is list.Any() or input number is 2</returns>
        static bool IsPrime(int nbr, out IEnumerable<int> diviseursNonTriviaux)
        {
            if (nbr == 2)
            {
                diviseursNonTriviaux = Enumerable.Empty<int>();
                return true;
            }

            var max = nbr / 2;
            var numbers = Enumerable.Range(2, max - 1);
            diviseursNonTriviaux = numbers.Where(n => nbr % n == 0);
            if (diviseursNonTriviaux.Any())
                return false;
            return true;
        }

        static IEnumerable<KeyValuePair<int, int>> GetPrimeDecomposition(int number)
        {
            _ = IsPrime(number, out IEnumerable<int> diviseurs);

            var primeDiviseurs = diviseurs.Where(d => d != number && d != 1);
            if (!primeDiviseurs.Any())
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
                var kvp = new KeyValuePair<int, int>(primeDiviseur, j);
                Console.WriteLine($"facteur de décomposition de {number} : {kvp.Key} exposant {kvp.Value}");
                yield return kvp ;
            }
        }

        static List<KeyValuePair<int, int>> PrimeDecompositionList(int number)
        {
            return GetPrimeDecomposition(number).ToList();
        }
    }
}
