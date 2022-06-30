using UnityEngine;

namespace SpecialAdventure
{

    public interface IProtector
    {
        void StartProtection(GameObject invader);
        void FinishProtection(GameObject invader);
    }
}