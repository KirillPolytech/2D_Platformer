using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime.Scripts.Buttons
{
    public class ExitButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Application.Quit);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Application.Quit);
        }
    }
}