using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    [SerializeField]
    private float _typingDelay = 0.05f;


    private void Start() {
        StartCoroutine(Type());
    }

    // Text typing effect
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(_typingDelay);
        }

    }

}
