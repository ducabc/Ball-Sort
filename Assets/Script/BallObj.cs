using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "SO/BallObj", order = 1)]
public class BallObj : ScriptableObject 
{
    public List<Sprite> balls;
}
