using Game.Runtime.Scripts.FSM;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Runtime.Scripts.Buttons
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        private LevelStateMachine _levelStateMachine;
        private Button _button;

        [Inject]
        public void Construct(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(_levelStateMachine.Enter<PlayState>);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(_levelStateMachine.Enter<PlayState>);
        }
    }
}