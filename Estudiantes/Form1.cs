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
        private LEstudiante _E = new LEstudiante();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBoxImagen_Click(object sender, EventArgs e)
        {
            _E.CargarImagen(pictureBoxImagen);
        }
    }
}
