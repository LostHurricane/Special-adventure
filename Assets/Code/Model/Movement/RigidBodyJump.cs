using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class RigidBodyJump : IJump
    {
        public float JumpPower { get; private set; }

        private Rigidbody2D _rigidbody2D;

        public RigidBodyJump (Rigidbody2D rigidbody, float jumpPower)
        {
            _rigidbody2D = rigidbody;
            JumpPower = jumpPower;
        }

        public void Jump(float deltaTime)
        {
            _rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }

        public void ChangeJumpPower(float power) => JumpPower = power;

       

    }
}
