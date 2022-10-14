using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02_05_Elementos_XML_III
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
            //otra forma de crear un elemento, el parent es escuela
            escuela.SetElementValue("Deportes", "No hay");
            Console.WriteLine(escuela);
            //si ya existe se actualiza
            escuela.SetElementValue("Deportes", "Sin presupuesto");
            Console.WriteLine(escuela);
            Console.WriteLine("------------------------------------");

            //adicionar despues de un elemento, el primer nodo es el punto de referencia 
            escuela.FirstNode.AddAfterSelf(new XElement("Asignaturas"));
            Console.WriteLine(escuela);
            //ahora adicionamos un elemento antes de ese
            escuela.FirstNode.AddBeforeSelf(new XElement("EscuelaLibre"));
            Console.WriteLine(escuela);

            Console.WriteLine("------------------------------------");
            //obten a matematicas 
            var mate = escuela.Element("Ciencias").Element("Materia");
            //se le da un valor
            //mate.SetValue("Geometria no Euclidiana");
            Console.WriteLine(escuela);

            //obtenemos el valor de ese elemento
            //string valorMate = mate.Value;
            //Console.WriteLine(valorMate);

            Console.WriteLine("-----------------Cargar archivo xml-------------------");
            /*
             <?xml version="1.0" encoding="utf-8"?>
<Personas>
<Alumnos>
	<Alumno Nombre="Jose">
	<Curso>Programacion</Curso>
	<Calificacion>8</Calificacion>
	</Alumno>
	<Alumno Nombre="Susana">
	<Curso>UML</Curso>
	<Calificacion>9</Calificacion>
	</Alumno>
	<Alumno Nombre="Maria">
	<Curso>Orientado a objetos</Curso>
	<Calificacion>10</Calificacion>
	</Alumno>
	<Alumno Nombre="Luis">
	<Curso>UML</Curso>
	<Calificacion>10</Calificacion>
	</Alumno>
</Alumnos>
<Maestros>
	<Maestro Nombre="Juan">
	<Curso>Programacion</Curso>
	<Horario>Completo</Horario>
	</Maestro>
	<Maestro Nombre="Denis">
	<Curso>UML</Curso>
	<Horario>Completo</Horario>
	</Maestro>
	<Maestro Nombre="Sofia">
	<Curso>Orientado a objetos</Curso>
	<Horario>Completo</Horario>
	</Maestro>
	<Maestro Nombre="Carlos">
	<Curso>Base de datos</Curso>
	<Horario>Medio</Horario>
	</Maestro>
</Maestros>
</Personas>
             
             */
            XDocument alumnos = XDocument.Load("alumnos.xml");
            Console.WriteLine(alumnos);

            Console.WriteLine("-----------------------------------------------------");

            //eliminar a los Maestros
            alumnos.Descendants("Maestros").Remove();
            Console.WriteLine(alumnos);
            Console.WriteLine("-------------------");

            //eliminar las calificaciones
            alumnos.Descendants("Calificacion").Remove();
            Console.WriteLine(alumnos);
            Console.WriteLine("------------");

            //obtener las calificaciones 
            var califs = from a in alumnos.Descendants("Calificacion")
                         select a.Value;

            foreach (var calif in califs)
                Console.WriteLine(calif);

            Console.ReadKey();

        }
    }
}
