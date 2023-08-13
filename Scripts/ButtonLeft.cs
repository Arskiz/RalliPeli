using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private CarMovement carMovement;

    void Start(){
        carMovement = FindAnyObjectByType<CarMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        carMovement.leftKeyPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        carMovement.leftKeyPressed = false;
    }
}
