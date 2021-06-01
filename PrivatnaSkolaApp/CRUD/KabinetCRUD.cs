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
