using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{

    [SerializeField]
    private GameObject backButton;

    [SerializeField]
    private GameObject menuButton;

    [SerializeField]
    private GameObject originalCanva;

    [SerializeField]
    private Toggle musicToggle;

    [SerializeField]
    private Toggle sfxToggle;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private Slider sliderMaster;

    [SerializeField]
    private bool isInGameConfig;

    



    // Start is called before the first frame update
    void Start()
    {
        backButton.SetActive(true);

        if (isInGameConfig)
        {
            menuButton.SetActive(true);
        }
        else
        {
            menuButton.SetActive(false);
        }

        float valueMusic;
        bool resultMusic = audioMixer.GetFloat("Music", out valueMusic);

        if(resultMusic && valueMusic == -88)
        {
            musicToggle.isOn = false;
        }
        else
        {
            musicToggle.isOn = true;
        }


        float valueFX;
        bool resultFX = audioMixer.GetFloat("SFX", out valueFX);

        if (resultFX && valueFX == -88)
        {
            sfxToggle.isOn = false;
        }
        else
        {
            sfxToggle.isOn = true;
        }


        float valueMaster;
        bool resultMaster = audioMixer.GetFloat("Master", out valueMaster);

        if (resultMaster && valueMaster == -88)
        {
            sliderMaster.value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void backButtonClick()
    {
        this.gameObject.SetActive(false);
        originalCanva.SetActive(true);
    }

    public void menuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void musicToggleClick(Toggle toggle)
    {
        if(!toggle.isOn)
        {
            audioMixer.SetFloat("Music", -88);
        }
        else
        {
            audioMixer.SetFloat("Music", -11);
        }
    }

    public void sfxToggleClick(Toggle toggle)
    {
        if (!toggle.isOn)
        {
            audioMixer.SetFloat("SFX", -88);
        }
        else
        {
            audioMixer.SetFloat("SFX", 0);
        }
    }

    public void generalVolumeSlider(float sliderValue)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20); 
        if (sliderValue == 0)
        {
            audioMixer.SetFloat("Master", -88);
        }
    }
}
