using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class GetCarData
{
    [Header("Variables")]
    public float maxSpeed;
    public float enginePower;
    public float turnForce;
    public float brakeForce;

    public void GetDataByCar(CarData data)
    {
        this.maxSpeed = data.maxSpeed;
        this.enginePower = data.enginePower;
        this.turnForce = data.turnForce;
        this.brakeForce = data.brakeForce;
    }
}

public class Car : MonoBehaviour
{

    [Header("Objects & lists")]
    public Transform carsParent;
    public List<Transform> carsList;
    public List<GameObject> spawnPoints;

    public Transform currentCar;

    private UIManager uIManager;
    private PlayerStats playerStats;
    private Essentials essentials;
    private AudioManager audioManager;

    public ParticleSystem explosion;
    private CarMovement carMovement;
    // Get Car Data class instance
    public GetCarData carData = new GetCarData();



    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindAnyObjectByType<PlayerStats>();
        uIManager = FindAnyObjectByType<UIManager>();
        carMovement = FindAnyObjectByType<CarMovement>();
        audioManager = FindAnyObjectByType<AudioManager>();

        // Set cars's list by getting the children of carsParent-object
        for (int i = 0; i < carsParent.childCount; i++)
        {
            carsList.Add(carsParent.transform.GetChild(i));
        }

        // Set scripts by finding the gameobeject from the scene that has it
        essentials = FindFirstObjectByType<Essentials>();

    }

    // SpawnCar
    public void Spawn()
    {
        carMovement.currentSpeed = 0;
        playerStats.score = 0;
        if(currentCar != null){
            currentCar.gameObject.SetActive(true);
            currentCar.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count - 1)].transform.position;
            currentCar.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        
        if(audioManager.playing)
            audioManager.PlayClip(audioManager.gameMusic, true);
        carMovement.leftKeyPressed = false;
        carMovement.rightKeyPressed = false;

        foreach (TrailRenderer T in currentCar.GetComponent<CarDataHandler>().tireMarks)
        {
            T.Clear();
        }

    }

    // Constantly loop throught the carsList-list and change currentCar to the current active object
    public void UpdateCar()
    {
        // Do a loop throught the cars list
        for (int i = 0; i < carsList.Count; i++)
        {
            // Null check
            if (carsList[i].gameObject != null)
            {
                // If the current car index is active
                if (carsList[i].gameObject.activeSelf)
                {
                    // Set current car as such
                    currentCar = carsList[i];
                    // Set cardata
                    SetCarData(currentCar.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /////////// Debug \\\\\\\\\\\
        if (essentials.KeyPressed(KeyCode.Insert))
        {
            print("EngineHP: " + carData.maxSpeed);
            print("brakeForce: " + carData.brakeForce);
        }

        // Call updateCar once per frame
        if (uIManager.playing)
        {
            if (currentCar == null)
                UpdateCar();

            foreach (TrailRenderer T in currentCar.GetComponent<CarDataHandler>().tireMarks)
            {
                T.emitting = true;
            }
        }



    }

    // Set car by id
    public void SetCar(int carID)
    {
        for (int i = 0; i < carsList.Count; i++)
        {
            if (i == carID)
                essentials.SetGameObjectStatusTRUE(carsList[i].gameObject);
            else
                essentials.SetGameObjectStatusFALSE(carsList[i].gameObject);
        }
    }

    // Set Car Data
    void SetCarData(GameObject car)
    {
        if (car != null)
            car.GetComponent<CarDataHandler>().SetCarData();
    }



    // Die
    public void Die()
    {
        StartCoroutine(ExplosionTimer());
        
    }

    IEnumerator ExplosionTimer(){
        Debug.Log("Died");
        explosion.gameObject.SetActive(true);
        explosion.Play();
        yield return new WaitForSeconds(1);
        explosion.Stop();
        explosion.gameObject.SetActive(false);
        currentCar.gameObject.SetActive(false);
        playerStats.OnDied();
        uIManager.Died();
    }


}
