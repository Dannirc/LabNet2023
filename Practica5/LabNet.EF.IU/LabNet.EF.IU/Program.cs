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

            ProductsLogic productsLogic = new ProductsLogic();

            OrdersLogic ordersLogic = new OrdersLogic();

            Menu(customersLogic, productsLogic, ordersLogic);

            Console.ReadLine();
            
        }

        public static void Ejercicio1(CustomersLogic customersLogic)
        {
            List<Customers> customers = customersLogic.GetAll();

            Customers customer = customers.FirstOrDefault(c => c.CompanyName == "Eastern Connection");

            Console.WriteLine($"Objeto customer: {customer}");
            Console.WriteLine($"ID: {customer.CustomerID}");
            Console.WriteLine($"Compañia: {customer.CompanyName}");
        }

        public static void Ejercicio2(ProductsLogic productsLogic)
        {
            List<Products> products = productsLogic.GetAll();

            var productsSinStock = products.Where(p => p.UnitsInStock == 0).ToList();

            Console.WriteLine("****** Listado de Productos Sin Stock *****");
            foreach (var product in productsSinStock)
            {
                Console.WriteLine($"Nombre Producto: {product.ProductName}");
            }
        }

        public static void Ejercicio3(ProductsLogic productsLogic)
        {
            List<Products> products = productsLogic.GetAll();

            var query = from product in products
                        where product.UnitsInStock > 0
                        where product.UnitPrice > 3
                        select product;

            Console.WriteLine("***** Listado de productos en stock con precio por unidad mayor a 3 *****");
            var i = 0;
            foreach (var product in query)
            {
                i++;
                Console.WriteLine($"{i} - Nombre Producto: {product.ProductName}");
            }
        }

        public static void Ejercicio4(CustomersLogic customersLogic)
        {
            List<Customers> customers = customersLogic.GetAll();

            var customersRegionWA = from customer in customers
                                    where customer.Region == "WA"
                                    select customer;

            Console.WriteLine("***** Listado de clientes con Region WA *****");
            foreach (var customer in customersRegionWA)
            {
                Console.Write($"ID: {customer.CustomerID} - ");
                Console.WriteLine($"Compañia: {customer.CompanyName}");
            }
        }

        public static void Ejercicio5(ProductsLogic productsLogic)
        {
            List<Products> products = productsLogic.GetAll();

            var query = products.FirstOrDefault(p => p.ProductID == 789);

            if (query == null)
            {
                Console.WriteLine("No existe producto con ese ID");
            }

        }

        public static void Ejercicio6(CustomersLogic customersLogic)
        {
            List<Customers> customers = customersLogic.GetAll();

            var query = from customer in customers
                        select customer.CompanyName.ToLower();

            var query2 = from customer in customers
                        select customer.CompanyName.ToUpper();

            Console.WriteLine("***** Listado de Nombres de Customers minusculas");
            int i = 0;
            foreach (var name in query)
            {
                i++;
                Console.WriteLine($"{i} Nombre: {name}");
            }

            Console.WriteLine();
            Console.WriteLine("***** Listado de Nombres de Customers mayusculas");
            i = 0;
            foreach (var name in query2)
            {
                i++;
                Console.WriteLine($"{i} Nombre: {name}");
            }

        }

        public static void Ejercicio7(CustomersLogic customersLogic, OrdersLogic ordersLogic)
        {
            List<Customers> customers = customersLogic.GetAll();
            List<Orders> orders = ordersLogic.GetAll();

            var date = DateTime.Parse("01/01/1997");

            var query = from customer in customers
                        join order in orders on customer.CustomerID equals order.CustomerID
                        where customer.Region == "WA"
                        where order.OrderDate > date
                        select new { customer, order};

            Console.WriteLine("***** Listado de Customers de region WA y orders desde 01-01-1997");
            Console.WriteLine();
            var i=0;
            foreach (var item in query)
            {
                i++;
                Console.WriteLine($"{i} Nombre: {item.customer.ContactName}, Fecha: {item.order.OrderDate}, Region: {item.customer.Region}");
            }

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

        public static void Menu(CustomersLogic customersLogic, ProductsLogic productsLogic, OrdersLogic ordersLogic)
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
                            Ejercicio1(customersLogic);
                            Continuar();
                            break;
                        case 2:
                            Ejercicio2(productsLogic);
                            Continuar();
                            break;
                        case 3:
                            Ejercicio3(productsLogic);
                            Continuar();
                            break;
                        case 4:
                            Ejercicio4(customersLogic);
                            Continuar();
                            break;
                        case 5:
                            Ejercicio5(productsLogic);
                            Continuar();
                            break;
                        case 6:
                            Ejercicio6(customersLogic);
                            Continuar();
                            break;
                        case 7:
                            Ejercicio7(customersLogic, ordersLogic);
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

        public static int IngresarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine("***** MENÚ *****");
            Console.WriteLine();
            Console.WriteLine("1 - Ejercicio 01");
            Console.WriteLine("2 - Ejercicio 02");
            Console.WriteLine("3 - Ejercicio 03");
            Console.WriteLine("4 - Ejercicio 04");
            Console.WriteLine("5 - Ejercicio 05");
            Console.WriteLine("6 - Ejercicio 06");
            Console.WriteLine("7 - Ejercicio 07");
            Console.WriteLine();
            Console.WriteLine("0 - Salir del Programa");
            Console.WriteLine();
            int opc = IngresarInt("Seleccione una Opcion: ", 0, 7);

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
