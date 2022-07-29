using CommandExample.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample.Remote
{
    internal class RemotePanel
    {
        public Dictionary<int, ICommand> commands { get; private set; }

        public ICommand selectedCommand { get; private set; }

        public RemotePanel()
        {
            commands = new Dictionary<int, ICommand>();
        }
        public RemotePanel(Dictionary<int, ICommand> _command) : base()
        {
            foreach (var command in _command)
            {
                commands.Add(command.Key, command.Value);
            }
        }

        public void AddCommand(int key, ICommand _command)
        {
            if(commands.ContainsKey(key)) { return; }
            commands.Add(key, _command);
        }

        public ICommand SelectCommand(ICommand _command)
        {
            selectedCommand = _command;
            return selectedCommand;
        }


        public void CallForSelectedCommand(int i)
        {
            switch (i)
            {
                case 0:
                    {
                        selectedCommand.Exit();
                        break;
                    }
                case 1:
                    {
                        selectedCommand.Execute();
                        break;
                    }
                case 2:
                    {
                        selectedCommand.Toggle();
                        break;
                    }
                case 3:
                    {
                        selectedCommand.Undo();
                        break;
                    }
            }
        }
    }
}
