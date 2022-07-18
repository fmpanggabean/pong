using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pong.Gameplay.UI {
    public class ScoreUI : BaseUI {
        public TMP_Text player1Text;
        public TMP_Text player2Text;

        private void Start() {
            gameManager.score.OnScoreAdded += SetScore;
        }
        public void SetScore(int p1, int p2) {
            player1Text.text = p1.ToString();
            player2Text.text = p2.ToString();
        }
    } 
}
