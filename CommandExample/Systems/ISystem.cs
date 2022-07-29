using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample.Systems
{
    internal interface ISystem
    {
        void TurnOn();
        void TurnOff();
        void Toggle();
    }
}
