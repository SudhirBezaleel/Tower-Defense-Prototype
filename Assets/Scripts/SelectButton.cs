using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int selectedItem;
    private GameObject placeHolder;


    private void Start()
    {
        placeHolder = GameObject.Find("PlaceHolder");
    }

    public void Selected()
    {
        SaveScript.selectedObject = selectedItem;
        placeHolder.GetComponent<PlaceScript>().SetSize();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SaveScript.canSet = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SaveScript.canSet = true;
    }

}
