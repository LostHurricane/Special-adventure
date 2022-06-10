using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class Main : MonoBehaviour
    {
        [SerializeField]
        private Data _data;

        private SpriteAnimator _spriteAnimator;

        void Start()
        {
            _spriteAnimator = new SpriteAnimator(_data.GetAnimationConfig(InteractiveObjectType.Player));

            _spriteAnimator.StartAnimation(GetComponent<SpriteRenderer>(), AnimStatePlayer.Idle, true, 7);
        }

        void Update()
        {
            _spriteAnimator.Execute(Time.deltaTime);
        }
    }
}
