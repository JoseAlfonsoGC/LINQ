using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_00_LINQ_to_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Intro linq*/
            //Language Integrated Query
            //Se introdujo en .Net 3.5

            //es una forma concisa, simetrica y fuertemente tipificada de acceder a datos

            //Requisitos
            //C#, POO
            //Tipo implicito, collecciones, expresiones lambda, metodos de extension, tipo anonimos

            //Se crean expreciones de query, parecidas a SQL,´pero no es SQL
            //la expresion puede interactuar con multiples tipos de datos, no solo con base de datos

            //en los siguentes ejemplos se explicara la forma en que se trabaja con linq en[ 
            //LINQ to objects-> se usa para arreglos y colecciones
            //LINQ to XML-> para manipular y hacer queries a documentos XML
            //]
            //LINQ to DataSet-> se usa con objetos DataSet de ADO.NET 
            //LINQ to Entityes-> para queries con el API deEntity Framework de ADO.NET
            //Paralle1 LINQ-> para el procesamiento en paralelo de los datos que regresa un query

            //Las expresiones de LINQ son fuertemente tipificadas 

            //en esta seccion 01-nn-LINQ se vera linq a objetos
            //LINQ to objects-> se usa para arreglos y colecciones 
            //en los siguientes ejemplos se vera queries sencillos con arreglos y reflexion

            //*****************ejemplo 01 Crea un arreglo con el cual trabajar
            int[] numeros = { 1, 5, 7, 3, 5, 9, 8 };

            //crea el query
            IEnumerable<int> valores = from n in numeros
                                       where n > 3 && n < 8
                                       select n;
            //mostrar los resultados
            foreach (int num in valores)
            {
                Console.WriteLine(num);

            }
            Console.WriteLine("----------");

            //*******************Ejemplo 02 con cadenas*****************
            string[] postres = { "Pay de manzana", "Pastel de chocolate", "Manzana caramelizada", "Fresas con crema" };

            //query
            IEnumerable<string> encontrados = from p in postres // explicacion del foreach
                                              where p.Contains("manzana")//cadenas que contienen manzana
                                              orderby p //dar orden a la lista de cadenas que contienen manzana
                                              select p; //seleccionar y guardar en encontrados
            foreach (string postre in encontrados)
            {
                Console.WriteLine(postre);
            }
            Console.WriteLine("----------");

            //Hacemos reflexion
            Console.WriteLine("------reflexion------");

            InformacionResultados(valores);
            Console.WriteLine("------------");
            InformacionResultados(encontrados);

            Console.ReadKey();
        }
        static void InformacionResultados(object pResultados)
        {
            Console.WriteLine("Tipo {0}", pResultados.GetType().Name);
            Console.WriteLine("Locacion {0}", pResultados.GetType().Assembly.GetName().Name);
        }
    }
}
