using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using Game.Runtime.Scripts.MVP;
using Game.Runtime.Scripts.Providers;
using Game.Runtime.Scripts.Windows;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.FSM
{
    public class GameStateMachine : GenericFSM
    {
        [Inject]
        public GameStateMachine(
            SignalBus signalBus,
            WindowsController windowsController,
            PlayerModel playerModel,
            GameConfig gameConfig,
            InputSystem_Actions inputs,
            PlayerLogic.Player player,
            Transform startPosition,
            EnemiesProvider enemiesProvider)
        {
            _states.Add(typeof(WinState).ToString(), new WinState(windowsController));
            _states.Add(typeof(LoseState).ToString(), new LoseState(windowsController, inputs, player));
            _states.Add(typeof(PlayState).ToString(),
                new PlayState(windowsController, playerModel, gameConfig, inputs, player, startPosition,
                    enemiesProvider));
        }
    }
}