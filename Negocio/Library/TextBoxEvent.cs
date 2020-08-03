using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Library
{
    public class TextBoxEvent
    {
        //Método que solo permite ingresar valores alfabéticos
        public void textKeyPress(KeyPressEventArgs kpea)
        {
            //Condicion para campo alfabetico
            if (char.IsLetter(kpea.KeyChar)){kpea.Handled = false;}
            //No permite dar salto de línea con ENTER
            else if (kpea.KeyChar == Convert.ToChar(Keys.Enter)) {kpea.Handled = true;}
            //Se puede usar backspace
            else if (char.IsControl(kpea.KeyChar)) { kpea.Handled = false; }
            //Se puede usar espacio
            else if (char.IsSeparator(kpea.KeyChar)) { kpea.Handled = false; }
            else { kpea.Handled = true; }
        }

        //Método que solo permite ingresar valores numéricos
        public void textKeyPressNum(KeyPressEventArgs kpea)
        {
            //Condicion para campo alfabetico
            if (char.IsDigit(kpea.KeyChar)) { kpea.Handled = false; }
            //No permite dar salto de línea con ENTER
            else if (kpea.KeyChar == Convert.ToChar(Keys.Enter)) { kpea.Handled = true; }
            //Se puede usar backspace
            else if (char.IsControl(kpea.KeyChar)) { kpea.Handled = false; }
            //Se puede usar espacio
            else if (char.IsSeparator(kpea.KeyChar)) { kpea.Handled = true; }
            else { kpea.Handled = true; }
        }

        //Método que comprueba que el email sea válido
        public bool comprobarFormatoEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
