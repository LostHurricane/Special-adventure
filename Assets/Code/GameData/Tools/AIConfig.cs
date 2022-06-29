using System;
using UnityEngine;

namespace SpecialAdventure
{
    [Serializable]
    public struct AIConfig
    {
        public float Speed;
        public float MinDistanceToTarget;
        //Vector3?
        public Vector3[] Waypoints;
    }
}
