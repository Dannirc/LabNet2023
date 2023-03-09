using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Logic
    {
        public static decimal Division(decimal dividendo, decimal divisor)
        {
            decimal resultado = dividendo / divisor;
            return resultado;
        }

        public static void OutOfMemoryException()
        {

            throw new OutOfMemoryException();
        }

        public static void PerzonalizableException(string mensaje)
        {

            throw new CustomException(mensaje);
        }
    }
}
