using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareSys
{
    public static class HardwareSys
    {
        public static void Init()
        {
            Hardware.Hardware.Init();
        }

        public static void Run()
        {
            Hardware.Hardware.Run(); 
        }
    }
}
