using System;
using Pathfinding;

namespace SpecialAdventure
{

    public class AIPatrolPath : AIPath
    {
        public Action TargetReachedDetination;

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispatchTargetReached();
        }

        protected virtual void DispatchTargetReached()
        {
            TargetReachedDetination?.Invoke();
        }
    }
}