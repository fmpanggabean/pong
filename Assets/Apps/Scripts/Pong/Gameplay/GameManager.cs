using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Gameplay {
    public class GameManager : MonoBehaviour {
        [SerializeField]
        private Player player1;
        [SerializeField]
        private Player player2;
        [SerializeField]
        private Ball ball;

        private Score score;

        private void Awake() {
            score = new Score(this);

            player1.Init(this, Side.Player1);
            player2.Init(this, Side.Player2);

            ball.Init(this);
        }
        private void Start() {
            player1.Spawn();
            player2.Spawn();
            ball.Spawn();
        }
        private void FixedUpdate() {
            player1.Update();
            player2.Update();
            ball.Update();
        }
    } 
}
