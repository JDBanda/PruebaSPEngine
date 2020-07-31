using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Library
{
    public class UploadImage
    {
        private OpenFileDialog fd = new OpenFileDialog();
        public void CargarImagen(PictureBox pictureBox)
        {
            //Propiedad que establece la carga de la imagen de manera sincrona
            pictureBox.WaitOnLoad = true;
            //Hacer un filtro que solo agarre imagenes (creo es una expresion regular)
            fd.Filter = "Imagenes|*.jpg;*.gif;*.png;*,png";
            fd.ShowDialog();
            if (fd.FileName != string.Empty)
            {
                pictureBox.ImageLocation = fd.FileName;

            }
        }

        //Convertir la imagen a un arreglo de Bytes
        public byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
