using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Gameplay {
    public class RectangleArea : MonoBehaviour {
        protected float x;
        protected float y;
        protected float width;
        protected float height;


        public void SetDimension() {
            (x, y) = (transform.position.x, transform.position.y);
            (width, height) = (transform.localScale.x, transform.localScale.y);
        }
        public bool IsInside(Vector3 position) {
            SetDimension();

            if (IsInsideVertically(position) && IsInsideHorizontally(position)) {
                return true;
            }
            return false;
        }

        public bool IsInsideHorizontally(Vector3 position) {
            if (position.x > MinX() && position.x < MaxX()) {
                return true;
            }
            return false;
        }

        private float MaxX() {
            return x + (width / 2);
        }

        private float MinX() {
            return x - (width / 2);
        }

        public bool IsInsideVertically(Vector3 position) {
            if (position.y > MinY() && position.y < MaxY()) {
                return true;
            }
            return false;
        }

        private float MaxY() {
            return y + (height / 2);
        }

        private float MinY() {
            return y - (height / 2);
        }
    } 
}
