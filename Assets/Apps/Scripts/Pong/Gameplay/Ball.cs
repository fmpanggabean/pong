using System;

namespace Pong.Gameplay {
    [System.Serializable]
    internal class Ball : Entity {

        internal override void Init(GameManager gameManager) {
            this.gameManager = gameManager;
        }

        internal override void Update() {

        }
    }
}