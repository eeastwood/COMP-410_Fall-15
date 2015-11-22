using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;

namespace MouseHardware
{
    public class MouseHardware
    {
        protected Mouse mouse; 

        public MouseHardware ()
        {
            mouse = new Mouse(); 
        }

        public void Init()
        {
            mouse.Initialize(320, 200); 
        }
    }
}
