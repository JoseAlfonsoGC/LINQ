using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_08_Subquery
{
    class Program
    {
        static void Main(string[] args)
        {
            //SubQuery es un query que se encuentra dentro de una expresion lambda de otro query
            //el scope que tiene existe dentro de la expresion que lo contiene 

            string[] postres = { "Pay de manzana", "Pastel de chocolate", "Manzana caramelizada", "Fresas con crema" };
            //Ejemplo 01 Subquery se tiene que ordenar alfabeticamente de acuerdo a la ultima palabra de cada elemento
            //
            //paso uno usar Split para dividir en una coleccion a la cadena ["Pay", "de", "manzana"...]
            //paso dos seleccionar la ultima palabra [pSplit().Last()] este es el subquery
            //hasta que no se termine de ejecutar el subquery no se puede proseguir con el query
            //el orden de los datos se obtiene del query principal [....postres.OrderBy....]

            IEnumerable<string> resultados = postres.OrderBy(p => p.Split().Last());

            //mostramos los resultados
            foreach (string postre in resultados)
            {
                Console.WriteLine(postre);
            }
            Console.WriteLine("---------ejemplo 2----------");

            int[] numeros = { 19, 14, 56, 32, 11, 8, 45, 7, 18, 2, 17, 23 };

            IEnumerable<int> nums = numeros
                .Where(n => n < numeros.First());

            foreach (int n in nums)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("----------ejemplo 3-----------");
            //numeros que sean menores o iguales al primer entero que se encuentre
            IEnumerable<int> nums2 = numeros
                .Where(n => n <= (numeros.Where(n2 => n2 % 2 == 0)).First());

            foreach (int n in nums)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
}
