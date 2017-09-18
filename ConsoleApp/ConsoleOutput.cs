using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class ConsoleOutput
    {
        private List<string> outputValues = new List<string>();

        public void initializeOutput()
        {
            Console.Clear();
            printValues();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Type 'x' to exit, 'u' to undo, 'r' to redo");
            Console.WriteLine("Type some word:");
        }

        public void addValue(string value)
        {
            outputValues.Add(value);
            initializeOutput();
        }

        public IMemento CreateMemento()
        {
            IEnumerable<string> state = outputValues.ToList();
            return new ConsoleOutputMemento() { State = state };
        }

        public void SetMemento(IMemento memento)
        {
            outputValues = ((List<string>)memento.State).ToList();

            initializeOutput();
        }

        public class ConsoleOutputMemento : IMemento
        {
            public object State { get; set; }
        }

        private void printValues()
        {
            foreach (string value in outputValues)
            {
                Console.Write(value + " ");
            }
        }
    }
}