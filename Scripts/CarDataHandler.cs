using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataHandler : MonoBehaviour
{
    public CarData data;
    public Car carScript;
    private UIManager uIManager;
    public TrailRenderer[] tireMarks;
    
    void Start(){
        uIManager = FindAnyObjectByType<UIManager>();
    }

    // Function to pass out cardata
    public void SetCarData(){
        if(data != null)
            carScript.carData.GetDataByCar(data);
    }

    // Detect Collision
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Death"){
            carScript.Die();
            uIManager.playing = false;
        }
    }
}
