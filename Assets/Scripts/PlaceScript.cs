using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceScript : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private GameObject placeObj;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Placement", 0.1f, 0.1f);
        SetSize();
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && SaveScript.canSet == true)
        {
            Instantiate(placeObj, this.transform.position, this.transform.rotation);

        }
    }

    public void SetSize()
    {
        placeObj = GetComponent<SwitchScript>().placeObj[SaveScript.selectedObject];
    }

    
    void Placement()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 300))
        {
            if(hit.transform.gameObject.CompareTag("Terrain"))
            {
                this.transform.position = hit.point;
            }
        }
    }
}
