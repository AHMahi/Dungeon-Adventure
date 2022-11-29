using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public interface IHaveInventory// In dotnet all interfaces names start with an I " A Naming convention "
    {
        GameObject Locate(string id);// needed to build loosely coupled classes, these classes, even if they are changed, they won't effect the other components/classes much.

        string Name// so these methods here won't effect others who inherit these, even if these methods are changed
        {
            get;
        }

    }
}
