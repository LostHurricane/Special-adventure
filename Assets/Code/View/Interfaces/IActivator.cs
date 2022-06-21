using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public interface IActivator
    {
        public Action<InteractiveObjectType> OnInteraction { get; set; }

        public void Interract(InteractiveObjectType interactiveObjectType);
    }
}
