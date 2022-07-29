using CommandExample.Commands;
using CommandExample.Remote;
using CommandExample.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample
{
    internal class Program
    {
        public static RemotePanel remotePanel;
        static void Main(string[] args)
        {
            remotePanel = new RemotePanel();
            string input = "";
            remotePanel.AddCommand(1, new AudioSystemCommand(new AudioSystem()));

            do
            {
                DrawMainMenu();
                Console.Write("Ваш выбор: ");
                input = Console.ReadLine();
                remotePanel.SelectCommand(remotePanel.commands[int.Parse(input)]);
                Console.WriteLine();
                DrawCommandMenu();
                Console.Write("Ваш выбор: ");
                input = Console.ReadLine();
                Console.WriteLine();
                remotePanel.CallForSelectedCommand(int.Parse(input));

                Console.WriteLine();
                Console.WriteLine("Для выхода напишите Exit");
                input = Console.ReadLine();
                Console.WriteLine();
            }
            while (input != "Exit");
        }

        static void DrawMainMenu()
        {
            foreach(var command in remotePanel.commands)
            {
                Console.WriteLine($"{command.Key} - {command.Value.ToString()}. \t Состояние {Enum.GetName(typeof(SystemStates.State), command.Value.GetGeneralState())}");
            }
        }

        static void DrawCommandMenu()
        {
            Console.WriteLine($"Вы выбрали: {remotePanel.selectedCommand.ToString()}");
            Console.WriteLine("0 - Выключить");
            Console.WriteLine("1 - Включить");
            Console.WriteLine("2 - Переключить");
            Console.WriteLine("3 - Отменить последнее действие");
        }

    }
}
