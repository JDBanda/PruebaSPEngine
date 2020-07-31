using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudiantes
{
    public partial class Form1 : Form
    {
        private LEstudiante _E;
        public Form1()
        {
            InitializeComponent();
            var listTextBox = new List<TextBox>();
            listTextBox.Add(textBoxNId);
            listTextBox.Add(textBoxNombres);
            listTextBox.Add(textBoxApellido);
            listTextBox.Add(textBoxEmail);
            var listLabel = new List<Label>();
            listLabel.Add(labelNid);
            listLabel.Add(labelNombre);
            listLabel.Add(labelApellido);
            listLabel.Add(labelEmail);
            Object[] objetos = { pictureBoxImagen };

            _E = new LEstudiante(listTextBox, listLabel, objetos);

            //Listar elementos
            DGVPrueba.DataSource = _E.ListadoAlumnos();
        }

        private void pictureBoxImagen_Click(object sender, EventArgs e)
        {
            //Llaada al método que carga la imagen
            _E.uploadImage.CargarImagen(pictureBoxImagen);
        }

        //Cambia el color de la etiqueta si el texto esta vacio
        private void CambiarLabel(TextBox t, Label l, string tex)
        {
            if (t.Text.Equals(""))
            {
                //l.ForeColor = Color.Red;
            }
            else
            {
                l.ForeColor = Color.Green;
                l.Text = tex;
            }
        }

        private void textBoxNId_TextChanged(object sender, EventArgs e)
        {
            //Invocar el método local
            CambiarLabel(textBoxNId, labelNid, "No. Id");
        }

        private void textBoxNId_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamada al método que verifica que solo sean caracteres
            _E.textBoxEvent.textKeyPressNum(e);
        }

        private void textBoxNombres_TextChanged(object sender, EventArgs e)
        {
            CambiarLabel(textBoxNombres, labelNombre, "Nombre");
        }

        private void textBoxNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            _E.textBoxEvent.textKeyPress(e);
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            CambiarLabel(textBoxApellido, labelApellido, "Apellido");
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            _E.textBoxEvent.textKeyPress(e);
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            CambiarLabel(textBoxEmail, labelEmail, "Email");
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            _E.Registrar();
        }
    }
}
