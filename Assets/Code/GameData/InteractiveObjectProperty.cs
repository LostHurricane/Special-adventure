using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "InteractiveObjectConfig", menuName = "Configs/Interactive Object Config")]
    public class InteractiveObjectProperty : ScriptableObject
    {
        [SerializeField]
        private InGameObject _inGameObject;
        
        [SerializeField]
        private SpriteAnimatorConfig _spriteAnimatorConfig;


        public T GetPrefab<T>()
        {
            return _inGameObject ? _inGameObject.GetObject<T>() : default;
        }

        public SpriteAnimatorConfig GetAnimatorConfig()
        {
            return _spriteAnimatorConfig ? _spriteAnimatorConfig : null;
        }
    }
}
