using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.CRUD
{
    class ProfesorCRUD
    {
        private ModelDBContext db;
        public ProfesorCRUD()
        {
            db = new ModelDBContext();
        }

        public bool AddProfesor(Profesor p)
        {
            try
            {
                db.Zaposlenis_Profesor.Add(p);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProfesor(Profesor p)
        {
            try
            {
                db.Zaposlenis_Profesor.Remove(p);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        IEnumerable<Profesor> GetProfesors()
        {
            return db.Zaposlenis_Profesor;
        }
        IEnumerable<Zaposleni> GetZaposleni()
        {
            return db.Zaposlenis;
        }

    }
}
