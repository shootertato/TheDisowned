using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class OptionsMenu : MonoBehaviour {
    public Slider slider;
    public float sliderValue;
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    private void Start() {
        sliderValue = PlayerPrefs.GetFloat("Volume", 0.5f);
        AudioListener.volume = sliderValue;
        Resolution();
    }
    public void Volume(float volume){
        sliderValue = volume;
        PlayerPrefs.SetFloat("Volume", sliderValue);
        AudioListener.volume = slider.value;
    }
    public void FullScreen(bool fullScreen){
        Screen.fullScreen = fullScreen;
    }

    public void Resolution(){
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;

        for(int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height ){
                currentResolution = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolution; 
        resolutionDropDown.RefreshShownValue();

        resolutionDropDown.value = PlayerPrefs.GetInt("indexRes", 0);
    }

    public void ChangeResolution(int resolutionIndex){
        PlayerPrefs.SetInt("indexRes", resolutionDropDown.value);
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
