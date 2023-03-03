﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> transportes = new List<TransportePublico>();

            int input = 0, cont_omnibus = 0, cont_taxi = 0;

            while (transportes.Count < 10)
            {
                Console.Write("Seleccione transporte a ingresar (Omnibus[1] o Taxi[2]): ");
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    if (cont_omnibus < 5)
                    {
                        Omnibus omnibus = new Omnibus();
                        Console.WriteLine(omnibus.Detenerse());
                        Console.Write("Ingrese precio del pasaje (1-500):");
                        omnibus._precioPasaje = float.Parse(Console.ReadLine());
                        while (omnibus._precioPasaje < 1 || omnibus._precioPasaje > 500)
                        {
                            Console.Write("Ingrese precio del pasaje (1-500):");
                            omnibus._precioPasaje = float.Parse(Console.ReadLine());
                        }
                        Console.Write("Ingrese Cantidad de Pasajeros (1-100): ");
                        omnibus.Pasajeros = int.Parse(Console.ReadLine());
                        while (omnibus.Pasajeros < 1 || omnibus.Pasajeros > 100){
                            Console.Write("Ingrese Cantidad de Pasajeros (1-100): ");
                            omnibus.Pasajeros = int.Parse(Console.ReadLine());
                        }
                        transportes.Add(omnibus);
                        Console.WriteLine(omnibus.Avanzar());
                        Console.WriteLine(omnibus.TotalVentas());
                        cont_omnibus++;
                    }
                    else
                    {
                        Console.WriteLine("Ha alcanzado el maximo de Omnibus disponibles (5)");
                    }
                }
                if (input == 2)
                {
                    if (cont_taxi < 5)
                    {
                        Taxi taxi = new Taxi();
                        Console.WriteLine(taxi.Detenerse());
                        Console.Write("Ingrese precio por km (1-1000):");
                        taxi._precioPorKM = float.Parse(Console.ReadLine());
                        while (taxi._precioPorKM < 1 || taxi._precioPorKM > 1000)
                        {
                            Console.Write("Ingrese precio por km (1-1000):");
                            taxi._precioPorKM = float.Parse(Console.ReadLine());
                        }
                        Console.Write("Ingrese cantidad de km del viaje (1-10000): ");
                        int km = int.Parse(Console.ReadLine());
                        while (km < 1 || km > 10000)
                        {
                            Console.Write("Ingrese cantidad de km del viaje (1-10000): ");
                            km = int.Parse(Console.ReadLine());
                        }
                        Console.Write("Ingrese Cantidad de Pasajeros (1-4): ");
                        taxi.Pasajeros = int.Parse(Console.ReadLine());
                        while (taxi.Pasajeros < 1 || taxi.Pasajeros > 4)
                        {
                            Console.Write("Ingrese Cantidad de Pasajeros (1-4): ");
                            taxi.Pasajeros = int.Parse(Console.ReadLine());
                        }
                        transportes.Add(taxi);
                        Console.WriteLine(taxi.Avanzar());
                        Console.WriteLine(taxi.CostoViaje(km));
                        cont_taxi++;
                    }
                    else
                    {
                        Console.WriteLine("Ha alcanzado el maximo de Taxis disponibles (5)");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Se ingreso la siguiente coleccion de transportes: ");

            Imprimir("Omnibus", transportes);
            Imprimir("Taxi", transportes);
            Console.ReadKey();
        }

        public static void Imprimir(string nombre_transporte, List<TransportePublico> transportes)
        {
            int cont = 0;
            for (int i = 0; i < 10; i++)
            {
                if (transportes[i].GetType().Name == nombre_transporte)
                {
                    cont++;
                    Console.WriteLine($"{transportes[i].GetType().Name} {cont}: {transportes[i].Pasajeros} pasajeros");
                }
            }
        }
    }
}
