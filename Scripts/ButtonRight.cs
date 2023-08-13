using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private CarMovement carMovement;

    void Start(){
        carMovement = FindAnyObjectByType<CarMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        carMovement.rightKeyPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        carMovement.rightKeyPressed = false;
    }
}
