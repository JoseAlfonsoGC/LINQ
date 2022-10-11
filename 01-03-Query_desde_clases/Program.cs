using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_03_Query_desde_clases
{
    class Program
    {
        static void Main(string[] args)
        {
            //uso de linq con clases

            //creamos una lista y los enviamos a los get de Cestudiante
            List<Cestudiante> estudiantes = new List<Cestudiante>
            {
                new Cestudiante("Ana","A100","Mercadotecnia",100.0),
                new Cestudiante("Luis","S250","Orientado a objetos",9.0),
                new Cestudiante("Juan","S875","Programacion basica",5.0),
                new Cestudiante("Susana","A432","Mercadotecnia",8.7),
                new Cestudiante("Pablo","A156","Mercadotecnia",4.3),
                new Cestudiante("Alberto","S456","Orientado a objetos",8.3)
            };

            //encontramos a los reprobados
            var reprobados = from e in estudiantes
                             where e.Promedio <= 5.0 //trabajar con una propiedad
                             select e;
            //mostramos
            Console.WriteLine("Reprobados");
            foreach (Cestudiante rep in reprobados)
            {
                Console.WriteLine(rep);
            }
            Console.WriteLine("--------");
            //mostramos solo un atributo de los encontrados por medio de la propiedad
            Console.WriteLine("Solo un atributo");
            foreach (Cestudiante rep in reprobados)
            {
                Console.WriteLine(rep.Nombre);//solo se imprime el nombre de los seleccionados
            }
            Console.WriteLine("-------------");
            //encontramos solo los nombres de los de mercadotecnia
            var mercadotecnia = from e in estudiantes
                                where e.Curso == "Mercadotecnia"
                                select e.Nombre;

            Console.WriteLine("Nombres de mercadotecnia");
            foreach (string n in mercadotecnia)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
}
