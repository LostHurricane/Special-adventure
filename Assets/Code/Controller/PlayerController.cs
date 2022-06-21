using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class PlayerController : IExecute, IFixedExecute
    {
        private PlayerView _playerView;

        private SpriteAnimator _spriteAnimator;
        private AnimationStateHub _animationStateHub;

        private InputController _input;
        private PlayerMovementController _playerMovementController;

        public PlayerController (Data data, InputController input, out PlayerView player)
        {
            _input = input;
            var playerInfo = data.GetObjectInfo("Player");

            var playerPrototype = playerInfo.GetPrefab <PlayerView> ();
            _playerView = new RegularFactory<PlayerView>(playerPrototype).GetObject();

            _spriteAnimator = new SpriteAnimator(playerInfo.GetAnimatorConfig());
            _animationStateHub = new AnimationStateHub();
            
            _playerMovementController = new PlayerMovementController(input, _playerView, _animationStateHub);

            player = _playerView;
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
