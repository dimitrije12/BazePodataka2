using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class DrziCRUD
    {

        ModelDBContext db;
        public DrziCRUD()
        {
            db = new ModelDBContext();
        }

        public void AddDrzi(Drzi d)
        {
            try
            {
                db.Drzis.Add(d);
                db.SaveChanges();
            }
            catch
            {

            }
        }
        public void DeleteDrzi(Drzi d)
        {
            try
            {
                db.Drzis.Remove(db.Drzis.Find(d.VlasnikJMBG_V, d.PrivatnaSkolaRegBroj));
                db.SaveChanges();
            }
            catch
            {

            }
        }
        public IEnumerable<Drzi> GetAllDrzi()
        {
            return db.Drzis;
        }
        public IEnumerable<Vlasnik> GetAllVlasnik()
        {
            return db.Vlasnici;
        }
        public IEnumerable<Zaposleni> GetAllZaposleni()
        {
            return db.Zaposlenis;
        }

        public int getRegBroj(string jmbg)
        {
            Zaposleni v = db.Zaposlenis.Find(jmbg);
            return v.PrivatnaSkolaRegBroj;
        }
        
    }
}
