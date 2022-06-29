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
            controllers.Add(new PlayerController(data, inputController, out var _player));
            controllers.Add(new CameraController(_player.transform, new Vector3(0,0,-10), out var _camera));
            controllers.Add(new CollectibleController(data));
            controllers.Add(new ParalaxController(data, _camera));
            controllers.Add(new EnemyController(data));


        }
    }
}
