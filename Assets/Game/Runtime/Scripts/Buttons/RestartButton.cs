using Game.Runtime.Scripts.FSM;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Runtime.Scripts.Buttons
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private Button _button;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(_gameStateMachine.Enter<PlayState>);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(_gameStateMachine.Enter<PlayState>);
        }
    }
}