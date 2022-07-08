using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Pong.Gameplay {
    public class GameManager : MonoBehaviour {
        public float movementSpeed;
        public float ballSpeed;

        [SerializeField]
        private Player player1;
        [SerializeField]
        private Player player2;
        [SerializeField]
        private Ball ball;

        public Score score;
        public List<SolidObject> solidObjects;
        public List<TriggerArea> triggerAreas;

        private void Awake() {
            score = new Score(this);

            player1.Init(this, movementSpeed);
            player2.Init(this, movementSpeed);
            ball.Init(this, ballSpeed);

            player1.Spawn();
            player2.Spawn();
            ball.Spawn();

            solidObjects = FindObjectsOfType<SolidObject>().ToList();
            triggerAreas = FindObjectsOfType<TriggerArea>().ToList();

            SetTriggerAreaEvent();
        }

        private void SetTriggerAreaEvent() {
            foreach(TriggerArea ta in triggerAreas) {
                ta.onAreaEntered += Goal;
            }
        }

        private void Goal(Side side) {
            score.GiveScoreTo(side);
            StartCoroutine(StopGame());
        }

        private IEnumerator StopGame() {
            ball.Hide();
            yield return new WaitForSeconds(2f);
            StartGame();
        }

        private void StartGame() {
            ball.Reset();
        }

        private void Start() {

            player1.SetPosition(new Vector3(-7, 0, 0));
            player2.SetPosition(new Vector3(7, 0, 0));
            ball.SetDirection(Entity.GetRandomDirection());

            StartGame();
        }
        private void FixedUpdate() {
            player1.Update();
            player2.Update();
            ball.Update();
        }
    } 
}
