﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinwheel.Poseidon;

[ExecuteInEditMode]
public class SimpleBuoyController : MonoBehaviour
{
    public PWater water;
    public bool applyRipple;
    public float yPos;

    public void Update()
    {
        if (water == null)
            return;
        Vector3 localPos = water.transform.InverseTransformPoint(transform.position);
        localPos.y = yPos;
        localPos = water.GetLocalVertexPosition(localPos, applyRipple);

        Vector3 worldPos = water.transform.TransformPoint(localPos);
        transform.position = worldPos;
    }
}
