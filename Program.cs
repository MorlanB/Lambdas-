using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ex 1: Sustitución
            List<string> strs = new List<string>
            {
                "Imagine",
                "Respect",
                "Good Vibrations",
                "Stairway to Heaven",
                "Sympathy for the Devil",
                "You've Lost That Lovin' Feelin'",
                "Hotel California",
                "Love and Hapiness",
                "Roll Over Beethoven",
                "Strawberry Fields Forever"
            };

            foreach (string str in strs)
                Console.WriteLine(str);
            Console.WriteLine("\n");

            List<string> replaced = new List<string>();
            replaced = strs.Select(str => {
                string result = Regex.Replace(str, "v", "s", RegexOptions.IgnoreCase);
                return string.Join(" ", result.Split(" ")
                .Select( w => char.ToUpper(w[0]) + w.Substring(1)));
            })
            .ToList();

            foreach (string str in replaced)
                Console.WriteLine(str);
            Console.WriteLine("\n");
            #endregion

            #region Ex 2: Duplicados
            List<string> strs1 = new List<string>
            {
                "Imagine",
                "Respect",
                "Hotel California",
                "Whiter Shade of Pale",
                "When Doves Cry",
                "Hotel California",
                "Imagine",
                "Eleanor Rigby",
                "Respect",
                "Imagine",
            };

            var duplicates = strs1
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (var d in duplicates)
                Console.WriteLine(d);
            Console.WriteLine("\n");

            var singles = strs1
                .GroupBy(i => i)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key);

            foreach (var s in singles)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            #endregion

            #region Ex 3: Operaciones con Object.property

            List<Valor> valores = new List<Valor>()
            {
                new Valor ("Uruguay",4.8),
                new Valor ("Chile",4.09),
                new Valor ("Brasil",3.98),
                new Valor ("Costa Rica",3.83),
                new Valor ("Argentina",3.75),
                new Valor ("Honduras",3.61),
                new Valor ("Nicaragua",3.56),
                new Valor ("Perú",3.2),
                new Valor ("Guatemala", 3.2),
                new Valor ("México", 2.68)
            };

            //SUMA
            Console.WriteLine("Suma: " + valores.Sum(v => v.value) + "\n");

            //PROMEDIO
            Console.WriteLine("Promedio: " + valores.Average(v => v.value) + "\n");

            //MODA
            Console.WriteLine("moda: " +
                valores
                .GroupBy(i => i.value)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key)
                .Select(x => (double)x.Key)
                .FirstOrDefault()
                + "\n");

            //PRODUCTO
            double producto = 1;
            valores.ForEach(v => producto *= v.value);
            Console.WriteLine("producto: " + producto + "\n");

            #endregion

            #region Ex 4: Convertir clase

            List<Valor1> valores1;
            valores1 = valores.Select (v =>
                new Valor1(v.name, v.value))
                .ToList();

            Console.WriteLine(valores1[1].GetType());
            #endregion

        }
    }
}
