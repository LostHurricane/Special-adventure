using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class MovementManager : IMove, IJump
    {
        public float Speed { get; private set; }
        public float JumpPower { get; private set; }

        private IMove _movementImplementation;
        private IJump _jumpingImplementation;


        public MovementManager (IMove movementImplementation, IJump jumpingImplementation)
        {
            _movementImplementation = movementImplementation;
            _jumpingImplementation = jumpingImplementation;
        }

        public virtual void Move(Vector3 vector, float deltaTime)
        {
            _movementImplementation.Move(vector, deltaTime);

            
        }

        public void ChangeSpeed(float speed)
        {
            Speed = speed;
        }

        public virtual void Jump(float deltaTime)
        {
            _jumpingImplementation.Jump(deltaTime);

            
        }

        public void ChangeJumpPower(float power)
        {
            JumpPower = power;
        }
    }
}
