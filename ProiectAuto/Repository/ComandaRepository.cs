using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectAuto.Repository
{
    public class ComandaRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Comanda> GetAll() => db.Comandas.ToList();

        public Comanda Add(Comanda comanda)
        {
            if (GetById(comanda.ComandaId) != null)
            {
                return null;
            }

            db.Comandas.Add(comanda);
            db.SaveChanges();

            return comanda;
        }

        public Comanda GetById(int id)
        {
            Comanda comanda = db.Comandas.Find(id);
            return comanda;
        }

        public Comanda Update(Comanda comanda)
        {

            if (GetById(comanda.ComandaId) == null)
            {
                return null;
            }

            Comanda comanda1 = GetById(comanda.ComandaId);

            comanda1.StareComanda = comanda.StareComanda;
            comanda1.DataSystem = comanda.DataSystem;
            comanda1.DataProgramare = comanda.DataProgramare;
            comanda1.DataFinalizare = comanda.DataFinalizare;
            comanda1.KmBord = comanda.KmBord;
            comanda1.Descriere = comanda.Descriere;
            comanda1.ValoarePiese = comanda.ValoarePiese;
            comanda1.Auto = comanda.Auto;
            comanda1.DetaliuComanda = comanda.DetaliuComanda;

            db.SaveChanges();

            return comanda;
        }

        public Boolean Delete(int id)
        {
            Comanda comanda = GetById(id);
            if (comanda == null)
            {
                return false;
            }

            db.Comandas.Remove(comanda);
            db.SaveChanges();
            return true;
        }
    }
}
