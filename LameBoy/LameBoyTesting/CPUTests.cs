using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LameBoy;
using LameBoy.Graphics;
using System.Diagnostics;
using System.Threading;

namespace LameBoyTesting
{
    [TestClass]
    public class CPUTests
    {

        [TestMethod]
        public void StartGPUTest()
        {
            GameBoy gb = new GameBoy();
            Assert.IsTrue(gb.GPU.IsRunning);
        }

        [TestMethod]
        public void StartCPUTest()
        {
            GameBoy gb = new GameBoy();
            Assert.AreEqual(gb.CPU.CPUState, State.Paused);
        }

        [TestMethod]
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

        [TestMethod]
        [Timeout(100)]
        public void OneCycleTest()
        {
            GameBoy gb = new GameBoy();
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");
            gb.LoadCart(cart);

            gb.CPU.Execute();
            Assert.AreNotEqual(0x100, gb.CPU.registers.PC);
        }

        [TestMethod]
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
