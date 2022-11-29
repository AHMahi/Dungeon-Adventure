using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SwinAdventures;

namespace IdentifiableObjectTest
{
    [TestFixture()]
    public class InventoryUnitTests
    {
        [Test]

        public void TestFindItem()
        {
            Item shovel = new Item(new string[] { "shovel", "sword" }, "a shovel", "A shovel for digging");
            Inventory newInventory = new Inventory();
            newInventory.Put(shovel);
            Assert.True(newInventory.HasItem("shovel"));
        }

        [Test]

        public void TestNoItemFind()
        {
            Item shovel = new Item(new string[] { "shovel", "sword" }, "a shovel", "A shovel for digging");
            Player player = new Player("me", "inventory");
            player.Inventory.Put(shovel);
            Assert.False(player.Inventory.HasItem("spade"));
        }

        [Test]

        public void TestFetchItem()
        {
            Item shovel = new Item(new string[] { "shovel", "sword" }, "a shovel", "A shovel for digging");
            Inventory newInventory = new Inventory();
            newInventory.Put(shovel);
            Assert.AreEqual(shovel, newInventory.Fetch("shovel"));
        }

        [Test]

        public void TestTakeItem()
        {
            Item shovel = new Item(new string[] { "shovel", "sword" }, "a shovel", "A shovel for digging") ;
            Inventory newInventory = new Inventory();
            newInventory.Put(shovel);
            Assert.AreEqual(shovel, newInventory.Take("shovel"));
            Assert.IsFalse(newInventory.HasItem("shovel"));
        }

        [Test]

        public void TestItemList()
        {
            Item rifle = new Item(new string[] { "rifle" }, "a rifle", "A automatic 30 round rifle");
            Item honey = new Item(new string[] { "honey" }, "jar of honey", "A jar of honey to restore health");
            Inventory newInventory = new Inventory();
            newInventory.Put(rifle);
            newInventory.Put(honey);

            string expected_value = "\ta rifle (rifle)\n" + "\tjar of honey (honey)\n";

            Assert.AreEqual(expected_value, newInventory.ItemList);
        }

    }
    
}
