using System;
using UnityEngine;
using Pong;

namespace Pong.Gameplay {
    [System.Serializable]
    internal class Player : Entity {
        private PlayerInput playerInput;
        public float min;
        public float max;

        internal override void Init(GameManager gameManager, float movementSpeed) {
            this.gameManager = gameManager;
            speed = movementSpeed;
            min = -4f;
            max = 4f;
        }

        new public void Spawn() {
            base.Spawn();

            GetInputComponent();
            SetEvent();
        }

        private void SetEvent() {
            playerInput.onPlayerInput += SetDirection;
        }

        private void GetInputComponent() {
            playerInput = entityObject.GetComponent<PlayerInput>();
        }

        internal override void Update() {
            if (GetNextPosition().y > min && GetNextPosition().y < max) {
                Move();
            }
        }
    }
}