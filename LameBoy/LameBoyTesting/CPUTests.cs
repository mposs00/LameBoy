using System;
using NUnit.Framework;
using LameBoy;
using System.Threading;
using System.Diagnostics;

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

        [Test]
        //[Timeout(1200)]
        public void OneSecondClockTest()
        {
            GameBoy gb = new GameBoy();
            Cart cart = CartTests.LoadCart("cpu_instrs.gb");
            gb.LoadCart(cart);

            gb.Start();
            
            Stopwatch sw = Stopwatch.StartNew();
            Thread.Sleep(1000);
            sw.Stop();
            gb.Shutdown();

            //crazy hacks needed to join thread
            ((Thread)(typeof(GameBoy).GetField("cpuThread", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(gb))).Join();

            Console.WriteLine("Total cycles: {0}", gb.CPU.TotalCycles);

            double clock = gb.CPU.TotalCycles / (sw.ElapsedMilliseconds / 1000d);
            Assert.AreEqual(0x400000, clock, 250000);
        }
    }
}
