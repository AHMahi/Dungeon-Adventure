using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SwinAdventures;

namespace IdentifiableObjectTest
{
    [TestFixture()]
    public class LocationUnitTests
    {
        [Test]

        public void TestLocationIdentifyItself()
        {
            Location cave = new Location(new string[] { "new location", "cave" }, "Dark cave", "You have enter a dark cave and can see something glowing");

            Assert.AreEqual(cave.Locate("new location"), cave);
            Assert.AreEqual(cave.Locate("cave"), cave);
        }

        [Test]

        public void TestLocationCanLocateItems()
        {
            Location cave = new Location(new string[] { "new location", "cave" }, "Dark cave", "You have enter a dark cave and can see something glowing");
            Item shovel = new Item(new string[] { "shovel", "sword" }, "a shovel", "A shovel for digging");
            cave.Inventory.Put(shovel);

            Assert.AreEqual(cave.Locate("shovel"), shovel);
        }

        [Test]

        public void TestPlayerCanLocateItemInLocation()
        {
            Player player = new Player("me", "location");
            Location cave = new Location(new string[] { "new location", "cave" }, "Dark cave", "You have enter a dark cave and can see something glowing");
            Item shovel = new Item(new string[] { "shovel", "sword" }, "a shovel", "A shovel for digging");
            cave.Inventory.Put(shovel);
            player.Location = cave;

            Assert.AreEqual(player.Location.Locate("shovel"), shovel);
        }


    }
}
