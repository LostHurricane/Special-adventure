using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class QuestSwitchModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.TryGetComponent<PlayerView>(out _);
        }

    }
}
