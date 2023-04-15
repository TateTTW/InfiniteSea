using Pinwheel.Poseidon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public static WaterManager instance;
    public PWater water;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicate WaterManager instance", gameObject);
        }

        if (water == null)
        {
            water = GetComponent<PWater>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
