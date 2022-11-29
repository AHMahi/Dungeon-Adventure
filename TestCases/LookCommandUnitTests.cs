using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SwinAdventures;

namespace IdentifiableObjectTest
{
    public class LookCommandUnitTests
    {
        [Test]

        public void TestLookAtMe()
        {
            Player newPlayer = new Player("me", "inventory");
            LookCommand myCommand = new LookCommand(new string[] { "look" });

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "look", "at", "me" }), newPlayer.FullDescription);
        }

        [Test]

        public void TestLookAtGem()
        {
            Player newPlayer = new Player("me", "inventory");
            Item gem = new Item(new string[] { "gem" }, "Shiny Gem", "this is a gem");
            newPlayer.Inventory.Put(gem);
            LookCommand myCommand = new LookCommand(new string[] { "look" });

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "look", "at", "gem" }), gem.FullDescription);
        }

        [Test]

        public void TestLookAtUnk()
        {
            Player newPlayer = new Player("me", "inventory");
            LookCommand myCommand = new LookCommand(new string[] { "look" });
            Item gem = new Item(new string[] { "gem" }, "Shiny Gem", "this is a gem");

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "look", "at", "gem" }), "I can't find the gem");
        }

        [Test]

        public void TestLookAtGemInMe()
        {
            Player newPlayer = new Player("me", "inventory");

            LookCommand myCommand = new LookCommand(new string[] { "look" });
            Item gem = new Item(new string[] { "gem" }, "Shiny Gem", "this is a gem");

            newPlayer.Inventory.Put(gem);

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "inventory" }), gem.FullDescription); 
        }

        [Test]

        public void TestLookAtGemInBag()
        {
            Player newPlayer = new Player("me", "inventory");
            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");
            Item gem = new Item(new string[] { "gem" }, "Shiny Gem", "this is a gem");
            LookCommand myCommand = new LookCommand(new string[] { "look" });

            myBag.Inventory.Put(gem);
            newPlayer.Inventory.Put(myBag);

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }), gem.FullDescription);
        }

        [Test]

        public void TestLookAtGemInNoBag()
        {
            Player newPlayer = new Player("me", "inventory");
            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");
            Item gem = new Item(new string[] { "gem" }, "Shiny Gem", "this is a gem");
            LookCommand myCommand = new LookCommand(new string[] { "look" });

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }), "I can't find the bag");
        }

        [Test]

        public void TestLookAtNoGemInBag()
        {
            Player newPlayer = new Player("me", "inventory");
            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");
            Item gem = new Item(new string[] { "gem" }, "Shiny Gem", "this is a gem");
            LookCommand myCommand = new LookCommand(new string[] { "look" });

            newPlayer.Inventory.Put(myBag);

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }), "Can't find gem in bag");
        }

        [Test]

        public void TestInvalidLook()
        {
            Player newPlayer = new Player("me", "inventory");
            LookCommand myCommand = new LookCommand(new string[] { "look" });

            Assert.AreEqual(myCommand.Execute(newPlayer, new string[] { "Hello" }), "Error in look input");
        }
    }
}
