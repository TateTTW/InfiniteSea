using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject cannonball;
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

    private GameObject rightCannon1;
    private GameObject rightCannon2;
    private GameObject rightCannon3;
    private GameObject leftCannon1;
    private GameObject leftCannon2;
    private GameObject leftCannon3;

    private int cannonSpeed = 12;
    private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rightCannon1 = transform.Find("rightCannon1").gameObject;
        rightCannon2 = transform.Find("rightCannon2").gameObject;
        rightCannon3 = transform.Find("rightCannon3").gameObject;

        leftCannon1 = transform.Find("leftCannon1").gameObject;
        leftCannon2 = transform.Find("leftCannon2").gameObject;
        leftCannon3 = transform.Find("leftCannon3").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        frameCount++;

        Player closestPlayer = null;
        Double closestPlayerDistance = Double.NaN;
        Player[] players = PlayerManager.instance.players.ToArray();
        foreach (Player player in players)
        {
            double playerDistance = Vector3.Distance(player.transform.position, transform.position);
            if (closestPlayer == null || playerDistance < closestPlayerDistance)
            {
                closestPlayer = player;
                closestPlayerDistance = playerDistance;
            } 
        }

        if (closestPlayerDistance < 250)
        {
            Follow(closestPlayer);
        }
        
        /*if (distance< 25)
        {
            float step = Mathf.Abs(speed) / 8 * Time.deltaTime;

            Vector3 _direction = (player.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(_direction);
            rotation *= Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
        }*/
    }

    void Follow(Player player)
    {
        float adjSpeed = Mathf.Abs(speed) * Time.deltaTime;

        Vector3 rightSide = player.transform.position;
        rightSide += player.transform.TransformVector(new Vector3(20, 0, 0));

        float rightSideDistance = Vector3.Distance(transform.position, rightSide);

        Vector3 leftSide = player.transform.position;
        leftSide += player.transform.TransformVector(new Vector3(-20, 0, 0));

        float leftSideDistance = Vector3.Distance(transform.position, leftSide);

        Vector3 target = leftSideDistance > rightSideDistance ? rightSide : leftSide;

        transform.position = Vector3.MoveTowards(transform.position, target, adjSpeed);

        float distance = Vector3.Distance(transform.position, target);

        if (distance > 4)
        {
            Vector3 direction = (target - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, adjSpeed / 4);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, adjSpeed / 8);
        }

        if (distance < 3 && frameCount > 60)
        {
            frameCount = 0;
            Shoot(player);
        }
    }

    void Shoot(Player player)
    {
        float rightCannonDistance = Vector3.Distance(rightCannon1.transform.position, player.transform.position);
        float leftCannonDistance = Vector3.Distance(leftCannon1.transform.position, player.transform.position);
        int absSpeed = Mathf.Abs(cannonSpeed);
        int leftSpeed = absSpeed * -1;

        if (rightCannonDistance < leftCannonDistance)
        {
            if (rightCannon1 != null && rightCannonFire1 != null)
            {
                rightCannonFire1.Play();
                GameObject cb = Instantiate(cannonball, rightCannon1.transform.position, rightCannon1.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(absSpeed, absSpeed, 0));
            }

            if (rightCannon2 != null && rightCannonFire2 != null)
            {
                rightCannonFire2.Play();
                GameObject cb = Instantiate(cannonball, rightCannon2.transform.position, rightCannon2.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(absSpeed, absSpeed, 0));
            }

            if (rightCannon3 != null && rightCannonFire3 != null)
            {
                rightCannonFire3.Play();
                GameObject cb = Instantiate(cannonball, rightCannon3.transform.position, rightCannon3.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(absSpeed, absSpeed, 0));
            }
        }
        else if (leftCannonDistance < rightCannonDistance)
        {
            if (leftCannon1 != null && leftCannonFire1 != null)
            {
                leftCannonFire1.Play();
                GameObject cb = Instantiate(cannonball, leftCannon1.transform.position, leftCannon1.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(leftSpeed, absSpeed, 0));
            }

            if (leftCannon2 != null && leftCannonFire2 != null)
            {
                leftCannonFire2.Play();
                GameObject cb = Instantiate(cannonball, leftCannon2.transform.position, leftCannon2.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(leftSpeed, absSpeed, 0));
            }

            if (leftCannon3 != null && leftCannonFire3 != null)
            {
                leftCannonFire3.Play();
                GameObject cb = Instantiate(cannonball, leftCannon3.transform.position, leftCannon3.transform.rotation);
                Rigidbody rb = cb.GetComponent<Rigidbody>();
                rb.velocity = cb.transform.TransformVector(new Vector3(leftSpeed, absSpeed, 0));
            }
        }
    }
}
