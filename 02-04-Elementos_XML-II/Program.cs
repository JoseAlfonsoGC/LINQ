using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02_04_Elementos_XML_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new XElement("Escuela",
                                        new XElement("Ciencias",
                                            new XElement("Materias", "Matematicas"),
                                            new XElement("Materias", "Fisica")
                                            ),
                                        new XElement("Artes",
                                            new XElement("Materias", "Historia del arte"),
                                            new XElement("Practica", "Pintura")
                                            )
                                        );
            Console.WriteLine("-------------------------------------------");

            //obtener todos los elementos del curso donde se encuentre Fisica
            IEnumerable<string> materias = from curso in escuela.Elements()
                                           where curso.Elements().Any(materia => materia.Value == "Fisica")
                                           select curso.Value;
            foreach (string s in materias)
                Console.WriteLine(s);

            Console.WriteLine("-------------------------------------------");

            //obtener el nombre del elemento padre de fisica
            IEnumerable<XName> tipoCurso = from curso in escuela.Elements()
                                           where curso.Elements().Any(materia => materia.Value == "Fisica")
                                           select curso.Name;

            foreach (XName s in tipoCurso)
                Console.WriteLine(s.ToString());

            Console.WriteLine("-------------------------------------------");

            //Solamente selecciona los nodos materia
            IEnumerable<string> materias2 = from curso in escuela.Elements()
                                           from asignatura in curso.Elements()
                                           where asignatura.Name=="Materias"
                                           select asignatura.Value;

            foreach (string m in materias2)
                Console.WriteLine(m);

            Console.WriteLine("-------------------------------------------");

            //contar los elementos de un tipo en particular
            int n = escuela.Elements("Ciencias").Count();

            Console.WriteLine("Hay {0} Ciencias", n);

            Console.WriteLine("-------------------------------------------");

            //Element nos da la primera ocurrencia de un elemento con ese nombre
            string mat = escuela.Element("Ciencias").Element("Materia").Value;

            Console.WriteLine(mat);

            Console.WriteLine("------------------------------------------");

            //obtenemos el siguiente nodo, estilo lista ligada (recorre nodo a nodo y despues sus elementos)

            XNode s1 = escuela.FirstNode;
            Console.WriteLine(s1);
            Console.WriteLine("----Tomamos el siguiente----");
            s1 = s1.NextNode;
            Console.WriteLine(s1);

            Console.WriteLine("--------------------------------------------");

            Console.ReadKey();
        }
    }
}
