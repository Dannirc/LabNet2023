using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Omnibus : TransportePublico

    {
        public float _precioPasaje { get; set; }
        public Omnibus(int pasajeros) : base(pasajeros)
        {
        }

        public Omnibus() : base()
        {
        }

        public override string Avanzar()
        {
            return $"El Omnibus realizo un recorrido con {pasajeros} pasajeros";
        }

        public override string Detenerse()
        {
            return "El Omnibus se detuvo";
        }

        private float VentaTotal()
        {
            
            return _precioPasaje*pasajeros;
        }

        public string totalVentas()
        {
            return $"El total de ventas fue de: ${VentaTotal()}";
        }
    }
}
