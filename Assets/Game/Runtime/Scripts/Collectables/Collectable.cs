using UnityEngine;

namespace Game.Runtime.Scripts.Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField]
        private int score;

        public int Score => score;
        
        public void Collect()
        {
            gameObject.SetActive(false);
        }
    }
}