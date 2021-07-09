using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    float MaxSpeed { get; set; }
    float TimeToMaxAccelerate { get; set; }
    float DistanceToDecelerate { get; set; }
    float RotateSpeed { get; set; }

    void Move();

    void Rotate();
}
