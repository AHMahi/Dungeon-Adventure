using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public class LookCommand : Command
    {
        public LookCommand(string[] idents) : base(idents) { }
       
        public override string Execute(Player p, string[] text)
        {
            string result;
           

            if (text[0].ToLower() != "look")// checks if command input is valid or not
            {
                return "Error in look input";
            }

            if (text[1].ToLower() != "at")// checks if command input is valid or not
            {
                return "What do you want to look at?";   
            }

            if (text.Length == 5)// checks if command input is valid or not
            {
                if (text[3].ToLower() != "in")
                {
                    return "What do you want to look in?";
                }               
            }

            if (text.Length == 3)
            {
                result = LookAtIn(text[2], p);

                if (result == "")
                {
                    return "I can't find the " + text[2];
                }
                else
                {
                    return result;
                }
            }

            else if (text.Length == 5)// Check container in player inventory 
            {
                IHaveInventory contain = FetchContainer(p, text[4]);
                if (contain == null)
                {
                    return "I can't find the " + text[4];
                }

                else
                {
                    result = LookAtIn(text[2], contain);
                    if (result == "")
                    {
                        return "Can't find " + text[2] + " in " + text[4];
                    }

                    else
                    {
                        return result;
                    }
                }
            }

            else
            {
                return "Command Error";// If command input is wrong
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (containerId != null)
            {
                return p.Locate(containerId) as IHaveInventory;
            }

            else
            {
                return null;
            }
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            var result = container.Locate(thingId);
            if (result != null)
            {
                return result.FullDescription;
            }
            else
            {
                return "";
            }
        }
    }
}