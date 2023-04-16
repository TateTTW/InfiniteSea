using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject level1Player;
    [SerializeField]
    private GameObject level2Player;
    [SerializeField]
    private GameObject level3Player;

    public GameObject player;

    public static CurrentPlayer instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicate CurrentPlayer instance", gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradePlayer()
    {
        if (player != null && ScoreManager.instance.amount >= 100)
        {
            Player oldInfo = player.GetComponent<Player>();
            if (oldInfo != null)
            {
                GameObject prefab = oldInfo.lvl > 1 ? level3Player : level2Player;

                ScoreManager.instance.amount -= 100;

                Destroy(player);
                player = Instantiate(prefab, player.transform.position, player.transform.rotation);
                Player newInfo = player.GetComponent<Player>();
                newInfo.lvl = oldInfo.lvl + 1;

                CameraManager.instance.follow(player);
            }
        }
    }

    private void createInitPlayer()
    {
        player = Instantiate(level2Player, new Vector3(203, 0, 203), new Quaternion(0, 0, 0, 0));
        CameraManager.instance.follow(player);
    }
}
