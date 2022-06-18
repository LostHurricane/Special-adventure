using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public interface IMove
    {
        float Speed { get; }
       
        void Move(Vector3 vector , float deltaTime);
        void ChangeSpeed(float speed);
    }
}
