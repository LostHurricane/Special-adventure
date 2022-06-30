using UnityEngine;

namespace SpecialAdventure
{
    public class PatrolAIModel
    {
        private readonly Vector3[] _waypoints;
        private int _currentPointIndex;

        public PatrolAIModel(Vector3[] waypoints)
        {
            _waypoints = waypoints;
            _currentPointIndex = 0;
        }

        public Vector3 GetNextTarget()
        {
            if (_waypoints == null)
                throw new System.Exception("empty array GetNextTarget");

            _currentPointIndex = (_currentPointIndex + 1) % _waypoints.Length;
            return _waypoints[_currentPointIndex];
        }

        public Vector3 GetClosestTarget(Vector2 fromPosition)
        {
            if (_waypoints == null)
                throw new System.Exception("empty array ClosestTarget");


            var closestIndex = 0;
            var closestDistance = 0.0f;

            for (var i = 0; i < _waypoints.Length; i++)
            {
                var distance = Vector2.Distance(fromPosition, _waypoints[i]);

                if (closestDistance > distance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
            _currentPointIndex = closestIndex;
            return _waypoints[_currentPointIndex];
        }
    }
}