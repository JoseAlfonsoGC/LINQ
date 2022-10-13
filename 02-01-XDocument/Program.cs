using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02_01_XDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            //documento de xml mas completo

            XDocument documento = new XDocument(
                new XDeclaration("1.0","utf-8","yes"),//declaracion del documento
                new XComment("Listado de alumnos"),//con eso se coloca un comentario
                new XProcessingInstruction("xml-stylesheet","href='MyStyles.css' title='Compact' type='text/css'"),
                new XElement("Alumnos", // lleva namespace {https://github.com/JoseAlfonsoGC}
                    new XElement("Ana", new XAttribute("ID", "10100"),
                        new XElement("Curso", "Administracion"),
                        new XElement("Promedio", "10")
                ),//FIN DE ANA
                new XElement("Luis", new XAttribute("ID","25350"),
                        new XElement("Curso","Programacion"),
                        new XElement("Promedio","9.5")
                        )//final de luis
                )//final de alumnos
                );//fin del documento

            Console.WriteLine(documento);

            documento.Save("Alumnos.xml");
            Console.ReadKey();
           
        }
    }
}
