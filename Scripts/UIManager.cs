using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject playScreen;
    public GameObject gameUIScreen;
    public GameObject deathScreen;
    public bool playing;
    public TextMeshProUGUI oldHighScoreText;

    private Essentials essentials;
    private PlayerStats playerStats;
    private Car carScript;
    private AudioManager audioManager;

    void Start()
    {
        if(PlayerPrefs.GetInt("Score") != 0)
            oldHighScoreText.text = "Old Highscore: " + PlayerPrefs.GetInt("Score");
        else
            oldHighScoreText.text = "No highscore!";
        
        playerStats = FindAnyObjectByType<PlayerStats>();
        essentials = FindAnyObjectByType<Essentials>();
        carScript = FindAnyObjectByType<Car>();
        audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlayClip(audioManager.idleClip, true);
        playScreen.SetActive(true);
        deathScreen.SetActive(false);
        gameUIScreen.SetActive(false);
        
    }

    public void Play()
    {
        playerStats.LoadSavedValues();
        essentials.SwitchMenu(playScreen, gameUIScreen);
        if(deathScreen.activeSelf)
            deathScreen.SetActive(false);
        playing = true;

        carScript.Spawn();
        if(audioManager.playing)
            audioManager.PlayGame();
    }

    

    public void Died()
    {
        deathScreen.SetActive(true);
        gameUIScreen.SetActive(false);
        if(audioManager.playing)
            audioManager.PlayClip(audioManager.deathClip, false);
    }

}
