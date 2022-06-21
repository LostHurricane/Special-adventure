using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "InGameObject", menuName = "Configs /InGameObject", order = 0)]
    public class InGameObject : ScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject GetObject()
        {

            return _prefab ? _prefab : null;
        }

        public T GetObject <T> ()
        {
            return _prefab ? _prefab.GetComponent<T>() : default;
        }
    }
}
