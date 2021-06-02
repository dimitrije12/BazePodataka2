using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class SpremacicaCRUD
    {
        private ModelDBContext db;
        public SpremacicaCRUD()
        {
            db = new ModelDBContext();
        }

        public void AddSpremacica(Spremacica s)
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
        public bool DeleteSpremacica(Spremacica z)
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

