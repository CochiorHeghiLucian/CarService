using ProiectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectAuto.BazaDeDate;

namespace ProiectAuto.Repository
{
    public class SasiuRepository
    {
        private ModelAutoContexContainer db = BazaDeDate1.GetInstance();

        public List<Sasiu> GetSasiuri() => db.Sasius.ToList();

        public Sasiu Add(Sasiu sasiu)
        {
            if (GetById(sasiu.SasiuId) != null)
            {
                return null;
            }

            db.Sasius.Add(sasiu);
            db.SaveChanges();

            return sasiu;
        }

        public Sasiu GetById(int id)
        {
            Sasiu sasiu = db.Sasius.Find(id);
            return sasiu;
        }

        public Sasiu Update(Sasiu sasiu)
        {

            if (GetById(sasiu.SasiuId) == null)
            {
                return null;
            }

            Sasiu sasiu1 = GetById(sasiu.SasiuId);

            sasiu1.CodSasiu = sasiu.CodSasiu;
            sasiu1.Denumire = sasiu.Denumire;


            db.SaveChanges();

            return sasiu;
        }

        public Boolean Delete(int id)
        {
            Sasiu sasiu = GetById(id);
            if (sasiu == null)
            {
                return false;
            }

            db.Sasius.Remove(sasiu);
            db.SaveChanges();
            return true;
        }
    }


}
