using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Finger" && other.GetComponent<FingerManager>().isPinch)
        {
            this.transform.position = other.transform.position;
        }
    }
}
