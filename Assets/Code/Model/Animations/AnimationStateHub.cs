namespace SpecialAdventure
{
    public sealed class AnimationStateHub
    {
        public AnimStatePlayer CurrentState { get; private set; }

        public AnimationStateHub ()
        {
            CurrentState = AnimStatePlayer.Idle;
        }
      
        public void SetState(AnimStatePlayer animStatePlayer)
        {
            CurrentState = animStatePlayer;
        }

    }
}
