using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicPlay : MonoBehaviour
{
    public AudioSource AudioSource;
    public Text sliderValue;
    public Slider slider;
    private float temp;
    private string value;

    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateVolume(float volume) 
    { 
        musicVolume  = volume;
        temp = volume * 100f;
        value = temp.ToString("0") + "%";
        sliderValue.text = value;
    }
}
