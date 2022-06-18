using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public interface IJump
    {

        float JumpPower { get; }
        
        void Jump(float deltaTime);
        void ChangeJumpPower(float power);

    }
}
