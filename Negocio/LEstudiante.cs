using Data;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SPEngineCSharp;

namespace Negocio
{
    public class LEstudiante : Libreria
    {
        private List<TextBox> listTextBox;
        private List<Label> listLabel;
        private PictureBox image;

        //Constructores vacíos
        public LEstudiante()
        {

        }
        //Constructor que recibe parámetros
        public LEstudiante(List<TextBox> listTextBox, List<Label> listLabel, object[] objetos)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
            image = (PictureBox)objetos[0];
        }

        
        public void Registrar()
        {
            //Se hace un recorrido por los tres campos y se comprueba que no sean vacíos
            for (int i = 0; i < listTextBox.Count-1; i++)
            {
                if (listTextBox[i].Text.Equals(""))
                {
                    listLabel[i].Text = "El campo es requerido";
                    listLabel[i].ForeColor = Color.Red;
                }
            }
            //Se comprueba que el email sea valido, si no lo es se ejecuta
            if (!textBoxEvent.comprobarFormatoEmail(listTextBox[3].Text))
            {
                listLabel[3].Text = "El email no es válido";
                listLabel[3].ForeColor = Color.Red;
            }
            //Si es válido...
            else
            {
                //Variable que guarda el valor en un arreglo de Bytes de la imagen
                var imageArray = uploadImage.ImageToByte(image.Image);
            }
        }

        public DataTable ListadoAlumnos()
        {
            using (IDbConnection _c = Conexion.conn())
            {
                return Conexion.Listado("sp_SELECT_ALUMNOS",null);
            }
        }

    }
}
