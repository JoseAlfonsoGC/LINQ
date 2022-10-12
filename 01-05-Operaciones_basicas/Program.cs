using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_05_Operaciones_basicas
{
    class Program
    {
        static void Main(string[] args)
        {
            //operaciones basicas que podenos realizar coin LINQ

            //creamos la lista
            List<CEstudiante> estud = new List<CEstudiante>
            {
                new CEstudiante("Ana","A100","Mercadotecnia",10.0),
                new CEstudiante("Luis","S250","Orientado a objetos",9.0),
                new CEstudiante("Juan","S875","Programacion basica",5.0),
                new CEstudiante("Susana","A432","Mercadotecnia",8.7),
                new CEstudiante("Pablo","A156","Mercadotecnia",4.3),
                new CEstudiante("Alberto","S456","Orientado a objetos",8.3)
            };
            //conteo
            int cantidad = (from e in estud
                            where e.Promedio > 5
                            select e).Count();
            Console.WriteLine("Cantidad de aprobados es {0}", cantidad);
            Console.WriteLine("--------------------------------");

            //reversa
            //imprimir en orden
            var aprobados = from e in estud
                            where e.Promedio > 5
                            select e;
            foreach (CEstudiante est in aprobados)
            {
                Console.WriteLine(est);
            }
            Console.WriteLine("----------------");

            Console.WriteLine("Orden inversa");
            //imprimir orden inversa
            foreach (CEstudiante est in aprobados.Reverse())
            {
                Console.WriteLine(est);
            }
            Console.WriteLine("----------------");
            //ordenamiento
            Console.WriteLine("ordenamiento");
            var ordenados = from e in estud
                            orderby e.Promedio descending
                            select e;
            foreach (CEstudiante est in ordenados)
            {
                Console.WriteLine(est);
            }
            Console.WriteLine("----------------");

            Console.WriteLine("Ascendente");

            var ordenadosA = from e in estud
                             orderby e.Promedio ascending
                             select e;
            foreach (CEstudiante est in ordenadosA)
                Console.WriteLine(est);


            //operacion de agregacion

            int[] numeros = { 2, 5, 3, 9, 1, 6, 4, 7, 8 };

            Console.WriteLine("-------");

            //maximo
            int maximo = (from n in numeros select n).Max();
            Console.WriteLine("El maximo es {0}", maximo);

            //minimo
            int minimo = (from n in numeros select n).Min();
            Console.WriteLine("El minimo es {0}", minimo);

            //Promedio
            double prom = (from n in numeros select n).Average();
            Console.WriteLine("El promedio es {0}", prom);

            //sumatoria
            int sumatoria = (from n in numeros select n).Sum();
            Console.WriteLine("la sumatoria es {0}", sumatoria);
            Console.ReadKey();
        }
    }
}
