using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickuppableItem : MonoBehaviour
{
    [Header("Pickup-object's parent object, that has all the pickuppable childs in it.")]
    public List<TextMeshProUGUI> pickedUpItemText;
    public GameObject prefabItem;
    public Transform spawnPointParent;

    public List<Transform> spawnPoints;

    public List<GameObject> spawnedItems;
    private int collectedAmount;


    // Reference scripts
    private Essentials essentials;
    private Car car;
    private UIManager uIManager;
    private CarMovement carMovement;
    private AudioManager audioManager;
    float respawnTime;

    // Start is called before the first frame update
    void Start()
    {

        // Set script references to match any script found in the scene
        essentials = FindAnyObjectByType<Essentials>();
        car = FindAnyObjectByType<Car>();
        carMovement = FindAnyObjectByType<CarMovement>();
        uIManager = FindAnyObjectByType<UIManager>();
        audioManager = FindAnyObjectByType<AudioManager>();

        // Get saved tree-item collected amount
        if(PlayerPrefs.GetInt("treesCollected") != 0){
            collectedAmount = PlayerPrefs.GetInt("treesCollected");
        }

        // Set up spawnpoints list
        for (int i = 0; i < spawnPointParent.transform.childCount; i++)
        {
            spawnPoints.Add(spawnPointParent.transform.GetChild(i));
        }

        StartCoroutine(RandomSpawnCycle());
    }

    void FixedUpdate()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for(int i = 0; i < pickedUpItemText.Count; i++){
            pickedUpItemText[i].text = collectedAmount.ToString();
        }
        
    }

    IEnumerator RandomSpawnCycle()
    {
        while (true)
        {
                respawnTime = Random.Range(10, 30);
                yield return new WaitForSeconds(respawnTime);
                if(uIManager.playing)
                    SpawnItem();
        }
    }

    public void SpawnItem()
    {
        int randomSpawnPoint = Random.Range(0, spawnPoints.Count);

        GameObject itemObject = Instantiate(prefabItem, spawnPoints[randomSpawnPoint].position, Quaternion.identity, spawnPoints[randomSpawnPoint].parent);
        spawnedItems.Add(itemObject);
        
    }




    public void PickedUp(GameObject target)
    {
        collectedAmount += 1;
        if(target.tag == "tree")
            PlayerPrefs.SetInt("treesCollected", collectedAmount);
        else
            return;
        Destroy(target);
        
    }


    public void DestroyAllItems(){
        foreach(GameObject obj in spawnedItems){
            if(obj != null){
                Destroy(obj);
                spawnedItems.Remove(obj);
            }
            else
            {
                spawnedItems.Remove(obj);
            }
            
        }
    }
}
