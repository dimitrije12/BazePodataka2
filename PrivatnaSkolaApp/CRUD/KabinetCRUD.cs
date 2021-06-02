using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class KabinetCRUD
    {
        private ModelDBContext db;

        public KabinetCRUD()
        {
            db = new ModelDBContext();
        }

        public bool AddNewKabinet(Kabinet k)
        {
            try
            {
                db.Kabineti.Add(k);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteKabinet(Kabinet k)
        {
            try
            {
                PredmetCRUD pc = new PredmetCRUD();
                List<Predmet> predmeti = pc.GetPredmeti().Where(x => x.KabinetBroj == k.Broj).ToList();
                foreach(Predmet p in predmeti)
                {
                    pc.DeletePredmet(p);
                }


                db.Kabineti.Remove(k);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Kabinet> GetAllKabinet()
        {
            return db.Kabineti;
        }
        public IEnumerable<PrivatnaSkola> GetAllSkole()
        {
            return db.PrivatneSkole;
        }
    }
}
