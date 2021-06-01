using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class PredmetCRUD
    {
        private ModelDBContext db;
        public PredmetCRUD()
        {
            db = new ModelDBContext();
        }

        public bool AddPredmet(Predmet p)
        {
            try
            {
                db.Predmeti.Add(p);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Predmet> GetPredmeti()
        {
            return db.Predmeti;
        }
        public IEnumerable<Kabinet> GetKabineti()
        {
            return db.Kabineti;
        }
        public bool DeletePredmet(Predmet p)
        {
            try
            {
                db.Predmeti.Remove(p);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
