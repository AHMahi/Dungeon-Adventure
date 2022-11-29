using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        public Location(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
               
            }

            return _inventory.Fetch(id);

        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
  
}
