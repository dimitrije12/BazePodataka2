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

        public void UpdateSkola()
        {
            db.SaveChanges();
        }
        public PrivatnaSkola GetSkola(int a)
        {
            return db.PrivatneSkole.Find(a);
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
                List<Pohadja> poh = db.Pohadjas.Where(x => x.PrivatnaSkolaRegBroj == s.RegBroj).ToList();
                PohadjaCRUD pcr = new PohadjaCRUD();
                foreach(Pohadja p in poh)
                {
                    pcr.DeletePohadja(p);
                }




                List<Kabinet> kab = db.Kabineti.Where(x => x.PrivatnaSkolaRegBroj == s.RegBroj).ToList();
                KabinetCRUD kc = new KabinetCRUD();
                foreach (Kabinet k in kab)
                {
                    kc.DeleteKabinet(k);
                }

                List<Drzi> d = db.Drzis.Where(x => x.PrivatnaSkolaRegBroj == s.RegBroj).ToList();
                DrziCRUD dc = new DrziCRUD();
                foreach(Drzi dd in d)
                {
                    dc.DeleteDrzi(dd);
                }

                

                List<Zaposleni> zap = db.Zaposlenis.Where(x => x.PrivatnaSkolaRegBroj == s.RegBroj).ToList();
                ZaposleniCRUD zc = new ZaposleniCRUD();
                foreach (Zaposleni z in zap)
                {
                    zc.DeleteZaposleni(z);

                }


                db.PrivatneSkole.Remove(db.PrivatneSkole.Find(s.RegBroj));
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
