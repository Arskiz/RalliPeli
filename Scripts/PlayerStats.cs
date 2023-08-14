using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private CarMovement carMovement;
    private Car carScript;
    private Essentials essentials;
    private UIManager uIManager;

    [Header("Variables")]
    public float score;
    public int highScore;

    [Header("Text Objects")]
    public TextMeshProUGUI scoreAmountText;


    void Start(){
        uIManager = FindAnyObjectByType<UIManager>();
    }
    // Update is called once per frame
    void Update()
    {
        SetStuff();
        SetTexts();
        UpdateScore();
    }

    void SetStuff(){
        if(essentials == null)
            essentials = FindAnyObjectByType<Essentials>();

        if(carScript == null)
            carScript = FindAnyObjectByType<Car>();

        if(carMovement == null)
            carMovement = FindAnyObjectByType<CarMovement>();

    }

    void SetTexts(){
        if(scoreAmountText != null){
            scoreAmountText.text = ((int)score).ToString()+ " / " + highScore.ToString();
        }
    }

    void UpdateScore(){
        score += 1f * Time.deltaTime * carMovement.currentSpeed;
    }

    public void OnDied(){
        SaveValues();
    }

    public void SaveValues(){
        if(score > PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("Score", (int)score);
    }

    public void LoadSavedValues()
    {
        // Highscore
        if (PlayerPrefs.GetInt("Score") != 0)
        {
            this.highScore = PlayerPrefs.GetInt("Score");
        }

        // FPSLimit
        if(PlayerPrefs.GetInt("FPSLimit") != 0)
        {
            Application.targetFrameRate = (int)PlayerPrefs.GetFloat("FPSLimit");
            uIManager.fpsLimit.value = PlayerPrefs.GetFloat("FPSLimit");
            
        }
    }
    
}
