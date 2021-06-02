using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class CistiCRUD
    {
        private ModelDBContext db;
        public CistiCRUD()
        {
            db = new ModelDBContext();
        }

        public void AddCisti(Cisti c)
        {
            try
            {
                db.Cistis.Add(c);
                db.SaveChanges();
            }
            catch
            {

            }
        }

        public void DeleteCisti(Cisti c)
        {
            try
            {
                db.Cistis.Remove(c);
            }
            catch
            {

            }
        }

        public IEnumerable<Cisti> GetCistis()
        {
            return db.Cistis;
        }
        public IEnumerable<Zaposleni> GetSpremacica()
        {
            return db.Zaposlenis.Where(x => x.Uloga == "Spremacica");
        }
        public IEnumerable<Kabinet> GetKabinet()
        {
            return db.Kabineti;
        }

        public IEnumerable<PrivatnaSkola> GetPrivatneSk()
        {
            return db.PrivatneSkole;
        }
    }
}
