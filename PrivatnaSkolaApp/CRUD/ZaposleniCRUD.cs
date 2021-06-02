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


                /*
                List<Zaposleni> profesori = db.Zaposlenis.Where(a => ((a.Uloga == "Prof") && (a.JMBG_R == z.JMBG_R))).ToList();
                ProfesorCRUD pc = new ProfesorCRUD();
                foreach(Za p in profesori)
                {
                    pc.DeleteProfesor(p);
                }

                List<Obezbedjenje> ob = new List<Obezbedjenje>()


                */

                List<Drzi> d = db.Drzis.Where(x => x.DirektorJMBG_R == z.JMBG_R).ToList();
                DrziCRUD dc = new DrziCRUD();
                foreach (Drzi dd in d)
                {
                    dc.DeleteDrzi(dd);
                }
                List<PraviUgovor> pu = db.PraviUgovors.Where(x => x.DirektorJMBG_R == z.JMBG_R).ToList();
                PotpisiUgovorCRUD c = new PotpisiUgovorCRUD();
                foreach (PraviUgovor p in pu)
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
