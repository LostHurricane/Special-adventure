using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class PlayerController : IExecute, IFixedExecute
    {
        private const float _jumpThresh = 0.1f;
        private const float _movingThresh = 0.1f;

        

        private PlayerView _playerView;

        private SpriteAnimator _spriteAnimator;
        private AnimationStateHub _animationStateHub;

        private InputController _input;
        private PlayerMovementController _playerMovementController;

        public PlayerController (Data data, InputController input)
        {
            _input = input;

            var playerPrototype = data.GetPrefab<PlayerView>("Player");
            _playerView = new RegularFactory<PlayerView>(playerPrototype).GetNewObject();

            _spriteAnimator = new SpriteAnimator(data.GetAnimationConfig(InteractiveObjectType.Player));
            _animationStateHub = new AnimationStateHub();
            
            _playerMovementController = new PlayerMovementController(input, _playerView, _animationStateHub);

        }

        public void Execute(float deltaTime)
        {
            CheckAnimation();
            _spriteAnimator.Execute(deltaTime);
            _playerMovementController.Execute(deltaTime);
        }

        public void FixedExecute(float deltaTime)
        {
            _playerMovementController.FixedExecute(deltaTime);
            

        }

        private void CheckAnimation()
        {
            switch (_animationStateHub.CurrentState)
            {
                case AnimStatePlayer.Idle:
                    _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, _animationStateHub.CurrentState, true, 10);
                    break;
                case AnimStatePlayer.Run:
                    _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, _animationStateHub.CurrentState, true, 10);
                    break;
                case AnimStatePlayer.Jump:
                    _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, _animationStateHub.CurrentState, false, 7);
                    break;
            }


           

        }
    }
}
