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
        internal abstract void Init(GameManager gameManager, float movementSpeed);

        public void Spawn() {
            entityObject = GameObject.Instantiate(entityPrefab);
            SetPosition(Vector3.zero);
            SetRotation(Quaternion.identity);
        }

        public void SetPosition(Vector3 position) {
            entityObject.transform.position = position;
        }

        public void SetRotation(Quaternion rotation) {
            entityObject.transform.rotation = rotation;
        }

        public void SetDirection (Vector3 dir) {
            direction = dir;
        }

        public void SetDirection ((float x, float y, float z) dir) {
            (direction.x, direction.y, direction.z) = dir;
        }
        protected void Move() {
            //entityObject.transform.position += PositionOffset();
            entityObject.transform.position = GetNextPosition();
        }

        public Vector3 GetNextPosition() {
            return entityObject.transform.position + PositionOffset();
        }

        protected Vector3 PositionOffset() {
            return direction * Time.deltaTime * speed;
        }

        internal static Vector3 GetRandomDirection() {
            Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f) + 1, UnityEngine.Random.Range(-.5f, .5f) + 1, 0).normalized;
            return randomDirection;
        }
    }
}