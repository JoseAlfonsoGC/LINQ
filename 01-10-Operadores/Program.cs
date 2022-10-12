using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_10_Operadores
{
    class Program
    {
        static void Main(string[] args)
        {
            //Operadores Take | Skipe | Reverse | First | Last | ElementAt |  Any | Problemas con cambio de valores 

            int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

            //EJEMPLO Take
            IEnumerable<int> desdeInicio = numeros.Take(5);//selecciona 5 elelmentos (n)

            Console.WriteLine("Numeros seleccionados");
            foreach (int n in desdeInicio)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("-----------------");
            //Ejemplo Skipe se salta los registros que sean necesarios
            IEnumerable<int> brinco = numeros.Skip(5);

            Console.WriteLine("");
            foreach (int n in brinco)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("-----------------");
            //Ejemplo Reverse
            IEnumerable<int> reversa = numeros.Reverse();

            Console.WriteLine("");
            foreach (int n in reversa)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("-----------------");
            //Ejemplo First el primer registro de la coleccion

            Console.WriteLine("");
            Console.WriteLine(numeros.First());

            Console.WriteLine("-----------------");
            //Ejemplo Last ultimo registro del la coleccion

            Console.WriteLine(numeros.Last());
            //ElemetAt encontrar un registro en especifico 
            Console.WriteLine("En el indice 3 esta {0}", numeros.ElementAt(3));

            //Contains si la coleccion contiene determinado elemento, retorna un false o true 
            Console.WriteLine("Contiene a 15 - {0}", numeros.Contains(15));

            //Any si existen elementos en la coleccion retorna true o false
            Console.WriteLine("Tiene elementos - {0}", numeros.Any());

            //Any tambien puede ser utilizado para saber Si hay multiplos de 5 
            Console.WriteLine("Hay multiplos de 5 - {0}", numeros.Any(n => n % 5 == 0));
            Console.WriteLine("-------------------------");

            //cuidado con el cambio de valor entre la ejecucion de los query
            int valor = 2;

            IEnumerable<int>resultados = numeros.Where(n => n % valor == 0);

            valor = 3; //el query se ejecuta cuando se cambia el valor de variable de trabajo

            foreach (int n in resultados)
                Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}
