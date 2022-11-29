using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();//here this is acting as my attribute which will know about the objects
        //here every info is stored but initially its empty
        public IdentifiableObject (string[] idents)//constructor, basically adding a bunch of ideantifier here.
        //We fill the indetifier list with various objects which needs to identified in the game. Basically we add identifiable objects here which is passed on to the List to get identified.
        {
            foreach (string i in idents)
            {
                AddIdentifier(i);
            }
        }
         
        public bool AreYou(string id)//checks if passed in value is already available in the list or not
        // we add a value and call this method then it checks if that value is present in the list or not
        {
            foreach (string i in _identifiers)
            {
                if(i == id.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public string FirstId
        {
            get
            {
                return _identifiers.First();
            }
        }

        public void AddIdentifier (string id)
        {
            _identifiers.Add(id.ToLower());// before storing on the list we make sure every object is in lowercase
        }
    }
}
