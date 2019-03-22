using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectAuto.Repository
{
    public class MecanicRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Mecanic> GetSasiuri() => db.Mecanics.ToList();

        public Mecanic Add(Mecanic mecanic)
        {
            if (GetById(mecanic.MecanicId) != null)
            {
                return null;
            }

            db.Mecanics.Add(mecanic);
            db.SaveChanges();

            return mecanic;
        }

        public Mecanic GetById(int id)
        {
            Mecanic mecanic = db.Mecanics.Find(id);
            return mecanic;
        }

        public Mecanic Update(Mecanic mecanic)
        {

            if (GetById(mecanic.MecanicId) == null)
            {
                return null;
            }

            Mecanic mecanic1 = GetById(mecanic.MecanicId);

            mecanic1.Nume = mecanic.Nume;
            mecanic1.Prenume = mecanic.Prenume;
            mecanic1.esteDisponibil = mecanic.esteDisponibil;
            mecanic1.DetaliuComanda = mecanic.DetaliuComanda;
            mecanic1.Operaties = mecanic.Operaties;

            db.SaveChanges();

            return mecanic;
        }

        public Boolean Delete(int id)
        {
            Mecanic mecanic = GetById(id);
            if (mecanic == null)
            {
                return false;
            }

            db.Mecanics.Remove(mecanic);
            db.SaveChanges();
            return true;
        }
    }
}
