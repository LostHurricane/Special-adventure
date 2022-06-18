using System;

namespace SpecialAdventureInput
{
    public interface IActionOnInput <T> : IInput
    {
        event Action<T> InputOnChange;
    }
}
