using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class Main : MonoBehaviour
    {
        private Controllers _controllers;

        [SerializeField]
        private Data _data;

        void Start()
        {
            _controllers = new Controllers();
            new Initializer(_controllers, _data);

            _controllers.Initialization();

        }

        void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.deltaTime);

        }

    }
}
