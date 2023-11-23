using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip gameMusic;
    public AudioClip deathClip;
    public AudioClip idleClip;
    public AudioClip loseClip;

    public Button audioToggle;

    public Sprite audioOn;
    public Sprite audioOff;

    public AudioSource source;
    public bool playing;


    void Start()
    {
        if (PlayerPrefs.GetInt("PlayingSound") == 1)
        {
            playing = true;
            audioToggle.GetComponent<Image>().sprite = audioOn;
        }

        else if(PlayerPrefs.GetInt("PlayingSound") == 2)
        {
            playing = false;
            audioToggle.GetComponent<Image>().sprite = audioOff;
        }

        else
        {
            playing = true;
            audioToggle.GetComponent<Image>().sprite = audioOn;
        }

    }
    public void PlayClip(AudioClip clip, bool loop)
    {

        if (!loop)
        {
            source.clip = clip;
            source.Play();
            source.loop = false;
        }
        else
        {
            source.clip = clip;
            source.Play();
            source.loop = true;
        }

    }

    public void ToggleAudio()
    {
        if (playing)
        {
            audioToggle.GetComponent<Image>().sprite = audioOff;
            source.volume = 0;
            PlayerPrefs.SetInt("PlayingSound", 2);
        }

        else
        {
            audioToggle.GetComponent<Image>().sprite = audioOn;
            source.volume = 1;
            PlayerPrefs.SetInt("PlayingSound", 1);
        }


        playing = !playing;
        
    }

    void Update(){
        if (playing){
            source.volume = 1;
        }
        else
        {
            source.volume = 0;
        }
    }

    public void PlayGame(){
        int random = Random.Range(0, 2);
        print(random.ToString());
        if(random == 0)
            this.PlayClip(gameMusic, true);
        else if(random == 1)
            this.PlayClip(idleClip, true);
    }
}
