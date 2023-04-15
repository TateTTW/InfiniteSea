using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private void Awake()
    {
        SimpleBuoyController buoyController = GetComponent<SimpleBuoyController>();
        if (buoyController != null)
        {
            buoyController.water = WaterManager.instance.water;
        }
    }
}
