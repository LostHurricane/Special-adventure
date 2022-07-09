using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class QuestConfigurator : MonoBehaviour
    {
        [SerializeField] private QuestObjectView _singleQuestView;
        private Quest _singleQuest;

        private void Start()
        {
            _singleQuest = new Quest(_singleQuestView, new QuestSwitchModel());
            _singleQuest.Reset();

        }

        private void OnDestroy()
        {
            _singleQuest.Dispose();
        }
    }
}
