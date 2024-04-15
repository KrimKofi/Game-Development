using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bullet;
    // Start is called before the first frame update
    void Awake()
    {
        bullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
        float speed = 10f;
        bullet.velocity = transform.forward*speed;
    }

    private void OnTriggerEnter(Collider enter){
        Destroy(gameObject);
    }
}
