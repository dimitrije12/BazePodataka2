using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    public class ZiviCRUD
    {
        private ModelDBContext db;

        public ZiviCRUD()
        {
            db = new ModelDBContext();
        }
        public bool AddNewZivi(Zivi p)
        {
            try
            {
                
                    db.Zivis.Add(p);
                    db.SaveChanges();
               
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteZivi(Zivi p)
        {
            try
            {
                
                    db.Zivis.Remove(p);
                    db.SaveChanges();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Zivi> GetAllZivi()
        {
            return db.Zivis;
        }
        public IEnumerable<Ucenik> GetAllUcenici()
        {
            return db.Ucenici;
        }
        public IEnumerable<Grad> GetAllPGrad()
        {
            return db.Gradovi;
        }


    }
}
