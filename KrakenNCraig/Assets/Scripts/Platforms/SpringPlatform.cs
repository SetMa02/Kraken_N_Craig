using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : Platform
{
    [SerializeField] private float _springPower;

    public float SpringPower => _springPower;
}
