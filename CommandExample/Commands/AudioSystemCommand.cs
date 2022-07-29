using CommandExample.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommandExample.Systems.AudioSystem;

namespace CommandExample.Commands
{
    internal class AudioSystemCommand : ICommand
    {
        AudioSystem audioSystem;
        Stack<AudioSystemState> undoStates;
        Stack<AudioSystemState> redoStates;

        public AudioSystemCommand(AudioSystem _audioSystem) 
        {
            undoStates = new Stack<AudioSystemState>();
            redoStates = new Stack<AudioSystemState>();
            audioSystem = _audioSystem;
        }

        public void Execute()
        {
            audioSystem.TurnOn();
        }

        public void Toggle()
        {
            undoStates.Push(audioSystem.GetCurremtAudioSystemState());
            audioSystem.Toggle();
            redoStates.Clear();
        }

        public void Exit()
        {
            audioSystem.TurnOff();
        }

        public void Undo()
        {
            if(undoStates.Count == 0) { return; }
            redoStates.Push(audioSystem.GetCurremtAudioSystemState());
            audioSystem.SetAudioSystemState(undoStates.Pop());
        }
        public void Redo()
        {
            if (redoStates.Count == 0) { return; }
            undoStates.Push(audioSystem.GetCurremtAudioSystemState());
            audioSystem.SetAudioSystemState(redoStates.Pop());
        }

        public override string ToString()
        {
            return "Управление Аудиосистемой";
        }

        public SystemStates.State GetGeneralState() => audioSystem.GetGeneralState();
    }
}
