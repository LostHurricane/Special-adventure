using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "QuestItemsConfig", menuName = "Configs/Quests/QuestItemsConfig")]
    public class QuestItemsConfig : ScriptableObject
    {
        [SerializeField]
        private int _id;

        [SerializeField]
        private List<int> _questItemsIdCollection;

        public int QuestId => _id;
        public List<int> QuestItemsIdCollection => _questItemsIdCollection;
    }
}
