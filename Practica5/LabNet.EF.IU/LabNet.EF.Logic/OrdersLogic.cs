using LabNet.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.EF.Logic
{
    public class OrdersLogic : BaseLogic
    {
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }
    }
}
