using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class BulletText : MonoBehaviour
{
    [SerializeField]
    private FireCannonballs fireCannonballs;
    private TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Cannonballs: " + fireCannonballs.cannonballAmount.ToString();
    }
}
