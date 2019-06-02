using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!open && Input.GetKeyDown("joystick button 2")) {
            transform.position -= Vector3.up * 3.8f;
            open = true;
        }
        else if(open && Input.GetKeyDown("joystick button 2")) {
            transform.position += Vector3.up * 3.8f;
            open = false;
        }
    }
}
