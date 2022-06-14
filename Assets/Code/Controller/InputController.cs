using SpecialAdventureInput;
using System.Collections.Generic;

namespace SpecialAdventure
{
    public class InputController : IInitialization, IExecute, ICleanup
    {
        private HashSet<IInput> _inputs;

        private InputAxis _vertical = new InputAxis(InputNameBase.Vertical);
        private InputAxis _horizontal = new InputAxis(InputNameBase.Horizontal);
        private InputButtonPressed _fire = new InputButtonPressed(InputNameBase.Fire);

        public float AxisHorizontal { get; private set; }
        public float AxisVertical { get; private set; }
        public bool Fire { get; private set; }

        private void UpdateHorizontal(float value) => AxisHorizontal = value;
        private void UpdateVertical(float value) => AxisVertical = value;
        private void UpdateFireButton(bool value) => Fire = value;

        public InputController(out InputController inputController)
        {
            _inputs = new HashSet<IInput>();
            inputController = this;
        }

        public void Initialization()
        {
            _vertical.InputOnChange += UpdateVertical;
            _inputs.Add(_vertical);

            _horizontal.InputOnChange += UpdateHorizontal;
            _inputs.Add(_horizontal);

            _fire.InputOnChange += UpdateFireButton;
            _inputs.Add(_fire);

        }

        public void Execute(float deltaTime)
        {
            foreach (var input in _inputs)
            {
                input.GetInput();
            }
        }

        public void Cleanup()
        {
            _vertical.InputOnChange -= UpdateVertical;
            _horizontal.InputOnChange -= UpdateHorizontal;
            _fire.InputOnChange -= UpdateFireButton;



        }



    }
}
