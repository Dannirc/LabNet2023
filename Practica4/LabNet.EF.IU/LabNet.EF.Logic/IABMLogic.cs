using LabNet.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.EF.Logic
{
     interface IABMLogic<T>
    {
        List<T> GetAll();

        void Add(T add);

        void Update(T update);

        void Delete(T delete);

        T FindById(string id);
        void ValidarEntidadNull(T valid);

        void ValidarEntidadExist(T valid);
    }
}
