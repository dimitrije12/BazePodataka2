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
                db.PraviUgovors.Remove(PU);
                db.SaveChanges();
            }
            catch
            {

            }
        }

        public IEnumerable<PraviUgovor> GetAllUgovori()
        {
            return db.PraviUgovors;
        }
        public IEnumerable<Roditelj> GetRoditelj()
        {
            return db.Roditelji;
        }
        public IEnumerable<Zaposleni> GetZaposleni()
        {
            return db.Zaposlenis;
        }
    }
}
