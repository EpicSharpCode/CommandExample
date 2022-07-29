using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample.Systems
{
    internal class AudioSystem : ISystem
    {
        SystemStates.State generalState;
        AudioSystemState currentAudioSystemState;

        public AudioSystem()
        {
            currentAudioSystemState = AudioSystemState.None;
        }

        public void Toggle()
        {
            if(generalState == SystemStates.State.Off) { Console.WriteLine($"{this.ToString()} должна быть выключена"); return; }
            SetAudioSystemState(currentAudioSystemState.Next());
        }

        public void TurnOff()
        {
            currentAudioSystemState = AudioSystemState.None;
            generalState = SystemStates.State.Off;
            Console.WriteLine($"{this.ToString()} была выключена");
        }

        public void TurnOn()
        {
            generalState = SystemStates.State.On;
            Console.WriteLine($"{this.ToString()} была включена");
        }

        public void SetAudioSystemState(AudioSystemState audioSystemState)
        {
            currentAudioSystemState = audioSystemState;
            Console.WriteLine($"Нынешняя композиция: {Enum.GetName(typeof(AudioSystemState), currentAudioSystemState)}");
        }

        public SystemStates.State GetGeneralState() => generalState;
        public AudioSystemState GetCurremtAudioSystemState() => currentAudioSystemState;

        public enum AudioSystemState
        {
            None,
            Track1,
            Track2,
            Track3,
            Track4,
            Track5,
            Track6,
            Track7,
            Track8,
            Track9,
            Track10
        }

        public override string ToString()
        {
            return "Аудиосистема";
        }
    }
}
