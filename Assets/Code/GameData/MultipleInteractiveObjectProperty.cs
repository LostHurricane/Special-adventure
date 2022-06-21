using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "MultiInteractiveObjectConfig", menuName = "Configs/Multiple Interactive Object Config")]
    public class MultipleInteractiveObjectProperty : InteractiveObjectProperty
    {
        [SerializeField]
        private Vector3 [] _positions = new Vector3 [0];

        public Vector3[] Positions { get => _positions; }
    }
}
