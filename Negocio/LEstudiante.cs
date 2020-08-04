using Data;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SPEngineCSharp;
using System;

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

        private void validacionRegistrar()
        {
            //Se hace un recorrido por los tres campos y se comprueba que no sean vacíos
            for (int i = 1; i < listTextBox.Count - 1; i++)
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

        public Boolean Registrar()
        {
            //*******Validación de campos*******
            validacionRegistrar();
            //*******REGISTRO DE DATOS*******
            using (IDbConnection _c = Conexion.conn())
            {
                List<Parameter> _Lista = new List<Parameter>();
                _Lista.Add(new Parameter("@Nombre", listTextBox[1].Text));
                _Lista.Add(new Parameter("@Apellido", listTextBox[2].Text));
                _Lista.Add(new Parameter("@Email", listTextBox[3].Text));
                return Conexion.EjecutarSP("sp_INSERT_ALUMNO", _Lista);
            }
        }

        public Boolean Actualizar()
        {
            using (IDbConnection _c = Conexion.conn())
            {
                List<Parameter> _Lista = new List<Parameter>();
                _Lista.Add(new Parameter("@Id", listTextBox[0].Text));
                _Lista.Add(new Parameter("@Nombre", listTextBox[1].Text));
                _Lista.Add(new Parameter("@Apellido", listTextBox[2].Text));
                _Lista.Add(new Parameter("@Email", listTextBox[3].Text));
                return Conexion.EjecutarSP("sp_UPDATE_ALUMNO", _Lista);
            }
        }

        public Boolean Eliminar()
        {
            using (IDbConnection _c = Conexion.conn())
            {
                List<Parameter> _Lista = new List<Parameter>();
                _Lista.Add(new Parameter("@Id", listTextBox[0].Text));
                return Conexion.EjecutarSP("sp_DELETE_ALUMNO", _Lista);
            }
        }

        public DataTable ListadoAlumnos()
        {
            using (IDbConnection _c = Conexion.conn())
            {
                return Conexion.Listado("sp_SELECT_ALUMNOS",null);
            }
        }

        //Método para listar con parámetro
        public DataTable ListadoEspecial()
        {
            using (IDbConnection _c = Conexion.conn())
            {
                List<Parameter> _Lista = new List<Parameter>();
                _Lista.Add(new Parameter("@dominio","hotmail"));
                return Conexion.Listado("sp_SELECT_ALUMNOS_DOMINIO_EMAIL", _Lista);
            }
        }

    }
}
