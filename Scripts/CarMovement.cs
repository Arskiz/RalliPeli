using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour
{
    private Car carScript;
    private Essentials essentials;
    private Rigidbody rb;
    private UIManager uIManager;

    [Header("Movement Variables")]
    public float currentSpeed;

    [Header("Keyboard Keys")]
    public KeyCode leftKey;
    public KeyCode rightKey;
    public bool leftKeyPressed;
    public bool rightKeyPressed;


    // Start is called before the first frame update
    void Start()
    {
        essentials = FindAnyObjectByType<Essentials>();
        carScript = FindAnyObjectByType<Car>();
        uIManager = FindAnyObjectByType<UIManager>();
    }

    // Fixed Update
    void FixedUpdate()
    {
        if (uIManager.playing)
        {
            UpdateCar();
            CarInputHandler();
            UpdateCarSpeed();
        }
    }

    
    // Update the currentCar's rigidbody by getting the current car object's rigidbody from the carScript
    void UpdateCar()
    {
        if (rb == null)
        {
            if (carScript.currentCar != null)
                rb = carScript.currentCar.GetComponent<Rigidbody>();
        }

    }

    // Handle all keyboard input for the car
    void CarInputHandler()
    {
        // A-key
        if (essentials.KeyHeldDown(leftKey) || leftKeyPressed)
        {
            RotateCar(-carScript.carData.turnForce * currentSpeed / 5);
        }

        // D-key
        if (essentials.KeyHeldDown(rightKey) || rightKeyPressed)
        {
            RotateCar(carScript.carData.turnForce * currentSpeed / 5);
        }
    }


    // Fasten the car 24/7
    void UpdateCarSpeed()
    {
        // Check that the speed doesnt get over the assigned maxSpeed-variable
        if (currentSpeed <= carScript.carData.maxSpeed)
            currentSpeed += carScript.carData.enginePower * Time.deltaTime;

        // Set the speed to the car
        if (carScript.currentCar != null)
            rb.velocity = carScript.currentCar.forward * currentSpeed;
    }

    void RotateCar(float amount)
    {
        Vector3 rotation = carScript.currentCar.eulerAngles;
        rotation.y += amount * Time.deltaTime;
        carScript.currentCar.eulerAngles = rotation;
    }



}
