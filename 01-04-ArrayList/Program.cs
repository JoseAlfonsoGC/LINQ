using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            //tips para el uso de ArrayList con Linq por medio del ofType<>

            //seleccionamos objetos de un tipo en particular que esten en un arrayList

            //ejemplo 01
            ArrayList lista = new ArrayList();
            lista.AddRange(new object[] { "hola", 5, 6.7, false, 4, 2, "saludos", 3.5, 3 });

            //obtenemos solo los enteros
            var enteros = lista.OfType<int>();

            foreach (int n in enteros)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("----------------------");

            //ejemplo 02
            //creamos un arrayList
            ArrayList estudiantes = new ArrayList()
            {
                new Cestudiante("Ana","A100","Mercadotecnia",100.0),
                new Cestudiante("Luis","S250","Orientado a objetos",9.0),
                new Cestudiante("Juan","S875","Programacion basica",5.0),
                new Cestudiante("Susana","A432","Mercadotecnia",8.7),
                new Cestudiante("Pablo","A156","Mercadotecnia",4.3),
                new Cestudiante("Alberto","S456","Orientado a objetos",8.3)
            };
            //Tenemos que transformar el ArrayLIst a un tipo que implementea 
            //IEnuemrable<T> para poder ser usado con LINQ
            var estL = estudiantes.OfType<Cestudiante>();

            //ahora si podemos usar linq en el arrayList
            //encuentra los reprobados
            var reprobados = from e in estL
                             where e.Promedio <= 5.0
                             select e;
            Console.WriteLine("Reprobados");
            foreach (Cestudiante e in reprobados)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("------------------------");

            //proyeccion por medio de tipos anonimos 
            List<Cestudiante> estud = new List<Cestudiante>
            {
                new Cestudiante("Ana","A100","Mercadotecnia",100.0),
                new Cestudiante("Luis","S250","Orientado a objetos",9.0),
                new Cestudiante("Juan","S875","Programacion basica",5.0),
                new Cestudiante("Susana","A432","Mercadotecnia",8.7),
                new Cestudiante("Pablo","A156","Mercadotecnia",4.3),
                new Cestudiante("Alberto","S456","Orientado a objetos",8.3)
            };
            var nombrePromedio = from e in estud
                                 select new { e.Nombre, e.Promedio };//solo la informacion que se ocupa

            foreach (var no in nombrePromedio)
            {
                Console.WriteLine(no.ToString());
            }
            Console.ReadKey();
        }
    }
}
