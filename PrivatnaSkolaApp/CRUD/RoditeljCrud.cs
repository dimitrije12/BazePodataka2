using PrivatnaSkolaApp.Interfaces;
using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class RoditeljCrud : IRoditeljCrud
    {
        private ModelDBContext db;
        public RoditeljCrud()
        {
            this.db = new ModelDBContext();

        }

        public bool AddRoditelj(Roditelj roditelj)
        {
            try
            {
                db.Roditelji.Add(roditelj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRoditelj(Roditelj roditelj)
        {
            try
            {
                db.Roditelji.Remove(db.Roditelji.Find(roditelj.JMBG_Rod));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateRoditelj()
        {
            db.SaveChanges();
        }


        public Roditelj GetRoditelj(string JMBG)
        {
            return db.Roditelji.Find(JMBG) as Roditelj;
        }

        public IEnumerable<Roditelj> GetRoditeljList()
        {
            return db.Roditelji;
        }
    }
}
