using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pong {
    public enum Side {
        Player1, Player2
    }
    public class PlayerInput : MonoBehaviour {
        public Side side;

        public event Action<Vector3> onPlayerInput;

        private void Start() {

        }

        private void Update() {
            if (side == Side.Player1) {
                if (Input.GetKey(KeyCode.W)) {
                    onPlayerInput?.Invoke(Vector3.up);
                } else if (Input.GetKey(KeyCode.S)) {
                    onPlayerInput?.Invoke(Vector3.down);
                } else {
                    onPlayerInput?.Invoke(Vector3.zero);
                }
            } else if (side == Side.Player2) {
                if (Input.GetKey(KeyCode.UpArrow)) {
                    onPlayerInput?.Invoke(Vector3.up);
                }
                else if (Input.GetKey(KeyCode.DownArrow)) {
                    onPlayerInput?.Invoke(Vector3.down);
                }
                else {
                    onPlayerInput?.Invoke(Vector3.zero);
                }
            }
        }
    } 
}
