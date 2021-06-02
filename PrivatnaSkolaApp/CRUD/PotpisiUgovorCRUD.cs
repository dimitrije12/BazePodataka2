using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class PotpisiUgovorCRUD
    {
        private ModelDBContext db;
        public PotpisiUgovorCRUD()
        {
            db = new ModelDBContext();
        }

        public void addNewPotpisiUgovor(PraviUgovor PU)
        {
            try
            {
                db.PraviUgovors.Add(PU);
                db.SaveChanges();
            }
            catch
            {

            }
        }

        public void deleteUgovor(PraviUgovor PU)
        {
            try
            {
                db.PraviUgovors.Remove(db.PraviUgovors.Find(PU.UgovorBrojUgovora, PU.DirektorJMBG_R));
                db.SaveChanges();
            }
            catch
            {

            }
        }

        
        public IEnumerable<Roditelj> GetRoditeljList()
        {
            return db.Roditelji;
        }
        public IEnumerable<Zaposleni> GetZaposleni()
        {
            return db.Zaposlenis;
        }
    }
}
