using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class DirektorCRUD
    {

        private ModelDBContext db;
        public DirektorCRUD()
        {
            db = new ModelDBContext();
        }
        public void UpdateData()
        {
            db.SaveChanges();
        }
        public Zaposleni GetZaposleni(string jmbg)
        {
            return db.Zaposlenis.Find(jmbg);
        }

        public void AddDirektor(Direktor s)
        {
            try
            {
                db.Zaposlenis.Add(s);
                db.SaveChanges();
            }
            catch
            {

            }
        }
        public bool DeleteDirektor(Direktor z)
        {
            try
            {
                /*
                List<Cisti> cis = db.Cistis.Where(x => x.SpremacicaJMBG_R == z.JMBG_R).ToList();
                CistiCRUD cisc = new CistiCRUD();
                foreach (Cisti cuva in cis)
                {
                    cisc.DeleteCisti(cuva);
                }
                */
                List<PraviUgovor> pu = db.PraviUgovors.Where(x => x.DirektorJMBG_R == z.JMBG_R).ToList();
                PotpisiUgovorCRUD c = new PotpisiUgovorCRUD();
                foreach(PraviUgovor p in pu)
                {
                    c.deleteUgovor(p);
                }
                db.Zaposlenis.Remove(db.Zaposlenis.Find(z.JMBG_R));
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
