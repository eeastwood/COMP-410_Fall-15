using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;


namespace WatermelOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
            HardwareSys.HardwareSys.Init();
        }

        protected override void Run()
        {
            HardwareSys.HardwareSys.Run(); 
        }
    }
}
