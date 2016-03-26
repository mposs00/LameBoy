using System;
using LameBoy;
using NUnit.Framework;
using System.IO;

namespace LameBoyTesting
{
    [TestFixture]
    public class CartTests
    {
        private static readonly string cartPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"..\roms\");

        public static Cart LoadCart(string name)
        {
            try
            {
                return new Cart(Path.Combine(cartPath, name));
            }
            catch (FileNotFoundException e)
            {
                Assert.Inconclusive(String.Format("The test ROM at {0} could not be found.", e.FileName));
                return null;
            }
        }

        [Test]
        public void FileLoadTest()
        {
            Cart cart = LoadCart("cpu_instrs.gb");
            Assert.IsNotNull(cart);
            Assert.IsNotNull(cart.RAM);
        }

        [Test]
        public void CartTypeTest()
        {
            Cart cart = LoadCart("cpu_instrs.gb");
            Assert.AreEqual(CartType.MBC1, cart.Type);
        }

        [Test]
        public void BadCartPathTest()
        {
            Cart cart = new Cart(Path.Combine(cartPath, "blahblahblah.gbnevertobefound"));
            Assert.IsNull(cart);
            Assert.Throws<FileNotFoundException>(_BadCartPathTestBody);
        }

        private void _BadCartPathTestBody()
        {
            Cart cart = new Cart(Path.Combine(cartPath, "blahblahblah.gbnevertobefound"));
        }
    }
}
