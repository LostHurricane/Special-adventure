using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class Root : MonoBehaviour
    {
        [SerializeField]
        private LevelGeneratorView levelGeneratorView;

        private LevelGenerateController controller;

        private void Awake()
        {
            controller = new LevelGenerateController(levelGeneratorView);
            controller.Start();
        }
    }
}
