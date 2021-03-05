using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSettings : MonoBehaviour
{
    public GameObject[] objectsToDiactivate;
    public GameObject[] texts;

    // Start is called before the first frame update
    void Start()
    {
         
         texts = GameObject.FindGameObjectsWithTag("Text");
         for (int i = 0; i < objectsToDiactivate.Length; i++)
         {
             objectsToDiactivate[i].SetActive(false);
         }

         GetComponent<GeneralSettings>().SetFontSize(PlayerPrefs.GetFloat("fontSize", 1f));   
    }

    public void SetFontSize(float size)
    {
        for (int i = 0; i < texts.Length ; i++)
        {
            texts[i].transform.localScale = new Vector3(size, size, 0);
        }
    }

}
