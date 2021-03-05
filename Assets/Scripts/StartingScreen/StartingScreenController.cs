using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEasyMode()
    {
        PlayerPrefs.SetInt("playerSpeed", 70);
        PlayerPrefs.SetInt("ghostSpeed", 2);
        PlayerPrefs.SetInt("ghostQty", 10);
        PlayerPrefs.SetInt("patientLives", 10);
    }

    public void SetMediumMode()
    {
        PlayerPrefs.SetInt("playerSpeed", 75);
        PlayerPrefs.SetInt("ghostSpeed", 4);
        PlayerPrefs.SetInt("ghostQty", 12);
        PlayerPrefs.SetInt("patientLives", 8);
    }

    public void SetHardMode()
    {
        PlayerPrefs.SetInt("playerSpeed", 80);
        PlayerPrefs.SetInt("ghostSpeed", 6);
        PlayerPrefs.SetInt("ghostQty", 15);
        PlayerPrefs.SetInt("patientLives", 5);
    }

    public void SetFontSize(float size)
    {
        PlayerPrefs.SetFloat("fontSize", size);
        GetComponent<GeneralSettings>().SetFontSize(size);
    }
}
