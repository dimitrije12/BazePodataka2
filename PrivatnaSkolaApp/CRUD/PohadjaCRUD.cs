using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class PohadjaCRUD
    {
        private ModelDBContext db;
        public PohadjaCRUD()
        {
            db = new ModelDBContext();
        }

        public bool AddNewPohadja(Pohadja p)
        {
            try
            {
               
                    db.Pohadjas.Add(p);
                    db.SaveChanges();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePohadja(Pohadja p)
        {
            try
            {
               
                    db.Pohadjas.Remove(db.Pohadjas.Find(p.UcenikJMBG_U,p.PrivatnaSkolaRegBroj));
                    db.SaveChanges();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Pohadja> GetAllPohadja()
        {
            return db.Pohadjas;
        }
        public IEnumerable<Ucenik> GetAllUcenici()
        {
            return db.Ucenici;
        }
        public IEnumerable<PrivatnaSkola> GetAllPSkole()
        {
            return db.PrivatneSkole;
        }
    }
}
