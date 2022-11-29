using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SwinAdventures;

namespace IdentifiableObjectTest
{
    [TestFixture()]
    public class PlayerUnitTests
    {
        [Test]

        public void TestPlayerisIdentifiable()
        {
            Player newPlayer = new Player("me", "inventory");// since we passed in "me" and "inventory" when we made the Player object ( by passsing values via base constructor) we need to make sure
            //only "me" and "inventory" is always passed, when we call AreYou() method

            Assert.True(newPlayer.AreYou("me"));
            Assert.True(newPlayer.AreYou("inventory"));
        }

        [Test]

        public void TestPlayerLocatesItems()
        {
            
            Player newPlayer = new Player("me", "inventory");
            Item rifle = new Item(new string[] { "rifle" }, "a rifle", "This is a automatic rifle ...");
            newPlayer.Inventory.Put(rifle);

            var locate = newPlayer.Locate("rifle");

            Assert.AreEqual(rifle, locate);
        }

        [Test]

        public void TestPlayerLocatesItself()
        {
            Player newPlayer = new Player("me", "inventory");

            Assert.AreEqual(newPlayer, newPlayer.Locate("me"));
            Assert.AreEqual(newPlayer, newPlayer.Locate("inventory"));
        }

        [Test]

        public void TestPlayerLocatesNothing()
        {
            Player newPlayer = new Player("me", "inventory");
            Item rifle = new Item(new string[] { "rifle", "automatic rifle" }, "a rifle", "This is a automatic rifle ...");
            Inventory inventory = new Inventory();
            inventory.Put(rifle);

            Assert.AreEqual(null, newPlayer.Locate("sheild"));
        }

        [Test]

        public void TestPlayerFullDescription()
        {
            Player newPlayer = new Player("me", "inventory");
            newPlayer.Inventory.Put(new Item(new string[] { "rifle" }, "a rifle", "A automatic 30 round rifle"));
            newPlayer.Inventory.Put(new Item(new string[] { "shovel" }, "a shovel", "A shovel for digging"));

            string description = "You are carrying:\n" + "\ta rifle (rifle)\n" + "\ta shovel (shovel)\n";

            Assert.AreEqual(description, newPlayer.FullDescription);
        }

    }
}
