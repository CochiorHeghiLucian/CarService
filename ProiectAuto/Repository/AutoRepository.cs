using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProiectAuto.Repository
{
    public class AutoRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Auto> GetAll() => db.Autoes.ToList();

        public Auto Add(Auto auto)
        {
            if (GetById(auto.AutoId) != null)
            {
                return null;
            }

            db.Autoes.Add(auto);
            db.SaveChanges();

            return auto;
        }

        public Auto GetById(int id)
        {
            Auto auto = db.Autoes.Find(id);
            return auto;
        }

        public Auto Update(Auto auto)
        {

            if (GetById(auto.AutoId) == null)
            {
                return null;
            }

            Auto auto1 = GetById(auto.AutoId);

            auto1.ClientClientId = auto.ClientClientId;
            auto1.Comandas = auto.Comandas;
            auto1.NumarAuto = auto.NumarAuto;
            auto1.Sasiu = auto.Sasiu;
            auto1.SerieSasiu = auto.SerieSasiu;

            db.SaveChanges();

            return auto;
        }

        public Boolean Delete(int id)
        {
            Auto auto = db.Autoes.Find(id);
            if (auto == null)
            {
                return false;
            }

            db.Autoes.Remove(auto);
            db.SaveChanges();
            return true;
        }

    }
}

