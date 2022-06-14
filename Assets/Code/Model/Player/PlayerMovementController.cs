using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class PlayerMovementController : IExecute, IFixedExecute
    {
        private const float _jumpThresh = 0.1f;
        private const float _movingThresh = 0.1f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _goSideWay = 0;
        private bool _jumpCommand;
        private bool _moveCommand;

        private InputController _inputController;
        private Transform _playerTransform;
        private MovementManager _movementManager;
        private AnimationStateHub _animationStateHub;



        public PlayerMovementController (InputController inputController, PlayerView view, AnimationStateHub animationStateHub)
        {
            _inputController = inputController;
            _playerTransform = view.transform;
            _animationStateHub = animationStateHub;
            _movementManager = new AnimatedMovementManager(new RigidBodyMove(view.Rigidbody, 50), new RigidBodyJump(view.Rigidbody, 1), _animationStateHub);

        }

        public void Execute(float deltaTime)
        {
            _goSideWay = _inputController.AxisHorizontal;
            _jumpCommand = _inputController.AxisVertical > _jumpThresh;
            _moveCommand = Mathf.Abs(_goSideWay) > _movingThresh;


        }

        public void FixedExecute(float deltaTime)
        {
            if (_jumpCommand)
            { 
                _movementManager.Jump(deltaTime);

            }
            else if (_moveCommand)
            {
                _movementManager.Move(Vector3.right * (_goSideWay < 0 ? -1 : 1), deltaTime);
                _playerTransform.localScale = (_goSideWay < 0 ? _leftScale : _rightScale);
            }
            else
                _animationStateHub.SetState(AnimStatePlayer.Idle);
        }
    }
}
