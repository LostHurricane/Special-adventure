using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public interface IQuest
    {
        public event Action<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}
