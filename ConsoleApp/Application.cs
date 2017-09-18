using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Application
    {
        private readonly Stack<IMemento> undoStates = new Stack<IMemento>();
        private readonly Stack<IMemento> redoStates = new Stack<IMemento>();
        private readonly ConsoleOutput consoleOutput = new ConsoleOutput();

        public void Start()
        {
            consoleOutput.initializeOutput();
            StoreState();
            var doContinue = true;

            while (doContinue)
            {
                var value = Console.ReadLine();

                if (value == "u")
                {
                    Undo();
                }
                else if (value == "r")
                {
                    Redo();
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
            undoStates.Push(memento);
            redoStates.Clear();
        }

        private void Undo()
        {
            if (undoStates.Count > 1)
            {
                var redoState = undoStates.Pop();
                redoStates.Push(redoState);

                var lastState = undoStates.Peek();
                consoleOutput.SetMemento(lastState);
            }
            else
            {
                consoleOutput.initializeOutput();
            }
        }

        private void Redo()
        {
            if (redoStates.Count > 0)
            {
                var lastState = redoStates.Pop();
                undoStates.Push(lastState);
                consoleOutput.SetMemento(lastState);
            }
            else
            {
                consoleOutput.initializeOutput();
            }
        }
    }
}
