using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private PickuppableItem pickuppableItem;
    void Start(){
        pickuppableItem = FindAnyObjectByType<PickuppableItem>();
    }
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.name == "Pelaaja")
            Debug.Log("picked up!");
            pickuppableItem.PickedUp(this.gameObject);
            
    }
}
