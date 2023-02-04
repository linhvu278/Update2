using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CowndownTime : MonoBehaviour
{
    [SerializeField] private float currTime;
    [SerializeField] private float startTime;

    [SerializeField] private TextMeshProUGUI meshPro;
    // Start is called before the first frame update
    void Start()
    {
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= 1 * Time.deltaTime;
        meshPro.text = currTime.ToString("0");
        if(currTime <= 0)
        {
            currTime = 0;
        }
    }
}
