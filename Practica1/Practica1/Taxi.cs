using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Taxi : TransportePublico
    {
        public float _precioPorKM { get; set; }
        public Taxi(int pasajeros) : base(pasajeros)
        {
        }

        public Taxi() : base()
        {
        }

        public override string Avanzar()
        {
            return $"El taxi realizo un viaje con {Pasajeros} pasajeros";
        }

        public override string Detenerse()
        {
            return "El taxi se detuvo";
        }

        private float VentaTotal(int km)
        {

            return _precioPorKM * km;
        }

        public string CostoViaje(int km)
        {
            return $"El total del costo del viaje fue de: ${VentaTotal(km)}";
        }
    }
}
