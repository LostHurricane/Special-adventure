using System;

namespace SpecialAdventureInput
{
    public interface IInputBinary : IInput
    {
        event Action<bool> InputOnChange;
    }
}
