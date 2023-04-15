using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int gold = 0;
    public int lvl = 2;

    void Start()
    {
        PlayerManager.instance.players.Add(this);
    }

    private void OnDestroy()
    {
        PlayerManager.instance.players.Remove(this);
    }
}
