using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class RigidBodyMove : IMove
    {
        public float Speed { get; private set; }

        private Rigidbody2D _rigidbody2D;
        private Vector3 _move;

        public RigidBodyMove(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            Speed = speed;
        }
        
        public void Move(Vector3 vector, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(vector.x * speed, _rigidbody2D.velocity.y, 0f);
            _rigidbody2D.velocity = _move;
            
        }

        public void ChangeSpeed(float speed) => Speed = speed;

    }
}
