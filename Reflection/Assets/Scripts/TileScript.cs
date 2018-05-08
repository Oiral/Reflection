﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType { Default,Hole,Goal,Block}

public class TileScript : MonoBehaviour {
    public TileConnectionsScript topPoint;
    public TileConnectionsScript bottomPoint;

    public TileType Type = TileType.Default;
}
