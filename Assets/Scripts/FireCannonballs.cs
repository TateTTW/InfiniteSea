using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannonballs : MonoBehaviour
{
    public int cannonballAmount;

    [SerializeField]
    private GameObject cannonball;
    [SerializeField]
    private GameObject rightCannon1;
    [SerializeField]
    private GameObject rightCannon2;
    [SerializeField]
    private GameObject rightCannon3;
    [SerializeField]
    private GameObject leftCannon1;
    [SerializeField]
    private GameObject leftCannon2;
    [SerializeField]
    private GameObject leftCannon3;
    [SerializeField]
    private ParticleSystem rightCannonFire1;
    [SerializeField]
    private ParticleSystem rightCannonFire2;
    [SerializeField]
    private ParticleSystem rightCannonFire3;
    [SerializeField]
    private ParticleSystem leftCannonFire1;
    [SerializeField]
    private ParticleSystem leftCannonFire2;
    [SerializeField]
    private ParticleSystem leftCannonFire3;

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

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rightCannon1 != null && rightCannonFire1 != null && cannonballAmount > 0)
            {
                /*cannonballAmount -= 1;*/
                rightCannonFire1.Play();
                GameObject cb = Instantiate(cannonball, rightCannon1.transform.position, rightCannon1.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(absSpeed, absSpeed, 0));
            }

            if (rightCannon2 != null && rightCannonFire2 != null && cannonballAmount > 0)
            {
                /*cannonballAmount -= 1;*/
                rightCannonFire2.Play();
                GameObject cb = Instantiate(cannonball, rightCannon2.transform.position, rightCannon2.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(absSpeed, absSpeed, 0));
            }

            if (rightCannon3 != null && rightCannon3 != null && cannonballAmount > 0)
            {
                /*cannonballAmount -= 1;*/
                rightCannonFire3.Play();
                GameObject cb = Instantiate(cannonball, rightCannon3.transform.position, rightCannon3.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(absSpeed, absSpeed, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int leftSpeed = absSpeed * -1;

            if (leftCannon1 != null && leftCannonFire1 != null && cannonballAmount > 0)
            {
                /*cannonballAmount -= 1;*/
                leftCannonFire1.Play();
                GameObject cb = Instantiate(cannonball, leftCannon1.transform.position, leftCannon1.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(leftSpeed, absSpeed, 0));
            }

            if (leftCannon2 != null && leftCannonFire2 != null && cannonballAmount > 0)
            {
                /*cannonballAmount -= 1;*/
                leftCannonFire2.Play();
                GameObject cb = Instantiate(cannonball, leftCannon2.transform.position, leftCannon2.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(leftSpeed, absSpeed, 0));
            }

            if (leftCannon3 != null && leftCannonFire3 != null && cannonballAmount > 0)
            {
                /*cannonballAmount -= 1;*/
                leftCannonFire3.Play();
                GameObject cb = Instantiate(cannonball, leftCannon3.transform.position, leftCannon3.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(leftSpeed, absSpeed, 0));
            }
        }
    }
}
