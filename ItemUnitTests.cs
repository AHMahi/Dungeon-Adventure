using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SwinAdventures;

namespace IdentifiableObjectTest
{
	[TestFixture()]
	public class ItemUnitTests
	{
		[Test]
		public void TestItemIsIdentifiable()
		{
			Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "A shovel for digging");
			Assert.True(shovel.AreYou("shovel"));
		}

		[Test]
		public void TestShortDescription()
		{
			Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "A shovel for digging");
			Assert.AreEqual("a shovel (shovel)", shovel.ShortDescription);
		}

		[Test]
		public void TestFullDescription()
		{
			Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "A shovel for digging");
			Assert.AreEqual("A shovel for digging", shovel.FullDescription);
		}
	}
}
