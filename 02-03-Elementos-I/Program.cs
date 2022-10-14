using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace _02_03_Elementos_I
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new XElement("Escuela",
                                        new XElement("Ciencias",
                                            new XElement("Materia", "Matematicas"),
                                            new XElement("Materia", "fisica")
                                            ),
                                        new XElement("Artes",
                                            new XElement("Materia", "Historia del arte"),
                                            new XElement("Practica", "Pintura")
                                            )
                                        );
            Console.WriteLine(escuela);
            Console.WriteLine("--------------------------------------");

            // Nodes regresa a los hijos
            foreach (XNode nodo in escuela.Nodes())
                Console.WriteLine(nodo.ToString());

            Console.WriteLine("--------------------------------------");

            // Elements regresa los hijos de los nodos de tipo XElement
            foreach (XElement elemento in escuela.Elements())
                Console.WriteLine(elemento.Name + "=" + elemento.Value);

            Console.WriteLine("--------------------------------------");
            //FirstNode nos regresa el primer nodo
            Console.WriteLine(escuela.FirstNode);

            //el padre del primer nodo
            Console.WriteLine(escuela.FirstNode.Parent.Name);
            Console.WriteLine("--------------------------------------");

            //LastNode nos regresa el ultimo nodo
            Console.WriteLine(escuela.LastNode);

            Console.WriteLine("--------------------------------------");

            //LastNode nos regresa el ultimo nodo
            Console.WriteLine(escuela.LastNode);
            Console.ReadKey();
        }
    }
}
