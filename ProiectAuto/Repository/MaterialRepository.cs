using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectAuto.Repository
{
   public class MaterialRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Sasiu> GetSasiuri() => db.Sasius.ToList();

        public Material Add(Material material)
        {
            if (GetById(material.MaterialId) != null)
            {
                return null;
            }

            db.Materials.Add(material);
            db.SaveChanges();

            return material;
        }

        public Material GetById(int id)
        {
            Material material = db.Materials.Find(id);
            return material;
        }

        public Material Update(Material material)
        {

            if (GetById(material.MaterialId) == null)
            {
                return null;
            }

            Material material1 = GetById(material.MaterialId);

            material1.Denumire = material.Denumire;
            material1.Cantitate = material.Cantitate;
            material1.Pret = material.Pret;
            material1.DataAprovizonare = material.DataAprovizonare;

            db.SaveChanges();

            return material;
        }

        public Boolean Delete(int id)
        {
            Material material = GetById(id);
            if (material == null)
            {
                return false;
            }

            db.Materials.Remove(material);
            db.SaveChanges();
            return true;
        }
    }

}

