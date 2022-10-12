using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_05_Operaciones_basicas
{
    class CEstudiante
    {
        private string nombre;
        private string id;
        private string curso;
        private double promedio;

        public string Nombre { get { return nombre; } }
        public string ID { get { return id; } }
        public string Curso { get { return curso; } }
        public double Promedio { get { return promedio; } }
        public CEstudiante(string nombre, string id, string curso, double promedio)
        {
            this.nombre = nombre;
            this.id = id;
            this.curso = curso;
            this.promedio = promedio;
        }
        public override string ToString()
        {
            return string.Format("Nombre: {0}, {1}, curso: {2}, promedio {3}", nombre, id, curso, promedio);
        }
    }
}
