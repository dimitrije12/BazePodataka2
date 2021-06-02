using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class ObezbedjenjCRUD
    {
        private ModelDBContext db;
        public ObezbedjenjCRUD()
        {
            db = new ModelDBContext();
        }

        public void AddObezbedjenje(Obezbedjenje s)
        {
            try
            {
                db.Zaposlenis.Add(s);
                db.SaveChanges();
            }
            catch
            {

            }
        }
        public bool DeleteObezbedjenje(Obezbedjenje z)
        {
            try
            {
                db.Zaposlenis.Remove(z);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Zaposleni> GetZaposleni()
        {
            return db.Zaposlenis;
        }



        public IEnumerable<Predmet> GetPredmeti()
        {
            return db.Predmeti;
        }

        public IEnumerable<PrivatnaSkola> GetSkole()
        {
            return db.PrivatneSkole;
        }
    }
}
