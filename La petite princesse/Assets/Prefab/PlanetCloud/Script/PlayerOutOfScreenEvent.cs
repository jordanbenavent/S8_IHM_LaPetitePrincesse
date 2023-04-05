using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfScreenEventArgs : EventArgs {
    public float Altitude { get; private set; }

    public PlayerOutOfScreenEventArgs(float altitude) {
        Altitude = altitude;
    }
}