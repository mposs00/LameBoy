using System;
using LameBoy.Graphics;
using System.IO;
using System.Text;
using System.Threading;

namespace LameBoy
{
    public class CPU
    {
        public Registers registers = new Registers { PC = 0x100 };

        private Cart _gameCart;
        public Cart GameCart {
            get
            {
                return _gameCart;
            }
            set
            {
                _gameCart = value;
                gpu.SetCart(_gameCart);
            }
        }

        GPU gpu;
        byte instr;
        bool debugOut = false;

        private State _cpustate;
        public State CPUState {
            get
            {
                return _cpustate;
            }
            private set
            {
                _cpustate = value;
                StateChange(this, new EventArgs());
            }
        }

        public event EventHandler StateChange = delegate { };

        public CPU(GPU gpu)
        {
            this.gpu = gpu;
            //Thread sdlThread = new Thread(new ThreadStart(sdlt.Render));
            CPUState = State.Paused;
        }

        public void SetScale(int scale)
        {
            gpu.SetScale(scale);
        }

        public void VblankInterrupt()
        {
            //gpu.SetCPUExecutionState(true);
            registers.Immediate16 = 0x0040;
            var opcode = OpcodeTable.Table[0xCD];
            opcode.Execute(ref registers, GameCart.RAM);
            //gpu.SetCPUExecutionState(false);
        }

        public void ThreadStart()
        {
            CPUState = State.Paused;
            ThreadLoop();
        }

        public void ThreadLoop()
        {
            while (true)
            {
                if ((CPUState & State.Stopping) != 0)
                {
                    //Set running flag to 0
                    CPUState &= ~State.Running;
                    break;
                }

                if (CPUState != State.Running)
                {
                    Thread.Sleep(50);
                    continue;
                }

                Execute();
            }

            CPUState = State.Stopped;
            gpu.SetCPUExecutionState(CPUState);
        }

        public void Terminate()
        {
            CPUState |= State.Stopping;
            gpu.SetCPUExecutionState(CPUState);
        }

        public void Pause()
        {
            CPUState = State.Paused;
            gpu.SetCPUExecutionState(CPUState);
        }

        public void Resume()
        {
            CPUState = State.Running;
            gpu.SetCPUExecutionState(CPUState);
        }

        //Main interpreter loop
        public void Execute()
        {
            StringBuilder sb = new StringBuilder();

            while (gpu.drawing) { }

            gpu.SetCPUExecutionState(State.Running);
            instr = GameCart.Read8(registers.PC);
            var opcode = OpcodeTable.Table[instr];
            registers.Immediate8 = GameCart.Read8(registers.PC + 1);
            registers.Immediate16 = GameCart.Read16(registers.PC + 1);

            //debug output
            if (debugOut)
            {
                string disasm = opcode.Disassembly;
                if (disasm.Contains("X4"))
                    disasm = String.Format(disasm, registers.Immediate16);
                else if (disasm.Contains("X2"))
                    disasm = String.Format(disasm, registers.Immediate8);
                if(disasm.Contains("X2"))
                    disasm = String.Format(disasm, registers.A);
                sb.Clear();
                sb.Append("PC: $");
                sb.Append(registers.PC.ToString("X4"));
                sb.Append(" Disasm: ");
                sb.Append(disasm);
                sb.Append(" Opcode: ");
                sb.Append(instr.ToString("X2"));
                sb.Append("\n");
                File.AppendAllText(@"log.txt", sb.ToString());
            }
            if (opcode.Disassembly.Contains("UNIMP"))
            {
                string disasm = opcode.Disassembly;
                if (disasm.Contains("X4"))
                    disasm = String.Format(disasm, registers.Immediate16);
                else if (disasm.Contains("X2"))
                    disasm = String.Format(disasm, registers.Immediate8);
                //debugOut = true;
                Console.WriteLine("Unimplemented opcode: {0:X2}", instr);
                Console.WriteLine("PC: ${0:X4} Disasm: {1} Opcode: {2:X2}", registers.PC, disasm, instr);
                //Console.ReadLine();
            }

            registers.PC += opcode.Length;
            opcode.Execute(ref registers, GameCart.RAM);
            //gpu.SetCPUExecutionState(false);
            if (gpu.GetYCounter() == 154 && registers.Interrupts)
            {
                VblankInterrupt();
            }
            if (CPUState == State.Paused)
                gpu.SetCPUExecutionState(State.Paused);
        }
    }
}
