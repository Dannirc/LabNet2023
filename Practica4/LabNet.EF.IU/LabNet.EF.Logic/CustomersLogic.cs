using LabNet.EF.Data;
using LabNet.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ValidarEntidadExist(customer);
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Update(Customers newCustomer) 
        {
            context.SaveChanges();
        }

        public void Delete(Customers customer)
        {
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
    }
}
