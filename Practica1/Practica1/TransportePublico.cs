using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public abstract class TransportePublico
    {
        private int _pasajeros { get; set; }

        public TransportePublico (int pasajeros)
        {
            this._pasajeros = pasajeros;
        }

        public TransportePublico()
        {
           
        }


        public int pasajeros
        {
            get
            {
                return _pasajeros;
            }
            set
            {
                if (value>0)
                {
                    _pasajeros = value;
                }
            }
        }

        public abstract string Avanzar();

        public abstract string Detenerse();
    }
}
