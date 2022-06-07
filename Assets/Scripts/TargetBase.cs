using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBase : MonoBehaviour
{
    protected float minSpeed = 12;
    protected float maxSpeed = 16;
    protected float maxTorque = 10;
    protected float xRange = 4;
    protected float ySpawnPos = -5;

    protected Rigidbody targetRb;
    protected GameManager gameManager;
}
