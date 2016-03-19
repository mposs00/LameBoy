using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LameBoy;

namespace LameBoyTesting
{
    [TestClass]
    public class MemoryTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Memory mem = new Memory(65536);
            Assert.IsNotNull(mem);
        }

        [TestMethod]
        public void Read8Test()
        {
            Memory mem = new Memory(65536);
            Assert.AreEqual(mem.Read8(0), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Read8OutOfBoundsTest()
        {
            Memory mem = new Memory(65536);
            mem.Read8(65536);
        }

        public void Write8Test()
        {
            Memory mem = new Memory(65536);
            mem.Write8(1, 0x0D);
            Assert.AreEqual(mem.Read8(1), 0x0D);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Write8OutOfBoundsTest()
        {
            Memory mem = new Memory(65536);
            mem.Write8(65536, 0x88);
        }

        public void Read16Test()
        {
            Memory mem = new Memory(65536);
            mem.Write8(1, 0x45);
            mem.Write8(2, 0x61);

            Assert.AreEqual(mem.Read16(1), (ushort)0x4561);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Read16OutOfBoundsTest()
        {
            Memory mem = new Memory(65536);
            mem.Read16(65535);
        }

        public void Write16Test()
        {
            Memory mem = new Memory(65536);
            mem.Write16(4, 0xFBA4);

            Assert.AreEqual(mem.Read16(4), (ushort)0xFBA4);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Write16OutOfBoundsTest()
        {
            Memory mem = new Memory(65536);
            mem.Write16(65535, 0x994F);
        }

        [TestMethod]
        public void CopyTest()
        {
            Memory mem1 = new Memory(65536);
            mem1.Write16(32768, 0xAFA5);

            Memory mem2 = new Memory(65536);
            mem2.Write16(32764, 0x44F6);

            mem1.CopyInto(mem2);

            Assert.AreEqual(mem1, mem2);
        }

        [TestMethod]
        public void LengthTest()
        {
            Memory mem = new Memory(465789);
            Assert.AreEqual(mem.Length, 465789);
        }
    }
}
