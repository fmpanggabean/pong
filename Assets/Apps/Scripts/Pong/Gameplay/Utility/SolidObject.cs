using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong.Gameplay {

    public class SolidObject : RectangleArea {


        internal Vector3 GetBounceDirection(Vector3 direction, Vector3 position) {
            Vector3 newDirection = direction;

            if (!IsInsideHorizontally(position)) {
                newDirection.x *= -1;
            }
            else if (!IsInsideVertically(position)) {
                newDirection.y *= -1;
            }
            return newDirection;
        }
    }

}