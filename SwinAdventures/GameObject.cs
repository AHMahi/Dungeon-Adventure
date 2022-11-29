using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] idents, string name, string desc) : base(idents)// idents string array gets passed to the constructor of IdentifiableObject
        {
            _description = desc;
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string ShortDescription//short description AKA the item player is carrying
        {
            get
            {
                return Name + " (" + FirstId + ")";
            }
        }

        public virtual string FullDescription// if we didn't use virtual then we would have had to make a abstract method and wouldn't have had a body an dwouldn't have been able to return _description
        {
            get
            {
                return _description;
            }
        }
    }
}
