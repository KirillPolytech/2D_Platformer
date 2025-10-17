using System;
using Platformer.Mechanics;
using UnityEngine;

[Serializable]
public struct PathData
{
    public PatrolPath PatrolPath;
    public Transform[] Paths;
}
