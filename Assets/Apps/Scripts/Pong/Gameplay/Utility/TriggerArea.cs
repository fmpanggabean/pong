using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pong.Gameplay {
    public class TriggerArea : RectangleArea {
        public Side side;
        public event Action<Side> onAreaEntered;

        internal void Trigger() {
            onAreaEntered?.Invoke(side);
        }
    }
}