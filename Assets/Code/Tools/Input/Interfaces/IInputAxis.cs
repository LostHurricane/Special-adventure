using System;

namespace SpecialAdventureInput
{
    public interface IInputAxis : IInput
    {
        event Action<float> InputOnChange;
    }
}
