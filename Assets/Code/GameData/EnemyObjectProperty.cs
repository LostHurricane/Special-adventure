using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "EnemyObjectConfig", menuName = "Configs/Enemy Object Config")]
    public class EnemyObjectProperty : MultipleInteractiveObjectProperty
    {
        [SerializeField]
        private AIConfig _aIConfig;

        public AIConfig AIConfig;
    }
}
