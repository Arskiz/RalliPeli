using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CarData", menuName = "Car Data")]
public class CarData : ScriptableObject
{
    public float maxSpeed;
    public float enginePower = 1;
    public float brakeForce;
    public float turnForce;
}
