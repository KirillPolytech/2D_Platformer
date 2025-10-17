using Game.Runtime.Scripts.Generic_FSM;
using Game.Runtime.Scripts.Windows;

namespace Game.Runtime.Scripts.FSM
{
    public class WinState : IState
    {
        private readonly WindowsController _windowsController;

        public WinState(
            WindowsController windowsController)
        {
            _windowsController = windowsController;
        }
        
        public void Enter()
        {
            _windowsController.OpenWindow<WinWindow>();
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