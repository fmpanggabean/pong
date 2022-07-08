using System;
using UnityEngine;

namespace Pong.Gameplay {
    public class Score {
        private GameManager gameManager;

        public int player1;
        public int player2;

        public event Action<int, int> onScoreAdded;

        public Score(GameManager gameManager) {
            this.gameManager = gameManager;
            player1 = 0;
            player2 = 0;
        }

        internal void GiveScoreTo(Side side) {
            if (side == Side.Player1) {
                player1++;
            } else if (side == Side.Player2) {
                player2++;
            }
            onScoreAdded?.Invoke(player1, player2);
        }
    }
}