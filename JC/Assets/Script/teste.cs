using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 19; i++)
        {
            if (Input.GetKeyDown("joystick button " + i.ToString()))
            {
                Debug.Log("joystick 1 button" + i.ToString());
            }
        }

    }
}
