using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCanvas : MonoBehaviour
{
    public static DialogCanvas instance;
    public Canvas canvas;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            canvas = GetComponent<Canvas>();
        }
        else
        {
            Debug.LogError("Duplicate Dialog Canvas instance", gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
