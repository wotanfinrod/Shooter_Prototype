using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Sprite musicOffSprite;
    [SerializeField] Sprite musicOnSprite;
    [SerializeField] Sprite SFXOffSprite;
    [SerializeField] Sprite SFXOnSprite;

    bool musicFlag;
    bool SFXFlag;
    float mouseSensivity;

    GameObject mainCanvas;
    GameObject settingsCanvas;
    GameObject popUpScreen;

    Slider slider;
    TMP_Text sliderText;
        
    void Start()
    {
        mainCanvas = GameObject.Find("MainCanvas");
        settingsCanvas = GameObject.Find("SettingsCanvas");
        popUpScreen = GameObject.Find("Popup");
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        sliderText = GameObject.Find("SliderText").GetComponent<TMP_Text>();

        musicFlag = true;
        SFXFlag = true;
        mouseSensivity = 1f;

        settingsCanvas.SetActive(false);
        popUpScreen.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void StartButtonClick()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1); //Load the game
    }

    public void SettingsButtonClick()
    {
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void BackButtonClick()
    {
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    public void MusicButtonClick()
    {
        Image musicButImage = GameObject.Find("MusicButton").GetComponent<Image>();
        musicFlag = !musicFlag;
        if (musicFlag) musicButImage.sprite = musicOnSprite;
        else musicButImage.sprite = musicOffSprite;  
    }

    public void SFXButtonClick()
    {
        Image SFXButImage = GameObject.Find("SFXButton").GetComponent<Image>();
        SFXFlag = !SFXFlag;
        if (SFXFlag) SFXButImage.sprite = SFXOnSprite;
        else SFXButImage.sprite = SFXOffSprite;
    }

    public void InfoButtonClick()
    {
        popUpScreen.SetActive(true);
    }

    public void PopUpReturnButtonClick()
    {
        popUpScreen.SetActive(false);
    }

    public void OnSliderChanged()
    {
        mouseSensivity = slider.value;
        sliderText.text = string.Format("{0:0.##}", slider.value);
    }

    //Getters-Setters
    public bool GetMusicFlag()
    {
        return musicFlag;
    }

    public bool GetSFXFlag()
    {
        return SFXFlag;
    }

    public float GetMouseSensivity()
    {
        return mouseSensivity;
    }

}
