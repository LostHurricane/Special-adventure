using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class InteractiveObjectView : MonoBehaviour, ITrigger, ISpriteRenderer
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Action<IActivator, InteractiveObjectView> OnLevelObjectTriggerEnter { get ; set ; }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerView>(out var playerView))
            {
                OnLevelObjectTriggerEnter.Invoke(playerView, this);
            }
        }
    }
}
