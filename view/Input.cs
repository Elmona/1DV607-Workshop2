using System;
using System.Collections.Generic;

namespace View
{
    class Input
    {
        private string _message;
        private List<string> _choices = new List<string>();

        public Input(string message)
        {
            _message = message;
        }

        public void AddChoice(string choice)
        {
            _choices.Add(choice);
        }

        public byte Run()
        {
            byte result;
            do
            {
                byte i = 0;
                Console.WriteLine($"\n{_message}");
                _choices.ForEach(x =>
                {
                    Console.WriteLine($"{i++}) {x}");
                });
                Console.Write("= ");
            } while (!byte.TryParse(Console.ReadLine(), out result) || (result < 0 || result > _choices.Count - 1));

            return result;
        }
    }
}