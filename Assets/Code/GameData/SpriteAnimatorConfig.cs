using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace SpecialAdventure
{
    [CreateAssetMenu (fileName = "SpriteAnimatorConfig", menuName = "Configs /Animator CFG", order = 0)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        
            

        public List<SpriteSequence> Sequences = new List<SpriteSequence>();

        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimStatePlayer Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }




    }

}
