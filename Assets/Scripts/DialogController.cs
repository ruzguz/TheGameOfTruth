using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{


    // UI vars
    private TextMeshProUGUI _textDisplay;
    public GameObject continueBtn;

    // General vars
    public string[] sentences;
    private int _index;
    [SerializeField]
    private float _typingDelay = 0.05f;


    private void Start() {
        _textDisplay = GetComponent<TextMeshProUGUI>();     
    }

    private void Update() {
        // Check if current text displayed is complete
        if (_textDisplay.text == sentences[_index])
        {
            continueBtn.SetActive(true);
        }
    }

    // Text typing effect
    IEnumerator Type()
    {
        foreach(char letter in sentences[_index].ToCharArray())
        {
            yield return new WaitForSeconds(_typingDelay);
            _textDisplay.text += letter;
            
        }
    }

    public void StartDialog()
    {
        StartCoroutine(Type());
    }

    // Show next sentence in the dialog
    public void NextSentence()
    {
        // Hide coninue button
        continueBtn.SetActive(false);
        if (_index < sentences.Length - 1)
        {
            _index++;
            _textDisplay.text = "";
            StartCoroutine(Type());
        } else 
        {
            _textDisplay.text = "";
        }
    }

}
