using LabNet.EF.Data;
using LabNet.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Add(Customers customer)
        {
            ValidarEntidadNull(customer);
            customer.CustomerID = IdAutogenerado(customer.CompanyName);
            ValidarEntidadExist(customer);
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Update(Customers newCustomer) 
        {
            ValidarEntidadNull(newCustomer);
            context.Customers.AddOrUpdate(newCustomer);
            context.SaveChanges();
        }

        public void Delete(Customers customer) 
        {
            ValidarEntidadNull(customer);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public void DeleteById(string id)
        {
            Customers customer = FindById(id);
            ValidarEntidadNull(customer);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public Customers FindById(string id)
        {
           Customers customer = context.Customers.Find(id);
            ValidarEntidadNull(customer);
            return customer;
        }

        public void ValidarEntidadNull(Customers customer)
        {
            if (customer == null)
            {
                throw new CustomNullException("No se encontro el cliente");
            }
        }

        public void ValidarEntidadExist(Customers customer)
        {
            if (context.Customers.Find(customer.CustomerID) != null)
            {
                throw new CustomExistException("No se pudo agregar. El cliente ya existe!");
            }
        }

        public string IdAutogenerado(string name)
        {
            string id = "";
            name = name.ToUpper();
            string dict = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            int largo = name.Length;
            if (largo > 4)
            {
                id = name.Substring(0, 5);
            } else
            {
                id = name.Substring(0, largo) + dict.Substring(0, 5-largo);
            }

            if (context.Customers.Find(id) == null)
            {
                return id;
            } else
            {
                for (int i = 4; i > 0; i--)
                {
                    foreach (var item in dict)
                    {
                        id = id.Substring(0, i) + item + id.Substring(i, 4-i);
                        if (context.Customers.Find(id) == null)
                        {
                            return id;
                        }
                    }
                }
            }

            return id;
        }
    }
}
