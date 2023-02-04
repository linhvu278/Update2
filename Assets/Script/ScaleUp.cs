using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    private BoxCollider boxCollider;
    private float powerupTime = 5f;
    CowndownTime countdown;
    CollisionCtl collisionCtl;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        collisionCtl = CollisionCtl.collisionCtl;
        countdown = GameObject.FindGameObjectWithTag("GameController").GetComponent<CowndownTime>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Rocket")
        {
            // gameObject.transform.localScale *= 0;
            // boxCollider.enabled = false;
            countdown.SetTime(powerupTime);
            collisionCtl.SetScaleUpTimer(powerupTime);
            Destroy(gameObject);
        }
    }
}
