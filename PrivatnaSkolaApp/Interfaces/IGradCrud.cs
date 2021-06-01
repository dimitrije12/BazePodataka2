using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.Interfaces
{
    public interface IGradCrud
    {
        bool AddGrad(Grad grad);
        void DeleteGrad(Grad grad);
        void UpdateGrad(Grad grad);
        Grad GetGrad(int PostanskiBroj);
        IEnumerable<Grad> GetGradList();

    }
}
