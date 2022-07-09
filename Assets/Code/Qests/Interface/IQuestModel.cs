using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }

}
