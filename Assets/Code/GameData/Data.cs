using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "MainDataConfig", menuName = "Configs/Main Data Config")]
    public class Data : ScriptableObject
    {
        [SerializeField]
        private List<ObjectInfo> _interactiveObjects;

        public InteractiveObjectProperty GetObjectInfo(string name)
        {
            return _interactiveObjects.Find(interactiveObject => interactiveObject.Name == name).Property;
        }

        [Serializable]
        private struct ObjectInfo
        {
            public string Name;
            public InteractiveObjectProperty Property;
        }
    }
       
}
