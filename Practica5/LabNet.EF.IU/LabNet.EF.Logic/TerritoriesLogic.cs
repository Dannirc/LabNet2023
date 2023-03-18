using LabNet.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet.EF.Logic
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories>
    {
        public void Add(Territories territory)
        {
            ValidarEntidadNull(territory);
            ValidarEntidadExist(territory);
            // se agrega por defecto region 1
            territory.RegionID = 1;
            context.Territories.Add(territory);
            context.SaveChanges();
        }

        public void Delete(Territories territory)
        {
            ValidarEntidadNull(territory);
            context.Territories.Remove(territory);
            context.SaveChanges();
        }

        public Territories FindById(string id)
        {
            Territories territory = context.Territories.Find(id);
            ValidarEntidadNull(territory);
            return territory;
        }

        public List<Territories> GetAll()
        {
            return context.Territories.ToList();
        }

        public void Update(Territories territory)
        {
            context.SaveChanges();
        }

        public void ValidarEntidadExist(Territories territory)
        {
            if (context.Territories.Find(territory.TerritoryID) != null)
            {
                throw new CustomExistException("No se pudo agregar. El territorio ya existe!");
            }
        }

        public void ValidarEntidadNull(Territories territory)
        {
            if (territory == null)
            {
                throw new CustomNullException("No se encontro el territorio");
            }
        }
    }
}
