using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;


        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory(); // we can also use the "this " keyword in the constructor if there is a naming conflict
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))// here we want to return the id if the AreYou method is true.... but here we can't directly write "id" because it is already
            {// used as a parameter in the Locate method so there would be confusion while compiling. SO, we need to use the "this" keyword here.
                return this;// or maybe it refers to inventory? 

            }

            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return "You are carrying:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }

    }
}
