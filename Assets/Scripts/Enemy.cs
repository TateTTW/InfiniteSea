using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        /*SimpleBuoyController buoyController = GetComponent<SimpleBuoyController>();
        if (buoyController != null)
        {
            buoyController.water = WaterManager.instance.water;
        }*/
    }
    void Start()
    {
        EnemyManager.instance.enemies.Add(this);
    }

    private void OnDestroy()
    {
        EnemyManager.instance.enemies.Remove(this);
    }
}
