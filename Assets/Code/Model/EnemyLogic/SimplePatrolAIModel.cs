using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class SimplePatrolAIModel
    {
        private readonly AIConfig _config;
        private Vector3 _target;
        private int _currentPointIndex;

        public SimplePatrolAIModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWaypoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var distance = Vector2.Distance(_target, fromPosition);

            if (distance <= _config.MinDistanceToTarget)
                _target = GetNextWaypoint();

            var direction = ((Vector2)_target - fromPosition).normalized;
            return _config.Speed * direction;
        }

        private Vector3 GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.Waypoints.Length;
            return _config.Waypoints[_currentPointIndex];
        }
    }
}
