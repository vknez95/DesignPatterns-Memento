using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Application
    {
        private readonly Stack<IMemento> states = new Stack<IMemento>();
        private readonly ConsoleOutput consoleOutput = new ConsoleOutput();

        public void Start()
        {
            consoleOutput.initializeOutput();
            StoreState();
            var doContinue = true;

            while (doContinue)
            {
                var value = Console.ReadLine();

                if (value == "r")
                {
                    Undo();
                }
                else if (value == "x")
                {
                    doContinue = false;
                }
                else
                {
                    consoleOutput.addValue(value);
                    StoreState();
                }
            }
        }

        private void StoreState()
        {
            var memento = consoleOutput.CreateMemento();
            states.Push(memento);
        }

        private void Undo()
        {
            if (states.Count > 1)
            {
                // discard current state
                states.Pop();
                var lastState = states.Peek();
                consoleOutput.SetMemento(lastState);
            }
            else
            {
                consoleOutput.initializeOutput();
            }
        }
    }
}
