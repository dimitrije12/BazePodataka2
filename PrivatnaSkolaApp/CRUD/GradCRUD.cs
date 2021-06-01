using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivatnaSkolaApp.Interfaces;
using ProjekatBP;
namespace PrivatnaSkolaApp.CRUD
{
    class GradCRUD : IGradCrud
    {
        private ModelDBContext dataBase;
        public GradCRUD()
        {
            dataBase = new ModelDBContext();
        }

        public bool AddGrad(Grad grad)
        {
            try
            {
                dataBase.Gradovi.Add(grad);
                dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void DeleteGrad(Grad grad)
        {
            PrivatnaSkolaCRUD pscrud = new PrivatnaSkolaCRUD();
            List<PrivatnaSkola> skole = pscrud.GetPrivatneSkole().Where(x => x.GradPostanskiBroj == grad.PostanskiBroj).ToList();
            foreach(PrivatnaSkola s in skole)
            {
                pscrud.DeletePrivSk(s);
            }

            ZiviCRUD zcrud = new ZiviCRUD();
            List<Zivi> z = zcrud.GetAllZivi().Where(x => x.GradPostanskiBroj == grad.PostanskiBroj).ToList();
            foreach(Zivi zi in z)
            {
                zcrud.DeleteZivi(zi);
            }

            dataBase.Gradovi.Remove(grad);
            dataBase.SaveChanges();
        }

        public Grad GetGrad(int PostanskiBroj)
        {
            return dataBase.Gradovi.Find(PostanskiBroj) as Grad;
        }

        public IEnumerable<Grad> GetGradList()
        {
            return dataBase.Gradovi;
        }

        public void UpdateGrad(Grad grad)
        {
            throw new NotImplementedException();
        }
    }
}
