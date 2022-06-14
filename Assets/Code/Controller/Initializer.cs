using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class Initializer
    {
        public Initializer(Controllers controllers, Data data)
        {
            controllers.Add(new InputController(out var inputController));
            controllers.Add(new PlayerController(data, inputController));


            

        }
    }
}
