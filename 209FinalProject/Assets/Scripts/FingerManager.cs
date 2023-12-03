using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    public bool isPinch;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(type == 1 && other.tag == "Left")
        {
            isPinch = true;
        }
        if(type == 2 && other.tag == "Right")
        {
            isPinch = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (type == 1 && other.tag == "Left")
        {
            isPinch = false;
        }
        if (type == 2 && other.tag == "Right")
        {
            isPinch = false;
        }
    }
}
