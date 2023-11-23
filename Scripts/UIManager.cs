
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject playScreen;
    public GameObject gameUIScreen;
    public GameObject deathScreen;
    public GameObject settingsScreen;
    public GameObject shopScreen;

    public bool playing;
    public TextMeshProUGUI oldHighScoreText;
    public TextMeshProUGUI highScoreText;
    public List<string> bullyWordsList;

    private Essentials essentials;
    private PlayerStats playerStats;
    private Car carScript;
    private AudioManager audioManager;
    private CarMovement carMovement;

    [Header("Graphics")]
    public Slider fpsLimit;
    public TextMeshProUGUI fpsAmountText;
    public Toggle fpsCounter;
    public TextMeshProUGUI fpsCounterText;
    public TextMeshProUGUI speedCounterText;


    void Start()
    {
        if (PlayerPrefs.GetInt("Score") != 0)
            oldHighScoreText.text = "Old Highscore: " + PlayerPrefs.GetInt("Score");
        else
        {
            oldHighScoreText.text = "No Highscore!";
        }



        playerStats = FindAnyObjectByType<PlayerStats>();
        carMovement = FindAnyObjectByType<CarMovement>();
        essentials = FindAnyObjectByType<Essentials>();
        carScript = FindAnyObjectByType<Car>();
        audioManager = FindAnyObjectByType<AudioManager>();

        if (audioManager.playing)
            audioManager.PlayClip(audioManager.idleClip, true);
        playScreen.SetActive(true);
        deathScreen.SetActive(false);
        gameUIScreen.SetActive(false);
        settingsScreen.SetActive(false);
        shopScreen.SetActive(false);

        if (PlayerPrefs.GetInt("FPSCounter") == 0)
        {
            fpsCounter.isOn = false;
        }
        else if (PlayerPrefs.GetInt("FPSCounter") == 1)
        {
            fpsCounter.isOn = true;
        }

        if (PlayerPrefs.GetFloat("FPSLimit") != 100)
        {
            fpsLimit.value = PlayerPrefs.GetFloat("FPSLimit");
            Application.targetFrameRate = (int)PlayerPrefs.GetFloat("FPSLimit");
        }
        else
        {
            Application.targetFrameRate = 9999;
        }



        if (PlayerPrefs.GetInt("Quality") != 0)
        {
            int it = PlayerPrefs.GetInt("Quality");
            if (it == 1)
            {
                QualitySettings.SetQualityLevel(0);
            }
            else if (it == 2)
            {
                QualitySettings.SetQualityLevel(1);
            }
            else if (it == 3)
            {
                QualitySettings.SetQualityLevel(2);
            }
            else if (it == 4)
            {
                QualitySettings.SetQualityLevel(3);
            }
            else if (it == 5)
            {
                QualitySettings.SetQualityLevel(4);
            }
        }



    }

    public void Play()
    {
        playerStats.LoadSavedValues();
        essentials.SwitchMenu(playScreen, gameUIScreen);
        if (deathScreen.activeSelf)
            deathScreen.SetActive(false);
        playing = true;

        carScript.Spawn();
        if (audioManager.playing)
            audioManager.PlayGame();
    }

    public void OpenSettings()
    {
        Time.timeScale = 0.0f;
        essentials.SwitchMenu(gameUIScreen, settingsScreen);
    }

    public void CloseSettings()
    {
        Time.timeScale = 1.0f;
        essentials.SwitchMenu(settingsScreen, gameUIScreen);
    }

    public void Lowest()
    {
        QualitySettings.SetQualityLevel(0);
        PlayerPrefs.SetInt("Quality", 1);
    }

    public void Low()
    {
        QualitySettings.SetQualityLevel(1);
        PlayerPrefs.SetInt("Quality", 2);
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(2);
        PlayerPrefs.SetInt("Quality", 3);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(3);
        PlayerPrefs.SetInt("Quality", 4);
    }

    public void Ultra()
    {
        QualitySettings.SetQualityLevel(4);
        PlayerPrefs.SetInt("Quality", 5);
    }

    public void OnFPSLimitChange()
    {
        if (fpsLimit.value != 100)
        {
            PlayerPrefs.SetFloat("FPSLimit", fpsLimit.value);
            Application.targetFrameRate = (int)fpsLimit.value;
        }
        else
        {
            PlayerPrefs.SetFloat("FPSLimit", 9999);
            Application.targetFrameRate = (int)9999;
        }

    }

    public void FPSCounter()
    {
        if (fpsCounter.isOn)
        {
            fpsCounterText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("FPSCounter", 1);
        }

        else
        {
            fpsCounterText.gameObject.SetActive(false);
            PlayerPrefs.SetInt("FPSCounter", 0);
        }
    }

    void Update()
    {
        //  FPSLimit
        fpsAmountText.text = ((int)fpsLimit.value).ToString();

        //  FPSCounter
        fpsCounterText.text = "FPS: " + ((int)(1f / Time.deltaTime)).ToString();

        //  Speedometer
        speedCounterText.text = ((int)carMovement.currentSpeed).ToString() + "km/h";
    }

    public void Died()
    {
        bool done = false;
        if (!deathScreen.activeSelf)
        {
            deathScreen.SetActive(true);
            gameUIScreen.SetActive(false);
            done = true;
        }


        if (done)
        {
            if (audioManager.playing)
                audioManager.PlayClip(audioManager.loseClip, false);


            if (playerStats.score > PlayerPrefs.GetInt("Score"))
                highScoreText.text = "Highscore!: " + ((int)playerStats.score).ToString();
            else
            {
                //playOnDeath.SetActive(false);
                int random = Random.Range(0, bullyWordsList.Count);
                essentials.StartCoroutine(essentials.FadeTextOut(highScoreText));
                //playOnDeath.SetActive(true);
                highScoreText.text = bullyWordsList[random];
            }
            StartCoroutine(WaitAfterDied(this.deathScreen));
        }

        IEnumerator WaitAfterDied(GameObject gameObject)
        {
            // Check death screen's status
            if (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(4.2f);
                essentials.SwitchMenu(deathScreen, playScreen);


            }
        }
    }

    public void Shop(){
        essentials.SwitchMenu(playScreen, shopScreen);
    }

}
