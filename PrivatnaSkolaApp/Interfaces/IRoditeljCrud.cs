using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatnaSkolaApp.Interfaces
{
    public interface IRoditeljCrud
    {
        bool AddRoditelj(Roditelj roditelj);
        bool DeleteRoditelj(Roditelj roditelj);
        Roditelj GetRoditelj(string JMBG);
        IEnumerable<Roditelj> GetRoditeljList();
    }
}
