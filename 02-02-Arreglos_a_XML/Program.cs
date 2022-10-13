using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace _02_02_Arreglos_a_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crea un xml a partir de un arreglo
            //funicona con otros contenedores

            //en este ejemplo 01 se usa tipos anonimos pero funciona con clases normales tambien
            var listado = new[]
            {
                new {Nombre="Jose", Calif=8, Curso="Programacion"},
                new {Nombre="Susana", Calif=8, Curso="UML"},
                new {Nombre="Maria", Calif=8, Curso="Orientado a objetos"},
                new {Nombre="Luis", Calif=8, Curso="UML"},
            };
            //Ahora xml
            XElement alumno = new XElement("Alumno",// este es la raiz
                from a in listado
                select new XElement("Alumno", new XAttribute("Nombre", a.Nombre),
                        new XElement("Curso", a.Curso),
                        new XElement("Calificacion", a.Calif)
                        )//fin de alumno
                );//fin alumnos
            Console.WriteLine(alumno);

            alumno.Save("Alumnos.xml");

            Console.WriteLine("------------------------");
            //Ejemplo 02 obtener informacion xml a partir de una cadena

            string alumnos = @"<Alumnos>
<Alumno Nombre='Jose'>
    <Curso> Programacion </Curso>
    <Calificacion> 8 </Calificacion>
</Alumno>
<Alumno Nombre = 'Susana'>
    <Curso> UML </Curso>
    <Calificacion> 8 </Calificacion>
</Alumno>
    <Alumno Nombre ='Maria'>
    <Curso > Orientado a objetos</Curso>
    <Calificacion> 8 </Calificacion>
</Alumno>
<Alumno Nombre = 'Luis'>
    <Curso> UML </ Curso>
    <Calificacion> 8 </ Calificacion>
</Alumno>
</Alumnos>";

            XElement alumnosx = XElement.Parse(alumnos);//pasamos la cadena para que haga parse

            Console.WriteLine(alumnosx);
            Console.ReadKey(); 
        }
    }
}
