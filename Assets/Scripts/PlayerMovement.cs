using Ink.Parsed;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private Vector2 movementValue;
    private float lookValue;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
    }

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * Mathf.Abs(speed);
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * (Mathf.Abs(speed) * (float)1.3);
    }

    // Update is called once per frame
    void Update()
    {
        float adjSpeed = Mathf.Abs(speed) * Time.deltaTime;
        float rotateSpeed = adjSpeed * (float)1.3;
        float rotationSpeed = Input.GetKey(KeyCode.W) ? rotateSpeed * (float)1.5 : rotateSpeed;


        if (Input.GetKey(KeyCode.W) && canMove)
        {
            transform.Translate(0, 0, adjSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Terrain>() != null || other.GetComponent<MerchantDialog>() != null)
        {
            transform.Translate(0, 0, 0);
            canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Terrain>() != null || other.GetComponent<MerchantDialog>() != null)
        {
            canMove = true;
        }
    }
}
