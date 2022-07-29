using CommandExample.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample.Commands
{
    internal interface ICommand
    {
        void Execute();
        void Toggle();
        void Exit();
        void Undo();
        void Redo();
        SystemStates.State GetGeneralState();
    }
}
