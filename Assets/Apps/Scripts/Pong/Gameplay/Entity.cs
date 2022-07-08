using System;
using UnityEngine;

namespace Pong.Gameplay {
    internal abstract class Entity {
        protected GameManager gameManager;

        public GameObject entityPrefab;
        protected GameObject entityObject;

        protected Vector3 direction;
        protected float speed;


        internal abstract void Update();
        internal abstract void Init(GameManager gameManager);

        public void Spawn() {
            entityObject = GameObject.Instantiate(entityPrefab);
            SetPosition(Vector3.zero);
            SetRotation(Quaternion.identity);
        }

        protected void SetPosition(Vector3 position) {
            entityObject.transform.position = position;
        }

        protected void SetRotation(Quaternion rotation) {
            entityObject.transform.rotation = rotation;
        }

        protected void SetDirection (Vector3 dir) {
            direction = dir;
        }
        protected void SetDirection ((float x, float y, float z) dir) {
            (direction.x, direction.y, direction.z) = dir;
        }
        protected Vector3 Move(Transform transform) {
            return transform.position + PositionOffset();
        }
        protected Vector3 PositionOffset() {
            return direction * Time.deltaTime * speed;
        }
    }
}