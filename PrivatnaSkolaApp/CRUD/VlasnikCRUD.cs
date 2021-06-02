using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatBP;
namespace PrivatnaSkolaApp.CRUD
{
    class VlasnikCRUD
    {
        private ModelDBContext db;

        public VlasnikCRUD()
        {
            db = new ModelDBContext();
        }
        public void UpdateVlasnik()
        {
            db.SaveChanges();
        }
        public Vlasnik GetVlasnik(string ID)
        {
            return db.Vlasnici.Find(ID);
        }

        public void AddVlasnik(Vlasnik v)
        {
            db.Vlasnici.Add(v);
            db.SaveChanges();   
        }

        public void DeleteVlasnik(Vlasnik v)
        {
            db.Vlasnici.Remove(v);
            db.SaveChanges();
        }

        public void DeleteAll(Vlasnik v)
        {
            db.Vlasnici.Remove(v);
            db.SaveChanges();
        }
        public bool ObrisiVlasnika(Vlasnik v)
        {
            try
            {
                List<Drzi> drzis = db.Drzis.Where(x => x.VlasnikJMBG_V == v.JMBG_V).ToList();
                DrziCRUD dc = new DrziCRUD();
                foreach(Drzi d in drzis)
                {
                    dc.DeleteDrzi(d);
                }
                db.Vlasnici.Remove(db.Vlasnici.Find(v.JMBG_V));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public IEnumerable<Vlasnik> GetAllVlasnici()
        {
            return db.Vlasnici;
        }
    }
}
