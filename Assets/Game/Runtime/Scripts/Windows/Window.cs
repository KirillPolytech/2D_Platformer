using UnityEngine;

namespace Game.Runtime.Scripts.Windows
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField]
        private bool isOpened;

        public bool IsOpened => isOpened;

        public void Open()
        {
            isOpened = true;
            gameObject.SetActive(true);
        }

        public void Close()
        {
            isOpened = false;
            gameObject.SetActive(false);
        }
    }
}