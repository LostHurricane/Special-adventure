using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpecialAdventure
{
    [CreateAssetMenu(fileName = "MainDataConfig", menuName = "Configs/Main Data Config")]
    public class Data : ScriptableObject
    {
        [SerializeField]
        private List<ObjectInfo> _interactiveObjects;

        //public InteractiveObjectProperty GetObjectInfo(string name)
        //{
        //    return _interactiveObjects.FirstOrDefault(interactiveObject => interactiveObject.Name == name).Property;
        //}

        public T GetObjectInfo <T>(string name) where T : ScriptableObject
        {
            var temp = _interactiveObjects.FirstOrDefault(interactiveObject => interactiveObject.Name == name).Property;
            if (temp is T config)
            {
                return config;
            }

            else 
                throw new Exception($"wrong type is required for {name}");
        }

        [Serializable]
        private struct ObjectInfo 
        {
            public string Name;
            public ScriptableObject Property;
        }
    }
       
}
