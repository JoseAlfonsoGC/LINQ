using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_07_Sintaxis_fluida
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hemos estado utilizando una sintaxis que llamamos query expression
            //Ahora veremos una sintaxis que se conoce como fluent sintax
            //Formalicemos algunos conceptos
            //Sequence es un objeto que implementa a IEnumerable<T>
            //Element es cada item en la secuencia
            //query operator es un metodo que transforma una secuencia, Acepta una secuencia de entrada y da como resultado una de salida
            //se tiene cerca de 40 operadores para LINQ, estos forman parte de los estandard query operators
            //el query es una expresion que cuando se enumera transforma a la secuencia usando los operadores

            //creamos un arreglo sobre el cual trabajar
            int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };

            //usamos expresion lambda como argumento, n es el argumento de entrada
            //query en sintaxis fluida
            IEnumerable<int> pares = numeros.Where(n => n % 2 == 0);//despues del '=' es lo que forma parte de la sintaxis fluida
            //muestra de los resultados
            foreach (int num in pares)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------------------ejemplo02");

            //arreglo sobre el cual trabajar
            string[] postres = { "Pay de manzana", "Pastel de chocolate", "Manzana caramelizada", "Fresas con crema" };

            IEnumerable<string> encontrados = postres.Where(p => p.Contains("manzana"));

            //mostrar resultados 
            foreach (string postre in postres)
            {
                Console.WriteLine(postre);
            }
            Console.WriteLine("--------------ejemplo 3 Enacdenamiento de operadores--------");
            //se van adicionando nuevos operadores

            IEnumerable<string> manzanas = postres
                .Where(p => p.Contains("Manzana"))
                .OrderBy(p => p.Length)
                .Select(p => p.ToUpper()); //el elemento es proyectado en Mayusculas

            foreach (string postre in manzanas)
            {
                Console.WriteLine(postre);
            }
            Console.ReadKey();
        }
    }
}
