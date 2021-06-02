using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class ObezbedjenjCRUD
    {
        private ModelDBContext db;
        public ObezbedjenjCRUD()
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
        public void AddObezbedjenje(Obezbedjenje s)
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
        public bool DeleteObezbedjenje(Obezbedjenje z)
        {
            try
            {
                
                List<Cuva> c = db.Cuvas.Where(x => x.ObezbedjenjeJMBG_R == z.JMBG_R).ToList();
                CuvaCRUD cc = new CuvaCRUD();
                foreach (Cuva cuva in c)
                {
                    cc.DeleteCuva(cuva);
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
