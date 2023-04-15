using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = this.GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPlayer.instance.player != null)
        {
            Life targetLife = CurrentPlayer.instance.player.GetComponent<Life>();
            if (targetLife != null)
            {
                image.fillAmount = targetLife.health / targetLife.fullHealth;
            }
        }
    }
}
