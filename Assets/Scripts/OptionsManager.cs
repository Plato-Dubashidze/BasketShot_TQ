using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Color blackCol, whiteCol;
    public Text soundText, backgroundModeText;


    private string backgroundMode;
    private bool sound;
    private Camera cam;

    private void Awake()
    {
        sound = PlayerPrefs.GetInt("SoundBool") != 0;
        backgroundMode = PlayerPrefs.GetString("BackGroundMode");
        cam = Camera.main;
        switch (backgroundMode)
        {
            case "White":
                cam.backgroundColor = whiteCol;
                backgroundModeText.text = "Night mode: Off";
                break;
            case "Black":
                cam.backgroundColor = blackCol;
                backgroundModeText.text = "Night mode: On";
                break;
        }
        switch (sound)
        {
            case true:
                soundText.text = "Sound: On";
                break;
            case false:
                soundText.text = "Sound: Off";
                break;
        }
    }

    public void SoundButton()
    {
        switch (sound)
        {
            case true:
                sound = false;
                PlayerPrefs.SetInt("SoundBool", sound ? 1 : 0);
                soundText.text = "Sound: Off";
                AudioListener.volume = 0;
                break;
            case false:
                sound = true;
                PlayerPrefs.SetInt("SoundBool", sound ? 1 : 0);
                soundText.text = "Sound: On";
                AudioListener.volume = 1;
                break;
        }
    }
    public void BackgroundModeButton()
    {
        switch (backgroundMode)
        {
            case "White":
                cam.backgroundColor = blackCol;
                backgroundMode = "Black";
                backgroundModeText.text = "Night mode: On";
                PlayerPrefs.SetString("BackGroundMode", backgroundMode);
                break;
            case "Black":
                cam.backgroundColor = whiteCol;
                backgroundMode = "White";
                backgroundModeText.text = "Night mode: Off";
                PlayerPrefs.SetString("BackGroundMode", backgroundMode);
                break;
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainScene");
    }

}
