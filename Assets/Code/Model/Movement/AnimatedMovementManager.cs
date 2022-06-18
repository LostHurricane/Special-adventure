using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class AnimatedMovementManager : MovementManager
    {

        private AnimationStateHub _animationStateHub;

        public AnimatedMovementManager(IMove movementImplementation, IJump jumpingImplementation , AnimationStateHub animationStateHub): base (movementImplementation, jumpingImplementation)
        {
            _animationStateHub = animationStateHub;
        }

        public override void Move(Vector3 vector, float deltaTime)
        {
            if (_animationStateHub.CurrentState != AnimStatePlayer.Run)
            {
                _animationStateHub.SetState(AnimStatePlayer.Run);
            }
            base.Move(vector, deltaTime);
            
        }

        public override void Jump(float deltaTime)
        {

            if (_animationStateHub.CurrentState != AnimStatePlayer.Jump)
            {
                Debug.Log(_animationStateHub.CurrentState);
                _animationStateHub.SetState(AnimStatePlayer.Jump);
            }
            base.Jump(deltaTime);

        }
    }
}
