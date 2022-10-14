using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _02_06_LINQ_en_WindowsForms
{
    public partial class Form1 : Form
    {
        XDocument documento = new XDocument();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            documento = XDocument.Load("alumnos.xml");
            txtXml.Text = documento.ToString();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //crea un nuevo elemento
            XElement temp = new XElement("Alumno", new XAttribute("Nombre", txtNombre.Text),
                            new XElement("Curso", txtCurso.Text),
                            new XElement("Calificacion", txtCalificacion.Text)
                            );
            //lo adicionamos al documento
            documento.Descendants("Alumnos").First().Add(temp);

            //Actuializamos el textBox
            txtXml.Text = documento.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var resultado = from a in documento.Descendants("Alumno")
                            where (string)a.Element("Curso") == txtBusqueda.Text
                            select a.Element("Calificacion").Value + a.Element("Curso").Value;

            //contruye una cadena con la informacion
            string datos = "";
            foreach(var dato in resultado.Distinct())
            {
                datos += string.Format("Calificacion {0}\r\n", dato);
            }

            MessageBox.Show(datos);
        }
    }
}
