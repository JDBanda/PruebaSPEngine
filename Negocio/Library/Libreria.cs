using Negocio.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    //Clase que emula una herencia multiple
    public class Libreria
    {
        public UploadImage uploadImage = new UploadImage();
        public TextBoxEvent textBoxEvent = new TextBoxEvent();
    }
}
