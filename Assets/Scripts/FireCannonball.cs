using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannonball : MonoBehaviour
{
    public int cannonballAmount;

    [SerializeField]
    private GameObject cannonball;
    [SerializeField]
    private GameObject cannon;
    [SerializeField]
    private ParticleSystem cannonFire;

    private int speed = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        int absSpeed = Mathf.Abs(speed);

        if (cannon != null && cannonFire != null && cannonballAmount > 0)
        {
            /*cannonballAmount -= 1;*/
            cannonFire.Play();
            GameObject cb = Instantiate(cannonball, cannon.transform.position, cannon.transform.rotation);
            Rigidbody rb = cb.GetComponent<Rigidbody>();
            rb.velocity = cb.transform.TransformVector(new Vector3(absSpeed, absSpeed, 0));
        }
    }
}
