using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_11_Operadores_por_categoria
{
    class CEstudiante
    {
        private string nombre;
        private int id;

        public CEstudiante(string nombre, int pID)
        {
            this.nombre = nombre;
            this.id = pID;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return string.Format("Estudiante {0}, {1}", nombre, id);
        }
    }

    class CCurso
    {
        private string curso;
        private int id;

        public CCurso(string opCurso, int opPid)
        {
            curso = opCurso;
            id = opPid;
        }

        public string Curso { get => curso; set => curso = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return string.Format("Curso => {0}", curso);
        }
    }
}
