using System;

namespace ConsoleApp
{
    public interface IMemento
    {
        object State { get; set; }
    }
}