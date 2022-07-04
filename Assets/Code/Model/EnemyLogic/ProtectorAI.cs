using Pathfinding;
using UnityEngine;

namespace SpecialAdventure
{
    public class ProtectorAI : IProtector
    {
        private readonly EnemyView _view;
        private readonly PatrolAIModel _model;
        private readonly AIDestinationSetter _destinationSetter;
        private readonly AIPatrolPath _patrolPath;
        


        private bool _isPatrolling;

        private Transform _target;

        public ProtectorAI(EnemyView view, PatrolAIModel model, AIDestinationSetter destinationSetter, AIPatrolPath patrolPath)
        {
            _view = view;
            _model = model;
            _destinationSetter = destinationSetter;
            _patrolPath = patrolPath;

            _target = new GameObject("target").transform;
        }

        public void Init()
        {
            _patrolPath.TargetReachedDetination += OnTargetReached;
            _target.position = _model.GetNextTarget();
            _destinationSetter.target = _target;
            _isPatrolling = true;
            
        }

        public void Deinit()
        {
            _patrolPath.TargetReachedDetination -= OnTargetReached;
        }

        private void OnTargetReached()
        {
            _target.position = _isPatrolling ? _model.GetNextTarget() : _model.GetClosestTarget(_view.transform.position);

        }

        public void StartProtection(GameObject invader)
        {
            _isPatrolling = false;
            _destinationSetter.target = invader.transform;
        }

        public void FinishProtection(GameObject invader)
        {
            _isPatrolling = true;
            _target.position = _model.GetClosestTarget(_view.transform.position);
            _destinationSetter.target = _target;
        }
    }
}