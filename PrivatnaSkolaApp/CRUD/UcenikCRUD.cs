using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class UcenikCRUD
    {
        private ModelDBContext db;

        public UcenikCRUD()
        {
            this.db = new ModelDBContext();
        }

        public bool AddUcenik(Ucenik u)
        {
            try
            {
                db.Ucenici.Add(u);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUcenik(Ucenik u)
        {
            try
            {
                
                    List<Pohadja> pohadjanja = db.Pohadjas.Where(x => x.UcenikJMBG_U == u.JMBG_U).ToList();
                    PohadjaCRUD pc = new PohadjaCRUD();
                    foreach(Pohadja p in pohadjanja)
                    {
                        pc.DeletePohadja(p);
                    }

                ZiviCRUD zcrud = new ZiviCRUD();
                List<Zivi> z = zcrud.GetAllZivi().Where(x => x.UcenikJMBG_U == u.JMBG_U).ToList();
                foreach (Zivi zi in z)
                {
                    zcrud.DeleteZivi(zi);
                }

                db.Ucenici.Remove(db.Ucenici.Find(u.JMBG_U));
                    db.SaveChanges();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Ucenik> GetAllUcenici()
        {
            return db.Ucenici;
        }
        public IEnumerable<Roditelj> GetAllRoditelji()
        {
            return db.Roditelji;
        }
    }
}
