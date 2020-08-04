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
        private int caso=0;
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

            actualizarGRIDS();
        }

        private void actualizarGRIDS()
        {
            //Listar elementos
            DGVPrueba.DataSource = _E.ListadoAlumnos();
            //Lista especial
            DGVListaEspecial.DataSource = _E.ListadoEspecial();
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
            switch (caso)
            {
                case 0:
                    MessageBox.Show(_E.Registrar() == true ? "Registro CORRECTO!"
                : "Es necesario implementar una lista de parámetros válida.\nLa consulta no surtío efecto");
                    actualizarGRIDS();
                    break;
                case 1:
                    MessageBox.Show(_E.Actualizar() == true ? "Registro ACTUALIZADO!"
                : "Es necesario implementar una lista de parámetros válida.\nLa consulta no surtío efecto");
                    actualizarGRIDS();
                    break;
                case 2:
                    MessageBox.Show(_E.Eliminar() == true ? "Registro ELIMINADO!"
                : "Es necesario implementar una lista de parámetros válida.\nLa consulta no surtío efecto");
                    actualizarGRIDS();
                    break;
                default:
                    MessageBox.Show("XD");
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            textBoxNId.Text = "";
            textBoxNombres.Text = "";
            textBoxApellido.Text = "";
            textBoxEmail.Text = "";
            buttonEliminar.Enabled = true;
            buttonActualizar.Enabled = true;
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas actualizar un elemento de la tabla?",
                "Actualizar tabla", MessageBoxButtons.YesNo) == DialogResult.Yes){
                textBoxNId.Enabled = true;
                caso = 1;
                buttonEliminar.Enabled = false;
                buttonActualizar.Enabled = false;
            }
            else
            {
                textBoxNId.Enabled = false;
                caso = 0;
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas actualizar un elemento?",
                "Pagar factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                textBoxNId.Enabled = true;
                caso = 2;
                buttonEliminar.Enabled = false;
                buttonActualizar.Enabled = false;
            }
            else
            {
                textBoxNId.Enabled = false;
                caso = 0;
            }
        }
    }
}
