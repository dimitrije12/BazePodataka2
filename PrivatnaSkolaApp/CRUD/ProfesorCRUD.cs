using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class ProfesorCRUD
    {
        private ModelDBContext db;
        public ProfesorCRUD()
        {
            db = new ModelDBContext();
        }

        public void AddProfesor(Profesor p)
        {
            db.Zaposlenis.Add(p);
            db.SaveChanges();
        }
        public bool DeleteProfesor(Profesor z)
        {
            try
            {
                db.Zaposlenis.Remove(db.Zaposlenis.Find(z.Ime_R));
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

