using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectAuto.Repository
{
   public class OperatieRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Operatie> GetSasiuri() => db.Operaties.ToList();

        public Operatie Add(Operatie operatie)
        {
            if (GetById(operatie.OperatieId) != null)
            {
                return null;
            }

            db.Operaties.Add(operatie);
            db.SaveChanges();

            return operatie;
        }

        public Operatie GetById(int id)
        {
            Operatie operatie = db.Operaties.Find(id);
            return operatie;
        }

        public Operatie Update(Operatie operatie)
        {

            if (GetById(operatie.OperatieId) == null)
            {
                return null;
            }

            Operatie operatie1 = GetById(operatie.OperatieId);

            operatie1.Denumire = operatie.Denumire;
            operatie1.TimpExecutie = operatie.TimpExecutie;
            operatie1.Mecanic = operatie.Mecanic;
            operatie1.Materials = operatie.Materials;


            db.SaveChanges();

            return operatie;
        }

        public Boolean Delete(int id)
        {
            Operatie operatie = GetById(id);
            if (operatie == null)
            {
                return false;
            }

            db.Operaties.Remove(operatie);
            db.SaveChanges();
            return true;
        }
    }
}
