using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private Essentials essentials;
    private UIManager uIManager;

    [Header("Contents for subcategories")]
    public GameObject carsContent;
    public GameObject powerUpContent;
    public GameObject upgradeContent;

    [Header("Sub Category-Buttons")]
    public GameObject carsContentB;
    public GameObject powerUpContentB;
    public GameObject upgradeContentB;

    private Button carsContentButton;
    private Button powerUpContentButton;
    private Button upgradeContentButton;

    // Start is called before the first frame update
    void Start()
    {
        essentials = FindAnyObjectByType<Essentials>();
        uIManager = FindAnyObjectByType<UIManager>();

        // Set up components
        carsContentButton = carsContentB.GetComponent<Button>();
        powerUpContentButton = powerUpContentB.GetComponent<Button>();
        upgradeContentButton = upgradeContentB.GetComponent<Button>();
    }


    public void BackButton(){
        essentials.SwitchMenu(uIManager.shopScreen, uIManager.playScreen);
    }


    public void Category1(){
        essentials.SwitchMenu(powerUpContent, upgradeContent, carsContent);
        essentials.SetButtonInteractable(carsContentButton, false);  
        essentials.SetButtonInteractable(powerUpContentButton, upgradeContentButton, true);
                        
        essentials.SetGameObjectStatusTRUE(carsContent);
        essentials.SetGameObjectStatusFALSE(upgradeContent);
        essentials.SetGameObjectStatusFALSE(powerUpContent);
    }

    public void Category2(){
        essentials.SwitchMenu(powerUpContent, upgradeContent, carsContent);
        essentials.SetButtonInteractable(powerUpContentButton, false);  
        essentials.SetButtonInteractable(carsContentButton, upgradeContentButton, true);

        essentials.SetGameObjectStatusFALSE(carsContent);
        essentials.SetGameObjectStatusFALSE(upgradeContent);
        essentials.SetGameObjectStatusTRUE(powerUpContent);
    }

    public void Category3(){
        essentials.SwitchMenu(powerUpContent, upgradeContent, carsContent);
        essentials.SetButtonInteractable(upgradeContentButton, false);  
        essentials.SetButtonInteractable(powerUpContentButton, carsContentButton, true);
                
        essentials.SetGameObjectStatusFALSE(carsContent);
        essentials.SetGameObjectStatusTRUE(upgradeContent);
        essentials.SetGameObjectStatusFALSE(powerUpContent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
