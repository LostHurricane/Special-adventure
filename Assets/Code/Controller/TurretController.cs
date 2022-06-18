using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class TurretController : IExecute
    {
        private Transform _barrelPivot;
        private Transform _target;

        public TurretController (Transform pivot, Transform target)
        {
            _barrelPivot = pivot;
            _target = target;
        }


        public void Execute (float deltaTime)
        {
            var dir = _target.position - _barrelPivot.position;
            var angle = Vector3.Angle(Vector3.down, dir);
            var axis = Vector3.Cross(Vector3.down, dir);
            _barrelPivot.localRotation = Quaternion.AngleAxis(angle, axis);
        }

    }
}
