using LabNet.EF.Entities;
using LabNet.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.EF.IU
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic customersLogic = new CustomersLogic();

            TerritoriesLogic territoriesLogic = new TerritoriesLogic();

            Menu(customersLogic, territoriesLogic);

        }

        public static void Menu(CustomersLogic customersLogic, TerritoriesLogic territoriesLogic)
        {
            int opc = 0;
            do
            {                
                try
                {
                    opc = IngresarOpcionMenu();

                    Console.Clear();

                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("***** Listado de Clientes *****");
                            Console.WriteLine();
                            MostrarClientes(customersLogic);
                            Continuar();
                            break;
                        case 2:
                            Console.WriteLine("***** Agregar Cliente *****");
                            Console.WriteLine();
                            AgregarCliente(customersLogic);
                            Continuar();
                            break;
                        case 3:
                            Console.WriteLine("***** Modificar Cliente *****");
                            Console.WriteLine();
                            ModificarCliente(customersLogic);
                            Continuar();
                            break;
                        case 4:
                            Console.WriteLine("***** Eliminar Cliente *****");
                            Console.WriteLine();
                            EliminarCliente(customersLogic);
                            Continuar();
                            break;
                        case 5:
                            Console.WriteLine("***** Buscar Cliente *****");
                            Console.WriteLine();
                            BuscarCliente(customersLogic);
                            Continuar();
                            break;
                        case 6:
                            Console.WriteLine("***** Listado de Territorios *****");
                            Console.WriteLine();
                            MostrarTerritorios(territoriesLogic);
                            Continuar();
                            break;
                        case 7:
                            Console.WriteLine("***** Agregar Territorio *****");
                            Console.WriteLine();
                            AgregarTerritorio(territoriesLogic);
                            Continuar();
                            break;
                        case 8:
                            Console.WriteLine("***** Modificar Territorio *****");
                            Console.WriteLine();
                            ModificarTerritorio(territoriesLogic);
                            Continuar();
                            break;
                        case 9:
                            Console.WriteLine("***** Eliminar Territorio *****");
                            Console.WriteLine();
                            EliminarTerritorio(territoriesLogic);
                            Continuar();
                            break;
                        case 10:
                            Console.WriteLine("***** Buscar Territorio *****");
                            Console.WriteLine();
                            BuscarTerritorio(territoriesLogic);
                            Continuar();
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
            Console.Write("Fin del Programa");
            Console.ReadKey();
        }

        public static void MostrarClientes(CustomersLogic customersLogic)

        {
            int i = 0;
            
            foreach (Customers customer in customersLogic.GetAll())
            {
                i++;
                Console.WriteLine($"{i} - ID: {customer.CustomerID} - Compañia: {customer.CompanyName}");
            }
        }

        public static void AgregarCliente(CustomersLogic customersLogic)
        {
            try
            {
                Customers customer = new Customers();

                customer.CustomerID = IngresarString("Ingrese el id del cliente [5]: ", 1, 5).ToUpper();

                customer.CompanyName = IngresarString("Ingrese nombre del cliente [40]: ", 1, 40);

                customersLogic.Add(customer);

                Console.WriteLine();
                Console.WriteLine("El cliente fue agregado con exito!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void EliminarCliente(CustomersLogic customersLogic)
        {
            try
            {
                string id = IngresarString("Ingrese Id del cliente a eliminar: ", 1, 5);
                Customers customer = customersLogic.FindById(id);
                customersLogic.Delete(customer);

                Console.WriteLine();
                Console.WriteLine("Cliente Eliminado con exito!");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void ModificarCliente(CustomersLogic customersLogic)
        {
            try
            {
                Customers customer = new Customers();

                string id = IngresarString("Ingrese Id del cliente a editar: ", 1, 5);
                customer = customersLogic.FindById(id);

                customer.CompanyName = IngresarString("Ingrese el nuevo nombre del cliente [40]: ", 1, 40);

                customersLogic.Update(customer);

                Console.WriteLine();
                Console.WriteLine("Cliente Actualizado!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void BuscarCliente(CustomersLogic customersLogic)
        {
            try
            {
                Customers customer = customersLogic.FindById(IngresarString("Ingrese el id del cliente [5]: ", 1, 5));

                Console.WriteLine("Cliente Encontrado!!");
                Console.WriteLine();
                Console.WriteLine($"ID: {customer.CustomerID}");
                Console.WriteLine($"Compañia: {customer.CompanyName}");
                Console.WriteLine($"Contacto: {customer.ContactName}");
                Console.WriteLine($"Cargo: {customer.ContactTitle}");
                Console.WriteLine($"Dirección: {customer.Address}");
                Console.WriteLine($"Ciudad: {customer.CustomerID}");
                Console.WriteLine($"Region: {customer.Region}");
                Console.WriteLine($"Cod.P.: {customer.PostalCode}");
                Console.WriteLine($"País: {customer.Country}");
                Console.WriteLine($"Tel.: {customer.Phone}");
                Console.WriteLine($"Fax: {customer.Fax}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void MostrarTerritorios(TerritoriesLogic territoriesLogic)

        {
            int i = 0;

            foreach (Territories territory in territoriesLogic.GetAll())
            {
                i++;
                Console.WriteLine($"{i} - ID: {territory.TerritoryID} - Descripción: {territory.TerritoryDescription}");
            }
        }

        public static void AgregarTerritorio(TerritoriesLogic territoriesLogic)
        {
            try
            {
                Territories territory = new Territories();

                territory.TerritoryID = IngresarString("Ingrese el id del territorio [string 20]: ", 1, 20).ToUpper();

                territory.TerritoryDescription = IngresarString("Ingrese descripción del territorio [string 50]: ", 1, 50);

                territoriesLogic.Add(territory);

                Console.WriteLine();
                Console.WriteLine("El territorio fue agregado con exito!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void EliminarTerritorio(TerritoriesLogic territoriesLogic)
        {
            try
            {
                string id = IngresarString("Ingrese el id del territorio [string 20]: ", 1, 20);
                Territories territory = territoriesLogic.FindById(id);
                territoriesLogic.Delete(territory);

                Console.WriteLine();
                Console.WriteLine("Territorio Eliminado con exito!");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void ModificarTerritorio(TerritoriesLogic territoriesLogic)
        {
            try
            {
                Territories territory = new Territories();

                Console.Write("Ingrese Id del territorio a editar: ");
                string id = Console.ReadLine();

                territory = territoriesLogic.FindById(id);

                territory.TerritoryDescription = IngresarString("Ingrese nueva descripción del territorio [string 50]: ", 1, 50);

                territoriesLogic.Update(territory);

                Console.WriteLine();
                Console.WriteLine("Territorio Actualizado!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void BuscarTerritorio(TerritoriesLogic territoriesLogic)
        {
            try
            {
                Territories territory = territoriesLogic.FindById(IngresarString("Ingrese el id del territorio [5]: ", 1, 5));

                Console.WriteLine("Territorio Encontrado!!");
                Console.WriteLine();
                Console.WriteLine($"ID: {territory.TerritoryID}");
                Console.WriteLine($"Descripción: {territory.TerritoryDescription}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static string IngresarString(string mensaje, int min, int max)
        {
            Console.Write(mensaje);
            string input = Console.ReadLine();
            while (input.Length > max || input.Length < min)
            {
                Console.Write(mensaje);
                input = Console.ReadLine();
            }

            return input;
        }

        public static int IngresarInt(string mensaje, int min, int max)
        {
            Console.Write(mensaje);
            int input = int.Parse(Console.ReadLine());
            while (input > max || input < min)
            {
                Console.WriteLine();
                Console.WriteLine("La opcion es incorrecta");
                Console.Write(mensaje);
                input = int.Parse(Console.ReadLine());
            }

            return input;
        }

        public static int IngresarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine("***** MENÚ *****");
            Console.WriteLine();
            Console.WriteLine("1 - Mostrar todos los clientes");
            Console.WriteLine("2 - Agregar Cliente");
            Console.WriteLine("3 - Modificar Cliente");
            Console.WriteLine("4 - Eliminar Cliente");
            Console.WriteLine("5 - Buscar Cliente");
            Console.WriteLine();
            Console.WriteLine("6 - Mostrar todos los territorios");
            Console.WriteLine("7 - Agregar Territorio");
            Console.WriteLine("8 - Modificar Territorio");
            Console.WriteLine("9 - Eliminar Territorio");
            Console.WriteLine("10 - Buscar Territorio");
            Console.WriteLine();
            Console.WriteLine("0 - Salir del Programa");
            Console.WriteLine();
            int opc = IngresarInt("Seleccione una Opcion: ", 0, 10);

            return opc;
        }

        public static void Continuar()
        {
            Console.WriteLine();
            Console.Write("Presione una tecla para continuar...");
            Console.ReadLine();
        }
    }
}
