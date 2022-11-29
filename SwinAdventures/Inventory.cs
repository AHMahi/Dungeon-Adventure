using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {

        }

        public bool HasItem(string id)//checks if the item is present in the inventory using the AreYou method of IdentifiableObject
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))// What ever id gets passed will go to AreYou method and get identified
                {
                    return true;
                }               
            }
            return false;//A class can use the methods of every other class without directly inheriting them only if there is a chained connection. Here _items object list refers to Item.cs which refers to 
        }

        public void Put(Item itm)//adds item to the inventory
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    _items.Remove(itm);
                    return itm;
                }
            }
            return null;
        }

        public Item Fetch(string id)// Locates an item present in the inventory by using AreYou() and returns
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return itm;
                }
            }
            return null;// If not present returns null
        }

        public string ItemList // need to understand this section
        {
            get
            {
                string result = "";
                foreach (Item i in _items)
                {
                    result += "\t" + i.ShortDescription + "\n";
                }
                return result;
            }
        }

    }
}
