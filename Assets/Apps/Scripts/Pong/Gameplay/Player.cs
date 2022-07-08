using System;
using UnityEngine;

namespace Pong.Gameplay {
    public enum Side {
        Player1, Player2
    }
    [System.Serializable]
    internal class Player : Entity {
        private Side side;

        internal void Init(GameManager gameManager, Side side) {
            Init(gameManager);
            this.side = side;
        }

        internal override void Init(GameManager gameManager) {
            this.gameManager = gameManager;
        }

        internal override void Update() {   
            
        }
    }
}