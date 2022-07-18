using UnityEngine;

namespace Pong.Gameplay.UI {
    public class BaseUI : MonoBehaviour {
        protected GameManager gameManager;

        private void Awake() {
            gameManager = FindObjectOfType<GameManager>();
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
        public void Show() {
            gameObject.SetActive(true);
        }
    }
}