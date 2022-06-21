using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public interface ITrigger: IView
    {
        public Action<IActivator, InteractiveObjectView> OnLevelObjectTriggerEnter { get; set; }

    }
}
