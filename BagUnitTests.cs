using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SwinAdventures;

namespace IdentifiableObjectTest
{
    [TestFixture()]
    public class BagUnitTests
    {
        [Test]

        public void TestBagLocatesItems()
        {
            Item rifle = new Item(new string[] { "rifle" }, "a rifle", "A automatic 30 round rifle");
            Item honey = new Item(new string[] { "honey" }, "jar of honey", "A jar of honey to restore health");
            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");
            
            myBag.Inventory.Put(rifle);
            myBag.Inventory.Put(honey);

            Assert.AreEqual("rifle", myBag.Locate("rifle").FirstId);
            Assert.AreEqual("honey", myBag.Locate("honey").FirstId);
        }

        [Test]

        public void TestBagLocatesItself()
        {
            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");

            Assert.AreEqual("bag", myBag.Locate("bag").FirstId);
        }

        [Test]

        public void TestBagLocatesNothing()
        {
            Item rifle = new Item(new string[] { "rifle" }, "a rifle", "A automatic 30 round rifle");
            Item honey = new Item(new string[] { "honey" }, "jar of honey", "A jar of honey to restore health");
            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");

            myBag.Inventory.Put(rifle);
            myBag.Inventory.Put(honey);

            var nullTest = myBag.Locate("bow");
            Assert.IsNull(nullTest);           
        }

        [Test]

        public void TestBagFullDescription()
        {
            Item rifle = new Item(new string[] { "rifle" }, "a rifle", "A automatic 30 round rifle");
            Item honey = new Item(new string[] { "honey" }, "jar of honey", "A jar of honey to restore health");
            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");

            myBag.Inventory.Put(rifle);
            myBag.Inventory.Put(honey);

            var bagfulldesc = myBag.FullDescription;
            Assert.AreEqual("In the a backpack you can see: \n\ta rifle (rifle)\n\tjar of honey (honey)\n", bagfulldesc);
        }

        [Test]

        public void TestBagInBag()
        {
            Item rifle = new Item(new string[] { "rifle" }, "a rifle", "A automatic 30 round rifle");
            Item honey = new Item(new string[] { "honey" }, "jar of honey", "A jar of honey to restore health");
            Bag b1 = new Bag(new string[] { "bag1" }, "a backpack", "A small backpack to store items");
            Bag b2 = new Bag(new string[] { "bag2" }, "a backpack", "A small backpack to store items");

            b1.Inventory.Put(b2);
            b1.Inventory.Put(rifle);
            b2.Inventory.Put(honey);

            Assert.AreEqual("bag2", b1.Locate("bag2").FirstId);
            Assert.AreEqual("rifle", b1.Locate("ai").FirstId);
            Assert.IsNull(b1.Locate("honey"));
        }
    }
}
