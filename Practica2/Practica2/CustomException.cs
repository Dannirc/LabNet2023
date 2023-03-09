using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class CustomException: Exception
    {
        private string _mensajePersonalizado;

        public CustomException(string mensaje)
        {
            _mensajePersonalizado = mensaje;
        }

        public override string Message
        {
            get { 
                if (_mensajePersonalizado == null)
                {
                    return $"Hola, te informo que {base.Message}";
                } 
                else
                {
                    return _mensajePersonalizado;
                }
            }
        }



    }
}
