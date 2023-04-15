using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    [SerializeField]
    private int amount;

    private void Awake()
    {
        Life life = GetComponent<Life>();
        if (life != null)
        {
            life.onDeath.AddListener(GivePoints);
        }
    }

    private void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }
}
