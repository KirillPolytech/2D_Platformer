using Game.Runtime.Scripts.Generic_FSM;
using Game.Runtime.Scripts.PlayerLogic;
using Game.Runtime.Scripts.Windows;

namespace Game.Runtime.Scripts.FSM
{
    public class LoseState : IState
    {
        private readonly WindowsController _windowsController;
        private readonly InputSystem_Actions _inputSystemActions;
        private readonly PlayerLogic.Player _player;

        public LoseState(
            WindowsController windowsController,
            InputSystem_Actions inputSystemActions,
            PlayerLogic.Player player)
        {
            _windowsController = windowsController;
            _inputSystemActions = inputSystemActions;
            _player = player;
        }

        public void Enter()
        {
            _inputSystemActions.Disable();
            _player.StateMachine.Enter<DeathState>();
            _windowsController.OpenWindow<LoseWindow>();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
        }
    }
}