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
            GPU gpu = new GPU();
            Assert.IsTrue(gpu.IsRunning);
        }

        [TestMethod]
        public void StartCPUTest()
        {
            GPU gpu = new GPU();
            CPU cpu = new CPU(gpu);
            Assert.AreEqual(cpu.CPUState, State.Paused);
        }

        [TestMethod]
        public void LoadTest()
        {
            GPU gpu = new GPU();
            CPU cpu = new CPU(gpu);
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");

            try {
                cpu.GameCart = cart;
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        [Timeout(100)]
        public void OneCycleTest()
        {
            GPU gpu = new GPU();
            CPU cpu = new CPU(gpu);
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");
            cpu.GameCart = cart;

            cpu.Execute();
            Assert.AreNotEqual(0x100, cpu.registers.PC);
        }

        [TestMethod]
        [Timeout(1200)]
        public void OneSecondTest()
        {
            GPU gpu = new GPU();
            CPU cpu = new CPU(gpu);
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");
            cpu.GameCart = cart;

            Thread thread = new Thread(new ThreadStart(cpu.ThreadStart));
            thread.Start();
            cpu.Resume();
            Thread.Sleep(1000);
            cpu.Terminate();
        }
    }
}
