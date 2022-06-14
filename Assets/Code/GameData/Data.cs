using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "MainDataConfig", menuName = "Configs/MainDataConfig")]
    public class Data : ScriptableObject
    {
        [SerializeField]
        private List<AnimationSet> _animationSets;
        
        [SerializeField]
        private List<ObjectPrefab> _prefabs;

        public SpriteAnimatorConfig GetAnimationConfig(InteractiveObjectType type)
        {
            return _animationSets.Find(animationSet => animationSet.Type == type).animatorConfig;
        }

        public T GetPrefab <T> (string name)
        {
            return _prefabs.Find(prefab => prefab.Name == name).Prefab.GetObject<T>();
        }

        [Serializable]
        private struct AnimationSet
        {
            public InteractiveObjectType Type;
            public SpriteAnimatorConfig animatorConfig;
        }

        [Serializable]
        private struct ObjectPrefab
        {
            public String Name;
            public InGameObject Prefab;
        }
    }
       
}
