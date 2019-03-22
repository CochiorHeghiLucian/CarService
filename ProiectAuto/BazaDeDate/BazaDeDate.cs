using ProiectAuto.Models;

namespace ProiectAuto.BazaDeDate
{
    public class BazaDeDate1
    {
        private static ModelAutoContexContainer db;

        public static ModelAutoContexContainer GetInstance()
        {
            if (db == null)
            {
                db = new ModelAutoContexContainer();
            }
            return db;
        }
    }
}
