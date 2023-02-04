using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhienCtl : MonoBehaviour
{
    [SerializeField] private float currTime;
    [SerializeField] private float startTime;
    private BoxCollider boxCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Rocket")
        {
            gameObject.transform.localScale *= 0;
            boxCollider.enabled = false;
        }
    }

}
