using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float moveAmt = 12.0f;

    // Update is called once per frame
    void Update()
    {
        // camera movement
        if(Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(0, moveAmt * Time.deltaTime, 0);
        }

        if(Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(0, -moveAmt * Time.deltaTime, 0);
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(moveAmt * Time.deltaTime, 0, 0);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-moveAmt * Time.deltaTime, 0, 0);
        }

        //camera zoom controls
        if(Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0, 0, moveAmt * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.X))
        {
            transform.Translate(0, 0, -moveAmt * Time.deltaTime);
        }
    }
}
