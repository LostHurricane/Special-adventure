using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class RegularFactory <T> : IFactory <T> where T: Object
    {
        private T _example;

        public RegularFactory (T example)
        {
            _example = example;
        }

        public T GetNewObject()
        {
            var temp = Object.Instantiate(_example);
            return temp;
        }

        
    }
}
