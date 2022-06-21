using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class PlayerView : MonoBehaviour, IView, IRigidBody, ISpriteRenderer, IActivator
    {
        [SerializeField]
        private Collider2D _collider2D;
        public Collider2D Collider2D => _collider2D;

        [SerializeField]
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Action<InteractiveObjectType> OnInteraction { get; set; } = delegate (InteractiveObjectType type) { Debug.Log($"Collected {type}"); };

        public void Interract(InteractiveObjectType interactiveObjectType)
        {
            OnInteraction.Invoke(interactiveObjectType);
        }
    }
}
