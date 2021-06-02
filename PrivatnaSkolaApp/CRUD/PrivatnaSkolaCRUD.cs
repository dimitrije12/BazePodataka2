using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class PrivatnaSkolaCRUD
    {
        ModelDBContext db;
        public PrivatnaSkolaCRUD()
        {
            db = new ModelDBContext();
        }

        public bool AddPrivSk(PrivatnaSkola s)
        {
            try
            {
                db.PrivatneSkole.Add(s);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePrivSk(PrivatnaSkola s)
        {
            try
            {

                List<Kabinet> kab = db.Kabineti.Where(x => x.PrivatnaSkolaRegBroj == s.RegBroj).ToList();
                KabinetCRUD kc = new KabinetCRUD();
                foreach (Kabinet k in kab)
                {
                    kc.DeleteKabinet(k);
                }
                List<Zaposleni> zap = db.Zaposlenis.Where(x => x.PrivatnaSkolaRegBroj == s.RegBroj).ToList();
                ZaposleniCRUD zc = new ZaposleniCRUD();
                foreach(Zaposleni z in zap)
                {
                    zc.DeleteZaposleni(z);
                }

                db.PrivatneSkole.Remove(s);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<PrivatnaSkola> GetPrivatneSkole()
        {
            return db.PrivatneSkole;
        }
        public IEnumerable<Grad> GetGradovi()
        {
            return db.Gradovi;
        }
    }
}
