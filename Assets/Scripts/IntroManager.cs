using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{

    // UI vars
    public TextMeshProUGUI dialog1, dialog2, dialog3;
    public GameObject dialog2Panel;


    // General vars
    private float _dialogDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Run first dialog
        StartCoroutine(StartDialog(dialog1));
    }

    // Update is called once per frame
    void Update()
    {
        // Check when the first dialog is finished
        if (dialog1.GetComponent<DialogController>().finished)
        {
            // Disable dialog 1
            dialog1.GetComponent<DialogController>().finished = false;
            dialog1.gameObject.SetActive(false);
            // Start dialgo2
            dialog2Panel.SetActive(true);
            dialog2.transform.parent.gameObject.SetActive(true);
            StartCoroutine(StartDialog(dialog2));
        }

        // Check when the second dialog is finished
        if (dialog2.GetComponent<DialogController>().finished)
        {
            // Disable dialog 2
            dialog2.GetComponent<DialogController>().finished = false;
            dialog2.gameObject.SetActive(false);
            dialog2Panel.SetActive(false);
            // Start dialog 3
            dialog3.transform.parent.gameObject.SetActive(true);
            StartCoroutine(StartDialog(dialog3));
        }


    }

    IEnumerator StartDialog(TextMeshProUGUI  dialog)
    {
        yield return new WaitForSeconds(_dialogDelay);
        dialog.GetComponent<DialogController>().StartDialog();
    }
}
