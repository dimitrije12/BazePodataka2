using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class ZaposleniCRUD
    {
        private ModelDBContext db;
        public ZaposleniCRUD()
        {
            db = new ModelDBContext();
        }
        public bool AddZaposleni(Zaposleni z)
        {
            try
            {
                db.Zaposlenis.Add(z);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteZaposleni(Zaposleni z)
        {
            try
            {
                List<Cuva> c = db.Cuvas.Where(x => x.ObezbedjenjeJMBG_R == z.JMBG_R).ToList();
                CuvaCRUD cc = new CuvaCRUD();
                foreach (Cuva cuva in c)
                {
                    cc.DeleteCuva(cuva);
                }
                List<Cisti> cis = db.Cistis.Where(x => x.SpremacicaJMBG_R == z.JMBG_R).ToList();
                CistiCRUD cisc = new CistiCRUD();
                foreach (Cisti cuva in cis)
                {
                    cisc.DeleteCisti(cuva);
                }

                db.Zaposlenis.Remove(z);
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
