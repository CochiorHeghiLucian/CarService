using ProiectAuto.BazaDeDate;
using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProiectAuto.Repository
{
    public class ImagineRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Imagine> GetSasiuri() => db.Imagines.ToList();

        public Imagine Add(Imagine imagine)
        {
            if (GetById(imagine.ImagineId) != null)
            {
                return null;
            }

            db.Imagines.Add(imagine);
            db.SaveChanges();

            return imagine;
        }

        public Imagine GetById(int id)
        {
            Imagine sasiu = db.Imagines.Find(id);
            return sasiu;
        }

        public Imagine Update(Imagine imagine)
        {

            if (GetById(imagine.ImagineId) == null)
            {
                return null;
            }

            Imagine imagine1 = GetById(imagine.ImagineId);

            imagine1.Titlu = imagine.Titlu;
            imagine1.Descriere = imagine.Descriere;
            imagine1.Data = imagine.Data;
            imagine1.Foto = imagine.Foto;

            db.SaveChanges();

            return imagine;
        }

        public Boolean Delete(int id)
        {
            Imagine imagine = GetById(id);
            if (imagine == null)
            {
                return false;
            }

            db.Imagines.Remove(imagine);
            db.SaveChanges();
            return true;
        }
    }
}

