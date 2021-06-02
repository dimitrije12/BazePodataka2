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
        public void UpdateKabinet()
        {
            db.SaveChanges();
        }
        public Kabinet GetKabinet(int k)
        {
            return db.Kabineti.Find(k);
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

                List<Cisti> cis = db.Cistis.Where(X => X.KabinetBroj == k.Broj).ToList();
                CistiCRUD cisc = new CistiCRUD();
                foreach (Cisti cuva in cis)
                {
                    cisc.DeleteCisti(cuva);
                }
                List<Cuva> c = db.Cuvas.Where(X => X.KabinetBroj == k.Broj).ToList();
                CuvaCRUD cc = new CuvaCRUD();
                foreach (Cuva cuva in c)
                {
                    cc.DeleteCuva(cuva);
                }
                /*
               
                */
                List<Zaposleni> zap = db.Zaposlenis.Where(x => x.PrivatnaSkolaRegBroj == k.PrivatnaSkolaRegBroj).ToList();
                ZaposleniCRUD zc = new ZaposleniCRUD();
                foreach (Zaposleni z in zap)
                {
                   
                    if (z.Uloga == "Cistacica")
                    {
                        SpremacicaCRUD sc = new SpremacicaCRUD();
                        Spremacica w = new Spremacica
                        {
                            Ime_R = z.Ime_R,
                            Prezime_R = z.Prezime_R,
                            JMBG_R = z.JMBG_R,
                            Godine = z.Godine,

                        };
                        sc.DeleteSpremacica(w);
                    }
                    else if (z.Uloga == "Obezbedjenje")
                    {
                        ObezbedjenjCRUD oc = new ObezbedjenjCRUD();
                        Obezbedjenje o = new Obezbedjenje
                        {
                            Ime_R = z.Ime_R,
                            Prezime_R = z.Prezime_R,
                            JMBG_R = z.JMBG_R,
                            Godine = z.Godine,
                        };
                        oc.DeleteObezbedjenje(o);

                    }
                    else if (z.Uloga == "Prof")
                    {

                        ProfesorCRUD prc = new ProfesorCRUD();
                        Profesor p = z as Profesor;
                       
                        prc.DeleteProfesor(p);
                    }

                }
                PredmetCRUD pc = new PredmetCRUD();
                List<Predmet> predmeti = pc.GetPredmeti().Where(x => x.KabinetBroj == k.Broj).ToList();
                foreach (Predmet p in predmeti)
                {
                    pc.DeletePredmet(p);
                }

                db.Kabineti.Remove(db.Kabineti.Find(k.Broj));
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
