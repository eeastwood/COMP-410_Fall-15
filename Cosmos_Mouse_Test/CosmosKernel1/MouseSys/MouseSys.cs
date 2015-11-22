using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;

namespace MouseSys
{
    public class MouseSys
    {
        public void Init()
        {
            MouseHardware.MouseHardware mouse = new MouseHardware.MouseHardware();
            mouse.Init(); 
        }
    }
}
