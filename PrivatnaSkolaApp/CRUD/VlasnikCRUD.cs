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
                db.Vlasnici.Remove(v);
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
