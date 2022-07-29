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
        Stack<AudioSystemState> previousStates;

        public AudioSystemCommand(AudioSystem _audioSystem) 
        {
            previousStates = new Stack<AudioSystemState>();
            audioSystem = _audioSystem;
        }

        public void Execute()
        {
            audioSystem.TurnOn();
        }

        public void Toggle()
        {
            previousStates.Push(audioSystem.GetCurremtAudioSystemState());
            audioSystem.Toggle();
        }

        public void Exit()
        {
            audioSystem.TurnOff();
        }

        public void Undo()
        {
            if(previousStates.Count == 0) { return; }
            audioSystem.SetAudioSystemState(previousStates.Pop());
        }

        public override string ToString()
        {
            return "Управление Аудио Системой";
        }

        public SystemStates.State GetGeneralState() => audioSystem.GetGeneralState();
    }
}
