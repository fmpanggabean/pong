using System;
using UnityEngine;

namespace Pong.Gameplay {
    [System.Serializable]
    internal class Ball : Entity {
        private bool isActive;

        internal override void Init(GameManager gameManager, float movementSpeed) {
            this.gameManager = gameManager;
            speed = movementSpeed;
        }

        internal override void Update() {
            if (isActive) {
                Move();

                CollisionCheck();
                TriggerAreaCheck();
            }
        }

        private void TriggerAreaCheck() {
            foreach(TriggerArea ta in gameManager.triggerAreas) {
                if (ta.IsInside(GetNextPosition())) {
                    ta.Trigger();
                }
            }
        }

        private void CollisionCheck() {
            foreach(SolidObject so in gameManager.solidObjects) {
                if (so.IsInside(GetNextPosition())) {
                    direction = so.GetBounceDirection(direction, entityObject.transform.position);
                    return;
                }
            }
        }

        internal void Reset() {
            Show();

            SetPosition(Vector3.zero);
            SetDirection(Entity.GetRandomDirection());
        }

        internal void Hide() {
            isActive = false;
            entityObject.SetActive(false);
        }

        internal void Show() {
            isActive = true;
            entityObject.SetActive(true);
        }
    }
}