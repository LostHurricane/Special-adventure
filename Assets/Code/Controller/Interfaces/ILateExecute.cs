namespace SpecialAdventure
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}
