using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_01_Modos_diferido_e_inmediato
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Ejecuciones en Linq
            -uso de tipos implícitos
            -Ejecución diferida
            -Ejecución inmediata
             */
            //*********************Ejemplo *****************
            int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };
            int[] arreglo = { 1, 5, 7, 3, 6, 9, 8 };

            //hacemos el query y usamos un tipo implicito por medio de var
            var query = from n in numeros
                        where n % 2 == 0 //valores pares divisibles /2
                        select n;
            foreach (int num in query)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("------Ejecucion diferida");
            //si aumenta un valor en el arreglo aundespues del [var query] lo tomara en cuenta
            //se evalua elquery cuando iteramos en el arreglo 
            numeros[1] = 12;
            //mostrar resultados
            foreach (int num in query)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------");
            Console.WriteLine("--------Ejecucion inmediata");
            //**************se ejecuta el query en el momento exacto**************
            //guardamos los resultados como un arreglo
            int[] arrayValores = (from n in numeros where n % 2 == 0 select n).ToArray<int>();

            //guardar los resultados como un list
            List<int> listaValores = (from n in numeros where n % 2 == 0 select n).ToList();

            //mostrar
            Console.WriteLine("El arreglo");

            //mostrar resultados
            foreach (int num in arrayValores)
            {
                Console.WriteLine(num);
            }

            numeros[0] = 28;
            Console.WriteLine("------- se actualiza despues de la modificacion?");
            foreach (int num in arrayValores)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("La lista");
            foreach (int num in listaValores)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-----------");
            //como podemos ver no se actualiza
            Console.ReadKey();
        }
    }
}
