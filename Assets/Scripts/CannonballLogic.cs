using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballLogic : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject collisionAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Life life = other.GetComponent<Life>();
        if (life != null)
        {
            if (collisionAnim != null)
            {
                GameObject anim = Instantiate(collisionAnim, transform.position, transform.rotation);
            }
            life.damage(damage);
        }
        Destroy(gameObject);
    }
}
