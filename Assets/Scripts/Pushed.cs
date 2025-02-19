using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushed : MonoBehaviour
{
    public int pushes = 0;
    public int pushLimit = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Pushes = " + pushes);
        if (pushes >= pushLimit)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
