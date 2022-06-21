using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public interface ICollider
    {
        Collider2D Collider2D { get; }
    }
}
