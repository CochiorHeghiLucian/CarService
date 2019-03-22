using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectAuto.Repository
{
    public class DetaliuComandaRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<DetaliuComanda> GetAll() => db.DetaliuComandas.ToList();

        public DetaliuComanda Add(DetaliuComanda detaliuComanda)
        {
            if (GetById(detaliuComanda.DetaliuComandaId) != null)
            {
                return null;
            }

            db.DetaliuComandas.Add(detaliuComanda);
            db.SaveChanges();

            return detaliuComanda;
        }

        public DetaliuComanda GetById(int id)
        {
            DetaliuComanda detaliuComanda = db.DetaliuComandas.Find(id);
            return detaliuComanda;
        }

        public DetaliuComanda Update(DetaliuComanda detaliuComanda)
        {

            if (GetById(detaliuComanda.DetaliuComandaId) == null)
            {
                return null;
            }

            DetaliuComanda detaliuComanda1 = GetById(detaliuComanda.DetaliuComandaId);

            detaliuComanda1.Mecanics = detaliuComanda.Mecanics;
            detaliuComanda1.Imagines = detaliuComanda.Imagines;
            detaliuComanda1.Comanda = detaliuComanda.Comanda;


            db.SaveChanges();

            return detaliuComanda;
        }

        public Boolean Delete(int id)
        {
            DetaliuComanda detaliuComanda = db.DetaliuComandas.Find(id);
            if (detaliuComanda == null)
            {
                return false;
            }

            db.DetaliuComandas.Remove(detaliuComanda);
            db.SaveChanges();
            return true;
        }
    }
}
