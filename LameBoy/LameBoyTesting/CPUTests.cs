using System;
using NUnit.Framework;
using LameBoy;
using System.Threading;

namespace LameBoyTesting
{
    [TestFixture]
    public class CPUTests
    {

        [Test]
        public void StartGPUTest()
        {
            GameBoy gb = new GameBoy();
            Assert.IsTrue(gb.GPU.IsRunning);
        }

        [Test]
        public void StartCPUTest()
        {
            GameBoy gb = new GameBoy();
            Assert.AreEqual(gb.CPU.CPUState, State.Paused);
        }

        [Test]
        public void LoadTest()
        {
            GameBoy gb = new GameBoy();
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");

            try {
                gb.LoadCart(cart);
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        [Timeout(100)]
        public void OneCycleTest()
        {
            GameBoy gb = new GameBoy();
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");
            gb.LoadCart(cart);

            gb.CPU.Execute();
            Assert.AreNotEqual(0x100, gb.CPU.registers.PC);
        }

        [Test]
        [Timeout(1200)]
        public void OneSecondTest()
        {
            GameBoy gb = new GameBoy();
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");
            gb.LoadCart(cart);

            gb.Start();
            Thread.Sleep(1000);
            gb.Shutdown();
        }
    }
}
