using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    private bool canRotate = false;
    public GameObject[] placeObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(canRotate == false)
            {
                canRotate = true;
                SaveScript.horizontalDirection = false;
                this.transform.Rotate(0, -90, 0);
            }
            else if (canRotate == true)
            {
                canRotate = false;
                SaveScript.horizontalDirection = true;
                this.transform.Rotate(0, -90, 0);
            }
        }
    }
}
