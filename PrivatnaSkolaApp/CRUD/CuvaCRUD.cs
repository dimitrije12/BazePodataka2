using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class CuvaCRUD
    {
        private ModelDBContext db;
        public CuvaCRUD()
        {
            db = new ModelDBContext();
        }

        public void AddCuva(Cuva c)
        {
            try
            {
                db.Cuvas.Add(c);
                db.SaveChanges();
            }
            catch
            {

            }
        }

        public void DeleteCuva(Cuva c)
        {
            try
            {
                db.Cuvas.Remove(c);
            }
            catch
            {

            }
        }

        public IEnumerable<Cuva> GetCuvas()
        {
            return db.Cuvas;
        }
        public IEnumerable<Zaposleni> GetObezbedjenje()
        {
            return db.Zaposlenis.Where(x => x.Uloga == "Obezbedjenje");
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
