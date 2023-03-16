using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.EF.Logic
{
    internal class CustomExistException : Exception
    {
        private string _mensajePersonalizado;

        public CustomExistException(string mensajePersonalizado)
        {
            _mensajePersonalizado = mensajePersonalizado;
        }

        public override string Message
        {
            get
            {
                if (_mensajePersonalizado == null)
                {
                    return $"El elemento ya existe!";
                }
                else
                {
                    return _mensajePersonalizado;
                }
            }
        }
    }
}
