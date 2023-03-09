using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menu();

        }

        public static void Menu()
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("MENÚ");
                Console.WriteLine("1 - Ejercicio 1");
                Console.WriteLine("2 - Ejercicio 2");
                Console.WriteLine("3 - Ejercicio 3");
                Console.WriteLine("4 - Ejercicio 4");
                Console.WriteLine("0 - Salir del Programa");
                try
                {
                    Console.Write("Seleccione una Opcion: ");
                    opc = int.Parse(Console.ReadLine());

                    while (opc < 0 || opc > 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine("La opcion es incorrecta");
                        Console.Write("Seleccione una Opcion: ");
                        opc = int.Parse(Console.ReadLine());
                    }

                    Console.Clear();

                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Ejercicio 1");
                            Console.WriteLine();
                            Ejercicio1();
                            break;
                        case 2:
                            Console.WriteLine("Ejercicio 2");
                            Console.WriteLine();
                            Ejercicio2();
                            break;
                        case 3:
                            Console.WriteLine("Ejercicio 3");
                            Console.WriteLine();
                            Ejercicio3();
                            break;
                        case 4:
                            Console.WriteLine("Ejercicio 4");
                            Console.WriteLine();
                            Ejercicio4();
                            break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
                    Console.Write("Presione una tecla para continuar... ");
                    Console.ReadKey();
                    opc = -1;
                    
                }
                Console.WriteLine();

            } while (opc != 0);
            Console.WriteLine("Fin del Programa");
            Console.ReadKey();
        }

        public static void Ejercicio1()
        {
            try
            {
                Console.Write("Ingrese un valor: ");
                decimal number = decimal.Parse(Console.ReadLine());
                decimal divisor = 0;

                decimal resultado = number / divisor;

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("La operacion ha finalizado");
            }
            Console.ReadKey();
        }

        public static void Ejercicio2()
        {
            try
            {
                Console.Write("Ingrese el dividendo: ");
                decimal dividendo = decimal.Parse(Console.ReadLine());
                Console.Write("Ingrese el divisor: ");
                decimal divisor = decimal.Parse(Console.ReadLine());

                decimal resultado = Logic.Division(dividendo, divisor);

                Console.WriteLine("El resultado es: " + resultado);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Nadie puede arruinar esta division mas que yo!.. y Tal vez el Muchacho!");
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("La operacion ha finalizado");

            }
            Console.ReadKey();
        }
        public static void Ejercicio3()
        {
            try
            {
                Logic.OutOfMemoryException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("La operacion ha finalizado");
            }
            Console.ReadKey();
        }

        public static void Ejercicio4()
        {
            try
            {
                Console.Write("Se va a lanzar una excepción personalizada, ¿Desea agregar un mensaje personalizado? [S-N]: ");
                string opc = Console.ReadLine().ToLower();

                while (opc != "s" && opc != "n")
                {
                    Console.Write("Se va a lanzar una excepción personalizada, ¿Desea agregar un mensaje personalizado? [S-N]: ");
                    opc = Console.ReadLine().ToLower();
                }

                string mensaje = null;
                if (opc == "s")
                {
                    Console.Write("Ingrese el mensaje personalizado: ");
                    mensaje = Console.ReadLine();

                }

                Logic.PerzonalizableException(mensaje);
            }
            catch (Exception e)
            {

                Console.WriteLine();
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("La operacion ha finalizado");
            }
            Console.ReadKey();
        }
    }
}
