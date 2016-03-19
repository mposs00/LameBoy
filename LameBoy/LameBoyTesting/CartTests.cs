using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LameBoy;
using System.IO;

namespace LameBoyTesting
{
    [TestClass]
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

        [TestMethod]
        public void FileLoadTest()
        {
            Cart cart = LoadCart("cpu_instrs.gb");
            Assert.IsNotNull(cart);
            Assert.IsNotNull(cart.RAM);
        }

        [TestMethod]
        public void CartTypeTest()
        {
            Cart cart = LoadCart("cpu_instrs.gb");
            Assert.AreEqual(CartType.MBC1, cart.Type);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BadCartPathTest()
        {
            Cart cart = new Cart(Path.Combine(cartPath, "blahblahblah.gbnevertobefound"));
            Assert.IsNull(cart);
        }
    }
}
