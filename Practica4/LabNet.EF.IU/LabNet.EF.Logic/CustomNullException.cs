using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.EF.Logic
{
    internal class CustomNullException : Exception
    {
        private string _mensajePersonalizado;

        public CustomNullException(string mensajePersonalizado)
        {
            _mensajePersonalizado = mensajePersonalizado;
        }

        public override string Message
        {
            get
            {
                if (_mensajePersonalizado == null)
                {
                    return $"No se encontro el elemento";
                }
                else
                {
                    return _mensajePersonalizado;
                }
            }
        }
    }
}
