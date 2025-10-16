using System.Linq;
using UnityEngine;

namespace Game.Runtime.Scripts.Windows
{
    public class WindowsController : MonoBehaviour
    {
        [SerializeField]
        protected Window[] windows;

        public Window Current { get; private set; }

        private void Start()
        {
            Current = windows.FirstOrDefault(x => x.GetType() == typeof(MainWindow));

            OpenWindow(Current);
        }

        public void OpenWindow(Window window)
        {
            foreach (Window m in windows.Where(x => x.IsOpened))
                m.Close();

            window.Open();

#if UNITY_EDITOR
            Debug.Log($"[OpenWindow] Window open: {window.GetType()} [Time: {Time.time}]");
#endif
        }

        public void OpenWindow<T>() where T : Window
        {
            foreach (Window m in windows.Where(x => x.IsOpened))
                m.Close();

            Window window = windows.FirstOrDefault(x => x.GetType() == typeof(T));

            window?.Open();

#if UNITY_EDITOR
            Debug.Log($"[OpenWindow] Window open: {window?.GetType()} [Time: {Time.time}]");
#endif
        }
    }
}