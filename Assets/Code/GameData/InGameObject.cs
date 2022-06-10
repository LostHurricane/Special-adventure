using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class InGameObject : ScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        public GameObject GetObject()
        {
            return _prefab;
        }

        public T GetObject <T> ()
        {
            return _prefab.GetComponent<T>();
        }
    }
}
