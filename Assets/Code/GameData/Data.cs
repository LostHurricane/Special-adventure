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
        private List<AnimationSet> animationSets;

        public SpriteAnimatorConfig GetAnimationConfig(InteractiveObjectType type)
        {
            return animationSets.Find(animationSet => animationSet.Type == type).animatorConfig;
        }

        [Serializable]
        private struct AnimationSet
        {
            public InteractiveObjectType Type;
            public SpriteAnimatorConfig animatorConfig;
        }
    }
       
}
