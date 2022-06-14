using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class PlayerView : MonoBehaviour, IView, IRigidBody, ISpriteRenderer
    {

        
        [SerializeField]
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;


        public void Initialise ()
        {
            if (!_rigidbody)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }

            if (!_spriteRenderer)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
        }
    }
}
