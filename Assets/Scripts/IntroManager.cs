using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{

    // UI vars
    public TextMeshProUGUI dialog1, dialog2, dialog3;


    // General vars
    private float _dialogDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Run first dialog
        StartCoroutine(StartDialog(dialog1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartDialog(TextMeshProUGUI  dialog)
    {
        yield return new WaitForSeconds(_dialogDelay);
        dialog.GetComponent<DialogController>().StartDialog();
    }
}
