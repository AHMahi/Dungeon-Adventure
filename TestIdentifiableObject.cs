using NUnit.Framework;
using SwinAdventures;

namespace IdentifiableObjectTest
{
    public class IdentifiableObjectTests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestAreYou()
        {
            IdentifiableObject sword = new IdentifiableObject(new string[]{ "sword", "sheild" });

            var result_true = sword.AreYou("sword");

            Assert.IsTrue(result_true);
        }

        [Test]
        public void TestAreYouNot()
        {
            IdentifiableObject sword = new IdentifiableObject(new string[] { "sword", "sheild" });

            var result_false = sword.AreYou("book");

            Assert.IsFalse(result_false);
        }

        [Test]
        public void TestCaseSensitivity()
        {
            IdentifiableObject sword = new IdentifiableObject(new string[] { "sword", "sheild" });

            var result_case_sensitivity = sword.AreYou("sWoRd");

            Assert.IsTrue(result_case_sensitivity);
        }

        [Test]
        public void TestFirstID()
        {
            IdentifiableObject sword = new IdentifiableObject(new string[] { "sword", "sheild"});

            var result = sword.FirstId;

            Assert.AreEqual("sword", result); // "sword" is expected value or the right answer and result is the value we are actually getting.
        }

        [Test]
        public void AddID()
        {
            IdentifiableObject sword = new IdentifiableObject(new string[] { "sword", "sheild", "shovel" });

            var result_new_add = sword.AreYou("sword");

            Assert.IsTrue(result_new_add);
        }

    }
}