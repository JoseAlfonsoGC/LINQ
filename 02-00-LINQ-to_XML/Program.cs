using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace _02_00_LINQ_to_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Framework provee System.Xml.dll y XmlReader, XmlWriter
            //pero es mas sencillo trabajar con LINQ para XML

            //cada parte de xml: declaracion, elemento, atributos. puede representarse por clases
            //si estas clases tienen colecciones, entonces podemos representar arbol que 
            //describa al documento xml, esa es la base de DOM (Document Object Model)

            //LINQ para xml tiene un DOM conocido como X-DOM y operadores extra
            //XObject       - clase abstracta que es la base para todo el contenido de XML
            //XNode         - clase base para la mayoria del contenido XML, excepto atributos 
            //XContainer    - Define miembros para trabajar con sus hijos y es la clase padre de XElement y XDocument
            //XElement      - define a un elemento
            //XDocument     - Representa la raiz de un arbol XML, en realidad envuelve a un XElement que actua como raiz
            //                  y lo podemos usar para adicion la declaracion e intrucciones de procesamiento.
            //                  se puede usar X-DOM sin tener un XDocument.

            /*LINQ para XML
             X-DOM
             XElement
             Creación de un documento
             Construcción funcional
             Salvar a disco el documento
             */

            //ejemplo 01 creamos un documento sencillo de XML con LINQ

            XElement raiz = new XElement("raiz");
            XElement el1 = new XElement("Elemento1");
            el1.Add(new XAttribute("atributo","valor"));
            el1.Add(new XElement("Anidado","Contenido"));

            raiz.Add(el1);
            Console.WriteLine(raiz);
            
            Console.WriteLine("-----------construccion funcional-------------");

            //ejemplo 02 esta forma de crear el documento se conoce como construccion funcional

            XElement documento= new XElement("Alumnos",
                new XElement("Ana", new XAttribute("ID","10100"),
                    new XElement("Curso", "Administracion"),
                    new XElement("Promedio","10")
                    ),//fin de Ana
                new XElement("Luis", new XAttribute("ID", "25350"),
                    new XElement("Curso","Promedio"),
                    new XElement("Promedio","9.5")
                    )//fin de luis
                );//fin de alumnos

            //imprimimos el documento
            Console.WriteLine(documento);
            //escribimos el documento a disco
            documento.Save("Alumnos.xml");
            Console.ReadKey(); 
        }
    }
}
